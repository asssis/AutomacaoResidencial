using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using Negocio.Dao;
using System.Data.SqlClient;

namespace Negocio.Dao
{
    public class EventoDAO
    {
        //METODOS PRINCIPAIS
        public string Gravar(Evento obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            if (obj.Potencia != null)
            {
                comando.CommandText = "INSERT INTO Evento (id_dispositivo, id_agenda, potencia) Values(@id_dispositivo, @id_agenda, @potencia) Select(SCOPE_IDENTITY()) as matricula";
                comando.Parameters.AddWithValue("@potencia", obj.Potencia);
            }
            else
            {
                comando.CommandText = "INSERT INTO Evento (id_dispositivo, id_comando, id_agenda) Values(@id_dispositivo, @id_comando, @id_agenda) Select(SCOPE_IDENTITY()) as matricula";
                comando.Parameters.AddWithValue("@id_comando", obj.ObjComando.Id);
            }
            comando.Parameters.AddWithValue("@id_dispositivo", obj.ObjDispositvo.Id);

            AgendaDAO daoAgenda = new AgendaDAO();
            comando.Parameters.AddWithValue("@id_agenda", daoAgenda.Gravar(obj.ObjAgenda));
            SqlDataReader dr = Conexao.Selecionar(comando);

            dr.Read();
            obj.Id = Convertt.ToInt32(dr["matricula"]);
            return "Agendamento gravado com sucesso!";
        }
        public string Alterar(Evento obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            if (obj.Potencia != null)
            {
                comando.CommandText = "Update Evento set id_dispositivo = @id_dispositivo, id_agenda = @id_agenda, potencia = @potencia from Evento where Evento.id = @id";
                comando.Parameters.AddWithValue("@potencia", obj.Potencia);
            }
            else
            {
                comando.CommandText = "Update Evento set id_dispositivo = @id_dispositivo, id_comando = @id_comando, id_agenda = @id_agenda from Evento where Evento.id = @id";
                comando.Parameters.AddWithValue("@id_comando", obj.ObjComando.Id);
            }
            comando.Parameters.AddWithValue("@id", obj.Id);
            comando.Parameters.AddWithValue("@id_dispositivo", obj.ObjDispositvo.Id);
            comando.Parameters.AddWithValue("@id_agenda", obj.ObjAgenda.Id);
            Conexao.CRUD(comando);

            AgendaDAO daoAgenda = new AgendaDAO();
            return daoAgenda.Alterar(obj.ObjAgenda);
        }
        public string Deletar(Evento obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Delete Evento from Evento where Evento.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            Conexao.CRUD(comando);
            return "Evento deletado com sucesso";
        }
        public string DeletarTodosEventosDispositivo(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Delete Evento from Evento where Evento.id_dispositivo = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            Conexao.CRUD(comando);
            return "Eventos deletados com sucesso";
        }

        //METODOS DE BUSCAS
        public Evento BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Evento where Evento.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);

            ComandoDAO daoComando = new ComandoDAO();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            AgendaDAO daoAgenda = new AgendaDAO();

            if (dr.HasRows)
            {
                dr.Read();
                Evento objEvento = new Evento();
                objEvento.Id = Convert.ToInt32(dr["id"]);
                try
                {
                    objEvento.ObjComando = daoComando.BuscarId(Convert.ToInt32(dr["id_comando"]));
                }
                catch
                {
                }

                objEvento.ObjDispositvo = daoDispositivo.BuscarId(Convert.ToInt32(dr["id_dispositivo"]));
                objEvento.ObjAgenda = daoAgenda.BuscarId(Convert.ToInt32(dr["id_agenda"]));
                objEvento.Potencia = Convertt.ToString(dr["potencia"]);
                return objEvento;
            }
            return null;
        }
        public Evento BuscarId(Evento obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Evento where Evento.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);

            ComandoDAO daoComando = new ComandoDAO();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            AgendaDAO daoAgenda = new AgendaDAO();

            if (dr.HasRows)
            {
                dr.Read();
                Evento objEvento = new Evento();
                objEvento.Id = Convert.ToInt32(dr["id"]);
                objEvento.ObjComando = daoComando.BuscarId(Convert.ToInt32(dr["id_comando"]));
                objEvento.ObjDispositvo = daoDispositivo.BuscarId(Convert.ToInt32(dr["id_dispositivo"]));
                objEvento.ObjAgenda = daoAgenda.BuscarId(Convert.ToInt32(dr["id_agenda"]));
                objEvento.Potencia = Convertt.ToString(dr["potencia"]);
                return objEvento;
            }
            return null;
        }
        public List<Evento> BuscarEventoBanco(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Evento where Evento.id_dispositivo = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Evento> objsEventos = new List<Evento>();
            ComandoDAO daoComando = new ComandoDAO();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            AgendaDAO daoAgenda = new AgendaDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Evento objEvento = new Evento();
                    objEvento.Id = Convert.ToInt32(dr["id"]);
                    try
                    {
                        objEvento.ObjComando = daoComando.BuscarId(Convert.ToInt32(dr["id_comando"]));
                    }
                    catch
                    {
                    }
                    objEvento.ObjDispositvo = daoDispositivo.BuscarId(Convert.ToInt32(dr["id_dispositivo"]));
                    objEvento.ObjAgenda = daoAgenda.BuscarId(Convert.ToInt32(dr["id_agenda"]));
                    objEvento.Potencia = Convertt.ToString(dr["potencia"]);
                    objsEventos.Add(objEvento);
                }
                return objsEventos;
            }
            return null;
        }
        public Dispositivo BuscarEventosDispositivo(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Evento where Evento.id_dispositivo = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            ComandoDAO daoComando = new ComandoDAO();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            AgendaDAO daoAgenda = new AgendaDAO();
            if (dr.HasRows)
            {
                obj.ObjsEventos = new List<Evento>();
                while (dr.Read())
                {
                    Evento objEvento = new Evento();
                    objEvento.Id = Convert.ToInt32(dr["id"]);
                    objEvento.ObjComando = daoComando.BuscarId(Convertt.ToInt32(dr["id_comando"]));
                    objEvento.ObjDispositvo = daoDispositivo.BuscarId(Convertt.ToInt32(dr["id_dispositivo"]));
                    objEvento.ObjAgenda = daoAgenda.BuscarId(Convertt.ToInt32(dr["id_agenda"]));
                    objEvento.Potencia = Convertt.ToString(dr["potencia"]);
                    obj.ObjsEventos.Add(objEvento);
                }
                return obj;
            }
            return null;
        }
        public IList<Evento> BuscarEventosUsuario(Usuario obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Evento where Evento.id_usuario = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Evento> objsEventos = new List<Evento>();
            ComandoDAO daoComando = new ComandoDAO();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            AgendaDAO daoAgenda = new AgendaDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Evento objEvento = new Evento();
                    objEvento.Id = Convert.ToInt32(dr["id"]);
                    objEvento.ObjComando = daoComando.BuscarId(Convert.ToInt32(dr["id_comando"]));
                    objEvento.ObjDispositvo = daoDispositivo.BuscarId(Convert.ToInt32(dr["id_dispositivo"]));
                    objEvento.ObjAgenda = daoAgenda.BuscarId(Convert.ToInt32(dr["id_agenda"]));
                    objEvento.Potencia = Convertt.ToString(dr["potencia"]);
                    objsEventos.Add(objEvento);
                }
                return objsEventos;
            }
            return null;
        }

        //METODOS DE VALIDAÇÕES
        public bool VerificarEventoDispositivo(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Evento where Evento.id_dispositivo = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            return dr.HasRows;
        }
    }
}
