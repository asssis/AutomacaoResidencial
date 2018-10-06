using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dao
{
    public class DivisaoDAO
    {
        //METODOS PRINCIPAIS
        public string Gravar(Divisao obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Divisao (id_unidade, descricao) VALUES (@id_unidade, @descricao) Select(SCOPE_IDENTITY()) as matricula";
                comando.Parameters.AddWithValue("@descricao", obj.Descricao);
                comando.Parameters.AddWithValue("@id_unidade", obj.ObjUnidade.Id);
               
                SqlDataReader dr = Conexao.Selecionar(comando);
                dr.Read();

                obj.Id = Convertt.ToInt32(dr["matricula"]);
                return "Divisão gravado com sucesso, Nº Matricula " + obj.Id.ToString();
  
        }
        public string Alterar(Divisao obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Divisao set descricao = @descricao, id_unidade = @id_unidade from Divisao where Divisao.id = @id";
       
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@descricao", obj.Descricao);
                comando.Parameters.AddWithValue("@id_unidade", obj.ObjUnidade.Id);
                Conexao.CRUD(comando);
                return "Divisao alterada com sucesso";
        }
        public string Deletar(Divisao obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Delete from Divisao where Divisao.id = @id";

            comando.Parameters.AddWithValue("@id", obj.Id);

            Conexao.CRUD(comando);
            return "Divisão deletado com sucesso";
        }

        //METODOS DE BUSCAS
        public Divisao BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Divisao where Divisao.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Divisao objDivisao = new Divisao();
            UnidadeDAO daoUnidade = new UnidadeDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objDivisao.Id = Convert.ToInt32(dr["id"]);
                    objDivisao.Descricao = Convert.ToString(dr["descricao"]);
                    //BUSCANDO UNIDADE
                    objDivisao.ObjUnidade = daoUnidade.BuscarId((int)dr["id_unidade"]);
                }

                return objDivisao;
            }
            return null;
        }

        public Divisao BuscarId(Divisao obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Divisao where Divisao.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Divisao objDivisao = new Divisao();
            UnidadeDAO daoUnidade = new UnidadeDAO();
            if (dr.HasRows)
            {
                dr.Read();
                    objDivisao.Id = Convert.ToInt32(dr["id"]);
                    objDivisao.Descricao = Convert.ToString(dr["descricao"]);
                    //BUSCANDO USUARIO
                    objDivisao.ObjUnidade.Id = Convert.ToInt32(dr["id_unidade"]);
                    objDivisao.ObjUnidade = daoUnidade.BuscarId(objDivisao.ObjUnidade);
            
            return objDivisao;
            }
            return null;
        }
        public List<Divisao> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Divisao";
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Divisao> objsDivisoes = new List<Divisao>();
            UnidadeDAO daoUnidade = new UnidadeDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Divisao objDivisao = new Divisao();
                    objDivisao.Id = Convert.ToInt32(dr["id"]);
                    objDivisao.Descricao = Convert.ToString(dr["descricao"]);
                    //BUSCANDO USUARIO
                    objDivisao.ObjUnidade.Id = Convert.ToInt32(dr["id_unidade"]);
                    objDivisao.ObjUnidade = daoUnidade.BuscarId(objDivisao.ObjUnidade);

                    objsDivisoes.Add(objDivisao);
                }
            return objsDivisoes;
            }
            return null;
        }
        public List<Divisao> BuscarDivisoesUnidade(Unidade obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Divisao where Divisao.id_unidade = @id";
            comando.Parameters.AddWithValue("@id",obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Divisao> objsDivisoes = new List<Divisao>();
            UnidadeDAO daoUnidade = new UnidadeDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Divisao objDivisao = new Divisao();
                    objDivisao.Id = Convert.ToInt32(dr["id"]);
                    objDivisao.Descricao = Convert.ToString(dr["descricao"]);
                    //BUSCANDO USUARIO
                    objDivisao.ObjUnidade.Id = Convert.ToInt32(dr["id_unidade"]);
                    objDivisao.ObjUnidade = daoUnidade.BuscarId(objDivisao.ObjUnidade);

                    objsDivisoes.Add(objDivisao);
                }
                return objsDivisoes;
            }
            return null;
        }

        public Divisao BuscarDispositivosDivisao(Divisao obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Divisao where Divisao.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Divisao objDivisao = new Divisao();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            if (dr.HasRows)
            {
                dr.Read();
                    objDivisao.Id = Convert.ToInt32(dr["id"]);
                    objDivisao.Descricao = Convert.ToString(dr["descricao"]);

                    //BUSCANDO DISPOSITIVOS
                objDivisao.ObjsDispositivos = daoDispositivo.BuscarDispositivosDivisao(objDivisao);
                return objDivisao;        
            }            
            return null;
        }
        public bool VerificarDispositivosDivisao(Divisao obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Dispositivo where Dispositivo.id_divisao = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            return dr.HasRows;
        }
    }
}
