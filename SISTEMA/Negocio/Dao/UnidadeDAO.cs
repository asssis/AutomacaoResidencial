using Negocio.Dao;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dao
{
    public class UnidadeDAO
    {
        //METODOS PRINCIPAIS
        public string Gravar(Unidade obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Unidade (descricao, id_usuario, estado, endereco, numero, bairro, cidade, pais, tempo, cep) VALUES (@descricao, @id_usuario, @estado, @endereco, @numero, @bairro, @cidade, @pais, @tempo, @cep) Select(SCOPE_IDENTITY()) as matricula";

                comando.Parameters.AddWithValue("@descricao", obj.Descricao);
                comando.Parameters.AddWithValue("@id_usuario", obj.ObjUsuario.Id);
                comando.Parameters.AddWithValue("@estado", obj.Estado);
                comando.Parameters.AddWithValue("@endereco", obj.Endereco);
                comando.Parameters.AddWithValue("@numero", obj.Numero);
                comando.Parameters.AddWithValue("@bairro", obj.Bairro);
                comando.Parameters.AddWithValue("@cidade", obj.Cidade);
                comando.Parameters.AddWithValue("@pais", obj.Pais);
                comando.Parameters.AddWithValue("@tempo", obj.Tempo);
                comando.Parameters.AddWithValue("@cep", obj.Cep);

                SqlDataReader dr = Conexao.Selecionar(comando);
                dr.Read();
                obj.Id = Convertt.ToInt32(dr["matricula"]);
                return "Unidade gravado com sucesso, Nº Matricula " + obj.Id.ToString();
        }
        public string Alterar(Unidade obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Unidade set descricao = @descricao, id_usuario = @id_usuario, estado = @estado, endereco = @endereco, numero = @numero, bairro = @bairro, cidade = @cidade, pais = @pais, tempo = @tempo, cep = @cep from Unidade where Unidade.id = @id";
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@descricao", obj.Descricao);
                comando.Parameters.AddWithValue("@id_usuario", obj.ObjUsuario.Id);
                comando.Parameters.AddWithValue("@estado", obj.Estado);
                comando.Parameters.AddWithValue("@endereco", obj.Endereco);
                comando.Parameters.AddWithValue("@numero", obj.Numero);
                comando.Parameters.AddWithValue("@bairro", obj.Bairro);
                comando.Parameters.AddWithValue("@cidade", obj.Cidade);
                comando.Parameters.AddWithValue("@pais", obj.Pais);
                comando.Parameters.AddWithValue("@tempo", obj.Tempo);
                comando.Parameters.AddWithValue("@cep", obj.Cep);
                Conexao.CRUD(comando);
                return "Unidade alterado com sucesso";
        }
        public string Deletar(Unidade obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            
            comando.CommandText = "Delete From Unidade where Unidade.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            
            Conexao.CRUD(comando);
            return "Unidade deletado com sucesso";
        }

        //METODOS DE BUSCAS
        public Unidade BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Unidade where Unidade.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Unidade objUnidade = new Unidade();
            UsuarioDAO daoUsuario = new UsuarioDAO();
            DivisaoDAO daoDivisao = new DivisaoDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objUnidade.Id = Convert.ToInt32(dr["id"]);
                objUnidade.Descricao = Convert.ToString(dr["descricao"]);
                objUnidade.Estado = Convert.ToString(dr["estado"]);
                objUnidade.Endereco = Convert.ToString(dr["endereco"]);
                objUnidade.Numero = Convert.ToString(dr["numero"]);
                objUnidade.Bairro = Convert.ToString(dr["bairro"]);
                objUnidade.Cidade = Convert.ToString(dr["cidade"]);
                objUnidade.Pais = Convert.ToString(dr["pais"]);
                objUnidade.Tempo = Convert.ToInt32(dr["tempo"]);
                objUnidade.Cep = Convert.ToString(dr["cep"]);
                objUnidade.ObjUsuario = daoUsuario.BuscarId((int)dr["id_usuario"]);
                return objUnidade;
            }
            return null;
        }


        public Unidade BuscarId(Unidade obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Unidade where Unidade.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Unidade objUnidade = new Unidade();
            DivisaoDAO daoDivisao = new DivisaoDAO();
            UsuarioDAO daoUsuario = new UsuarioDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objUnidade.Id = Convert.ToInt32(dr["id"]);
                objUnidade.Descricao = Convert.ToString(dr["descricao"]);
                objUnidade.Estado = Convert.ToString(dr["estado"]);
                objUnidade.Endereco = Convert.ToString(dr["endereco"]);
                objUnidade.Numero = Convert.ToString(dr["numero"]);
                objUnidade.Bairro = Convert.ToString(dr["bairro"]);
                objUnidade.Cidade = Convert.ToString(dr["cidade"]);
                objUnidade.Pais = Convert.ToString(dr["pais"]);
                objUnidade.Tempo = Convert.ToInt32(dr["tempo"]);
                objUnidade.Cep = Convert.ToString(dr["cep"]);
                //BUSCANDO USUARIO
                objUnidade.ObjUsuario = daoUsuario.BuscarId((int)dr["id_usuario"]);
                return objUnidade;
            }
            return null;
        }
        public List<Unidade> BuscarTodos(string valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Unidade";
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Unidade> objsUnidades = new List<Unidade>();
            UsuarioDAO daoUsuario = new UsuarioDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Unidade objUnidade = new Unidade();
                    objUnidade.Id = Convert.ToInt32(dr["id"]);
                    objUnidade.Descricao = Convert.ToString(dr["descricao"]);
                    objUnidade.Estado = Convert.ToString(dr["estado"]);
                    objUnidade.Endereco = Convert.ToString(dr["endereco"]);
                    objUnidade.Numero = Convert.ToString(dr["numero"]);
                    objUnidade.Bairro = Convert.ToString(dr["bairro"]);
                    objUnidade.Cidade = Convert.ToString(dr["cidade"]);
                    objUnidade.Pais = Convert.ToString(dr["pais"]);
                    objUnidade.Tempo = Convert.ToInt32(dr["tempo"]);
                    objUnidade.Cep = Convert.ToString(dr["cep"]);
                    //BUSCANDO USUARIO
                    objUnidade.ObjUsuario.Id = Convert.ToInt32(dr["id_usuario"]);
                    objUnidade.ObjUsuario = daoUsuario.BuscarId(objUnidade.ObjUsuario);

                    objsUnidades.Add(objUnidade);
                }
            return objsUnidades;
            }
            return null;
        }
        public Unidade BuscarDivisoesUnidade(Unidade obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Unidade";
            SqlDataReader dr = Conexao.Selecionar(comando);
            Unidade objUnidade = new Unidade();
            DivisaoDAO daoDivisao = new DivisaoDAO();
            if (dr.HasRows)
            {
                dr.Read();
                    objUnidade.Id = Convert.ToInt32(dr["id"]);
                    objUnidade.Descricao = Convert.ToString(dr["descricao"]);
                    objUnidade.Estado = Convert.ToString(dr["estado"]);
                    objUnidade.Endereco = Convert.ToString(dr["endereco"]);
                    objUnidade.Numero = Convert.ToString(dr["numero"]);
                    objUnidade.Bairro = Convert.ToString(dr["bairro"]);
                    objUnidade.Cidade = Convert.ToString(dr["cidade"]);
                    objUnidade.Pais = Convert.ToString(dr["pais"]);
                    objUnidade.Tempo = Convert.ToInt32(dr["tempo"]);
                    objUnidade.Cep = Convert.ToString(dr["cep"]);

                    //BUSCANDO DIVISOES
                    objUnidade.ObjsDivisoes = daoDivisao.BuscarDivisoesUnidade(obj);

            }
            return objUnidade;
        }
        public List<Unidade> BuscarUnidadesUsuario(Usuario obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Unidade where Unidade.id_usuario = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Unidade> objsUnidades = new List<Unidade>();
            UsuarioDAO daoUsuario = new UsuarioDAO();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Unidade objUnidade = new Unidade();
                    objUnidade.Id = Convert.ToInt32(dr["id"]);
                    objUnidade.Descricao = Convert.ToString(dr["descricao"]);
                    objUnidade.Estado = Convert.ToString(dr["estado"]);
                    objUnidade.Endereco = Convert.ToString(dr["endereco"]);
                    objUnidade.Numero = Convert.ToString(dr["numero"]);
                    objUnidade.Bairro = Convert.ToString(dr["bairro"]);
                    objUnidade.Cidade = Convert.ToString(dr["cidade"]);
                    objUnidade.Pais = Convert.ToString(dr["pais"]);
                    objUnidade.Tempo = Convert.ToInt32(dr["tempo"]);
                    objUnidade.Cep = Convert.ToString(dr["cep"]);

                    objUnidade.ObjUsuario = daoUsuario.BuscarId((int)dr["id_usuario"]);

                    objsUnidades.Add(objUnidade);
                }
                return objsUnidades;
            }
                return null;
        }
        public bool VerificarUnidadeUsuario(Usuario obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Unidade where Unidade.id_usuario = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);

            return dr.HasRows;
        }

        public bool VerificarDivisaoUnidade(Unidade obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Divisao where Divisao.id_unidade = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);

            return dr.HasRows;
        }
    }
}
