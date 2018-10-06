using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dao
{
    public class HistoricoDAO
    {
        //METODOS PRINCIPAIS
        public bool Gravar(Historico obj)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Historico (id_comando, id_dispositivo, momento, descricao, consumoenergia) VALUES (@id_comando, @id_dispositivo, @momento, @descricao, @consumoagua)";
                comando.Parameters.AddWithValue("@id_comando", obj.ObjComando.Id);
                comando.Parameters.AddWithValue("@id_dispositivo", obj.ObjDispositivo.Id);
                comando.Parameters.AddWithValue("@momento", obj.Momento);
                comando.Parameters.AddWithValue("@descricao", obj.Descricao);
                comando.Parameters.AddWithValue("@consumoenergia", obj.ConsumoAgua);
                comando.Parameters.AddWithValue("@consumoagua", obj.ConsumoEnergia);
                Conexao.CRUD(comando);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //METODOS DE BUSCAS
        public Historico BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Historico where Historico.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Historico objHistorico = new Historico();

            ComandoDAO daoComando = new ComandoDAO();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objHistorico.Id = Convert.ToInt32(dr["id"]);
                    objHistorico.Momento = Convert.ToDateTime(dr["momento"]);
                    objHistorico.Descricao = Convert.ToString(dr["descricao"]);
                    objHistorico.ConsumoEnergia = Convertt.ToDouble(dr["consumoenergia"]);
                    objHistorico.ConsumoAgua = Convertt.ToDouble(dr["consumoagua"]);
                    //BUSCANDO COMANDO
                    objHistorico.ObjComando = daoComando.BuscarId(Convert.ToInt32(dr["id_comando"]));
                    //BUSCANDO DISPOSITIVO
                    objHistorico.ObjDispositivo = daoDispositivo.BuscarId(Convert.ToInt32("id_dispositivo"));
                }
            }
            return objHistorico;
        }
        public Historico BuscarId(Historico obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Historico where Historico.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Historico objHistorico = new Historico();
            ComandoDAO daoComando = new ComandoDAO();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            if (dr.HasRows)
            {
               dr.Read();
               objHistorico.Id = Convert.ToInt32(dr["id"]);
               objHistorico.Momento = Convert.ToDateTime(dr["momento"]);
               objHistorico.Descricao = Convert.ToString(dr["descricao"]);
                objHistorico.ConsumoEnergia = Convertt.ToDouble(dr["consumoenergia"]);
                objHistorico.ConsumoAgua = Convertt.ToDouble(dr["consumoagua"]);
                //BUSCANDO COMANDO
                objHistorico.ObjComando = daoComando.BuscarId(Convert.ToInt32(dr["id_comando"]));
               //BUSCANDO DISPOSITIVO
               objHistorico.ObjDispositivo = daoDispositivo.BuscarId(Convert.ToInt32("id_dispositivo"));
            }
            return objHistorico;
        }

        public List<Historico> BuscarHistoricoDispositivo(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select TOP 10 * from Historico where id_dispositivo = @id order by Historico.id DESC";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            ComandoDAO daoComando = new ComandoDAO();
            List<Historico> objsHistoricos = new List<Historico>();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Historico objHistorico = new Historico();
                    objHistorico.Id = Convert.ToInt32(dr["id"]);
                    objHistorico.Momento = Convert.ToDateTime(dr["momento"]);
                    objHistorico.Descricao = Convert.ToString(dr["descricao"]);
                    objHistorico.ConsumoEnergia = Convertt.ToDouble(dr["consumoenergia"]);
                    objHistorico.ConsumoAgua = Convertt.ToDouble(dr["consumoagua"]);
                    //BUSCANDO COMANDO
                    objHistorico.ObjComando = daoComando.BuscarId(Convert.ToInt32(dr["id_comando"]));
                    //BUSCANDO DISPOSITIVO
                    objHistorico.ObjDispositivo = daoDispositivo.BuscarId(Convertt.ToInt32(dr["id_dispositivo"]));
                    objsHistoricos.Add(objHistorico);
                }
                return objsHistoricos;
            }
            else
            {
                return null;
            }
        }

        public List<Historico> BuscarHistoricoDispositivo(Dispositivo obj, DateTime dataInicial, DateTime dataFinal)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Historico Where Historico.id_dispositivo = @id_dispositivo and CAST(Historico.momento AS DATE) BETWEEN @dataInicial AND @dataFinal order by Historico.id asc";
            comando.Parameters.AddWithValue("@id_dispositivo", obj.Id);
            comando.Parameters.AddWithValue("@dataInicial", dataInicial);
            comando.Parameters.AddWithValue("@dataFinal", dataFinal);
            SqlDataReader dr = Conexao.Selecionar(comando);
            ComandoDAO daoComando = new ComandoDAO();
            List<Historico> objsHistoricos = new List<Historico>();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Historico objHistorico = new Historico();
                    objHistorico.Id = Convert.ToInt32(dr["id"]);
                    objHistorico.Momento = Convert.ToDateTime(dr["momento"]);
                    objHistorico.Descricao = Convert.ToString(dr["descricao"]);
                    objHistorico.ConsumoEnergia = Convertt.ToDouble(dr["consumoenergia"]);
                    objHistorico.ConsumoAgua = Convertt.ToDouble(dr["consumoagua"]);
                    //BUSCANDO COMANDO
                    objHistorico.ObjComando = daoComando.BuscarId(Convert.ToInt32(dr["id_comando"]));
                    //BUSCANDO DISPOSITIVO
                    objHistorico.ObjDispositivo = daoDispositivo.BuscarId(Convertt.ToInt32(dr["id_dispositivo"]));
                    objsHistoricos.Add(objHistorico);
                }
                return objsHistoricos;
            }
            else
            {
                return null;
            }
        }

        public bool VerificarHistoricoDispositivo(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Historico where Historico.id_dispositivo = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            return dr.HasRows;
        }

        public Historico BuscarUltimoHistoricoDispositivo(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select top 1 * from Historico where Historico.id_dispositivo = @id order by id desc";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Historico objHistorico = new Historico();

            if (dr.HasRows)
            {
                dr.Read();
                objHistorico.Id = Convert.ToInt32(dr["id"]);
                objHistorico.Momento = Convert.ToDateTime(dr["momento"]);
                objHistorico.Descricao = Convert.ToString(dr["descricao"]);
                objHistorico.ConsumoEnergia = Convertt.ToDouble(dr["consumoenergia"]);
                objHistorico.ConsumoAgua = Convertt.ToDouble(dr["consumoagua"]);
            }
            return objHistorico;
        }
    }
}
