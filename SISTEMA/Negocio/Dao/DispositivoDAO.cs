using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dao
{
    public class DispositivoDAO
    {
        //METODOS PRINCIPAIS
        public string Gravar(Dispositivo obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Dispositivo (nome, id_divisao, id_controle, porta, pinoentrada) VALUES (@nome, @id_divisao, @id_controle, @porta, @pinoentrada) Select(SCOPE_IDENTITY()) as matricula";
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@id_divisao", obj.ObjDivisao.Id);
                comando.Parameters.AddWithValue("@id_controle", obj.ObjControle.Id);
                comando.Parameters.AddWithValue("@porta", obj.Porta);
                comando.Parameters.AddWithValue("@pinoentrada", obj.PinoEntrada);

                SqlDataReader dr = Conexao.Selecionar(comando);
                dr.Read();

                obj.Id = Convertt.ToInt32(dr["matricula"]);
                return "Dispositivo gravado com sucesso, Nº Matricula " + obj.Id;
        }
        public string Alterar(Dispositivo obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Dispositivo set nome = @nome, porta = @porta, id_controle = @id_controle, id_divisao = @id_divisao, pinoentrada = @pinoentrada from Dispositivo where Dispositivo.id = @id";

                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@porta", obj.Porta);
                comando.Parameters.AddWithValue("@pinoentrada", obj.PinoEntrada);
                comando.Parameters.AddWithValue("@id_divisao", obj.ObjDivisao.Id);
                comando.Parameters.AddWithValue("@id_controle", obj.ObjControle.Id);

                Conexao.CRUD(comando);
                return "Dispositivo alterado com sucesso.";
     
        }
        public string Deletar(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Delete From Dispositivo where Dispositivo.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);

            Conexao.CRUD(comando);
            return "Dispositivo deletado com sucesso.";
        }

        //METODOS BUSCAS
        public Dispositivo BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Dispositivo where Dispositivo.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Dispositivo objDispositivo = new Dispositivo();
            ControleDAO daoControle = new ControleDAO();
            DivisaoDAO daoDivisao = new DivisaoDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objDispositivo.Id = Convert.ToInt32(dr["id"]);
                objDispositivo.Nome = Convert.ToString(dr["nome"]);
                objDispositivo.Porta = Convert.ToString(dr["porta"]);
                objDispositivo.PinoEntrada = Convertt.ToInt32(dr["pinoentrada"]);

                //BUSCANDO CONTROLE
                objDispositivo.ObjControle = daoControle.BuscarId((int)dr["id_controle"]);

                //BUSCANDO DIVISÃO
                objDispositivo.ObjDivisao = daoDivisao.BuscarId((int)dr["id_divisao"]);
                return objDispositivo;
            }
            return null;
        }
        public Dispositivo BuscarId(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Dispositivo where Dispositivo.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Dispositivo objDispositivo = new Dispositivo();
            ControleDAO daoControle = new ControleDAO();
            DivisaoDAO daoDivisao = new DivisaoDAO();

            if (dr.HasRows)
            {
                dr.Read();
                objDispositivo.Id = Convert.ToInt32(dr["id"]);
                objDispositivo.Nome = Convert.ToString(dr["nome"]);
                objDispositivo.Porta = Convert.ToString(dr["porta"]);
                objDispositivo.PinoEntrada = Convertt.ToInt32(dr["pinoentrada"]);
                    
                 //BUSCANDO CONTROLE
                 objDispositivo.ObjControle = daoControle.BuscarId((int)dr["id_controle"]);

                 //BUSCANDO DIVISÃO
                 objDispositivo.ObjDivisao = daoDivisao.BuscarId((int)dr["id_divisao"]);                
                return objDispositivo;
            }
            return null;
        }
        public List<Dispositivo> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Dispositivo";
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Dispositivo> objsDispositivos = new List<Dispositivo>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Dispositivo objDispositivo = new Dispositivo();
                    objDispositivo.Id = Convert.ToInt32(dr["id"]);
                    objDispositivo.Nome = Convert.ToString(dr["nome"]);
                    objDispositivo.Porta = Convert.ToString(dr["porta"]);
                    objDispositivo.PinoEntrada = Convertt.ToInt32(dr["pinoentrada"]);
                    objDispositivo.ObjControle.Id = Convert.ToInt32(dr["id_controle"]);
                    objDispositivo.ObjDivisao.Id = Convert.ToInt32(dr["id_divisao"]);
                    objsDispositivos.Add(objDispositivo);
                }
                return objsDispositivos;
            }
            return null;
        }
        public List<Dispositivo> BuscarDispositivosDivisao(Divisao obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Dispositivo where Dispositivo.id_divisao = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            ControleDAO daoControle = new ControleDAO();
            DivisaoDAO daoDivisao = new DivisaoDAO();
            List<Dispositivo> objsDispositivos = new List<Dispositivo>();
            EventoDAO daoEvento = new EventoDAO();
            LeitorDAO daoLeitor = new LeitorDAO();
            Dispositivo objDispositivo = new Dispositivo();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objDispositivo = new Dispositivo();
                    objDispositivo.Id = Convert.ToInt32(dr["id"]);
                    objDispositivo.Nome = Convert.ToString(dr["nome"]);
                    objDispositivo.Porta = Convert.ToString(dr["porta"]);
                    objDispositivo.PinoEntrada = Convertt.ToInt32(dr["pinoentrada"]);

                    //BUSCANDO DIVISÃO
                    objDispositivo.ObjDivisao = daoDivisao.BuscarId((int)dr["id_divisao"]);
                    objsDispositivos.Add(objDispositivo);

                    //BUSCANDO LEITORES
                    objDispositivo.ObjsLeitores = daoLeitor.BuscarLeitoresDispositivo(objDispositivo);
                    //BUSCANDO EVENTOS
                    daoEvento.BuscarEventosDispositivo(objDispositivo);
                }
                return objsDispositivos;
            }
            return null;
        }
    }
}
