using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using System.Data.SqlClient;

namespace Negocio.Dao
{
    public class UsuarioDAO
    {
        //METODOS PRINCIPAIS
        public string Gravar(Usuario obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Usuario (nome, login, senha, cpf_cnpj, telefone, email, ativacao, nivel) VALUES (@nome, @login, @senha, @cpf_cnpj, @telefone, @email, @ativacao, @nivel) Select(SCOPE_IDENTITY()) as matricula";
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@login", obj.Login);
                comando.Parameters.AddWithValue("@senha", obj.Senha);
                comando.Parameters.AddWithValue("@cpf_cnpj", obj.CpfCnpj);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@email", obj.Email);
                comando.Parameters.AddWithValue("@ativacao", obj.Ativacao);
                comando.Parameters.AddWithValue("@nivel", (int)obj.Nivel);
                
                SqlDataReader dr = Conexao.Selecionar(comando);
                dr.Read();
                obj.Id = Convertt.ToInt32(dr["matricula"]);
                return "Usuario gravado com sucesso, Nº Matricula " + Convert.ToString(obj.Id);
        }
        public string Alterar(Usuario obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Usuario set nome = @nome, login = @login, senha = @senha, cpf_cnpj = @cpf_cnpj, telefone = @telefone, email = @email, nivel = @nivel, ativacao = @ativacao from Usuario where Usuario.id = @id";
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@login", obj.Login);
                comando.Parameters.AddWithValue("@senha", obj.Senha);
                comando.Parameters.AddWithValue("@cpf_cnpj", obj.CpfCnpj);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@email", obj.Email);
                comando.Parameters.AddWithValue("@ativacao", obj.Ativacao);
                comando.Parameters.AddWithValue("@nivel", (int)obj.Nivel);
                Conexao.CRUD(comando);
                return "Usuario alterado com sucesso";
        }
        public string Deletar(Usuario obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Delete From Usuario where Usuario.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            Conexao.CRUD(comando);
            return "Usuario deletado com sucesso";
        }

        //METODOS DE BUSCAS
        public Usuario BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Usuario where Usuario.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Usuario objUsuario = new Usuario();
            if (dr.HasRows)
            {
                dr.Read();
                objUsuario.Id = Convert.ToInt32(dr["id"]);
                objUsuario.Login = Convert.ToString(dr["login"]);
                objUsuario.Nome = Convert.ToString(dr["nome"]);
                objUsuario.Senha = Convert.ToString(dr["senha"]);
                objUsuario.CpfCnpj = Convert.ToString(dr["cpf_cnpj"]);
                objUsuario.Telefone = Convert.ToString(dr["telefone"]);
                objUsuario.Email = Convert.ToString(dr["email"]);
                //objUsuario.Ativacao = Convert.ToBoolean(dr["ativacao"]);
                objUsuario.Nivel = Convertt.ToNivelAcesso(dr["nivel"]);

            }
            else
            {
                return null;
            }
            return objUsuario;
        }
        public Usuario BuscarId(Usuario obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select * from Usuario where Usuario.id = @id";
                comando.Parameters.AddWithValue("@id", obj.Id);
                SqlDataReader dr = Conexao.Selecionar(comando);
                Usuario objUsuario = new Usuario();
                if (dr.HasRows)
                {
                    dr.Read();
                    objUsuario.Id = Convert.ToInt32(dr["id"]);
                    objUsuario.Login = Convert.ToString(dr["login"]);
                    objUsuario.Nome = Convert.ToString(dr["nome"]);
                    objUsuario.Senha = Convert.ToString(dr["senha"]);
                    objUsuario.CpfCnpj = Convert.ToString(dr["cpf_cnpj"]);
                    objUsuario.Telefone = Convert.ToString(dr["telefone"]);
                    objUsuario.Email = Convert.ToString(dr["email"]);
                    objUsuario.Ativacao = Convert.ToBoolean(dr["ativacao"]);
                    objUsuario.Nivel = Convertt.ToNivelAcesso(dr["nivel"]);
                }
                else
                {
                    return null;
                }
                return objUsuario;
        }
        public Usuario BuscarLogin(Usuario obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Usuario where Usuario.login = @login";
            comando.Parameters.AddWithValue("@login", obj.Login);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Usuario objUsuario = new Usuario();
            UnidadeDAO daoUnidade = new UnidadeDAO();
            if (dr.HasRows)
            {
                dr.Read();
                    objUsuario.Id = Convert.ToInt32(dr["id"]);
                    objUsuario.Login = Convert.ToString(dr["login"]);
                    objUsuario.Nome = Convert.ToString(dr["nome"]);
                    objUsuario.Senha = Convert.ToString(dr["senha"]);
                    objUsuario.CpfCnpj = Convert.ToString(dr["cpf_cnpj"]);
                    objUsuario.Telefone = Convert.ToString(dr["telefone"]);
                    objUsuario.Email = Convert.ToString(dr["email"]);
                    objUsuario.Ativacao = Convert.ToBoolean(dr["ativacao"]);
                    objUsuario.Nivel = Convertt.ToNivelAcesso(dr["nivel"]);
                    objUsuario.ObjsUnidades = daoUnidade.BuscarUnidadesUsuario(objUsuario);
            }
            else
            {
                return null;
            }
            return objUsuario;
        }
        public Usuario BuscarCpf(Usuario obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Usuario where Usuario.cpf_cnpj = @cpf_cnpj";
            comando.Parameters.AddWithValue("@cpf_cnpj", obj.CpfCnpj);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Usuario objUsuario = new Usuario();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objUsuario.Id = Convert.ToInt32(dr["id"]);
                    objUsuario.Login = Convert.ToString(dr["login"]);
                    objUsuario.Nome = Convert.ToString(dr["nome"]);
                    objUsuario.Senha = Convert.ToString(dr["senha"]);
                    objUsuario.CpfCnpj = Convert.ToString(dr["cpf_cnpj"]);
                    objUsuario.Telefone = Convert.ToString(dr["telefone"]);
                    objUsuario.Email = Convert.ToString(dr["email"]);
                    objUsuario.Ativacao = Convert.ToBoolean(dr["ativacao"]);
                    objUsuario.Nivel = Convertt.ToNivelAcesso(dr["nivel"]);
                }

            }
            else
            {
                return null;
            }
            return objUsuario;
        }
        public List<Usuario> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Usuario";
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Usuario> objsUsuarios = new List<Usuario>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Id = Convert.ToInt32(dr["id"]);
                    objUsuario.Login = Convert.ToString(dr["login"]);
                    objUsuario.Nome = Convert.ToString(dr["nome"]);
                    objUsuario.Senha = Convert.ToString(dr["senha"]);
                    objUsuario.CpfCnpj = Convert.ToString(dr["cpf_cnpj"]);
                    objUsuario.Telefone = Convert.ToString(dr["telefone"]);
                    objUsuario.Email = Convert.ToString(dr["email"]);
                    objUsuario.Ativacao = Convert.ToBoolean(dr["estado"]);
                    objUsuario.Nivel = Convertt.ToNivelAcesso(dr["nivel"]);
                    objsUsuarios.Add(objUsuario);
                }

            }
            return objsUsuarios;
        }
        public List<Usuario> BuscarGeralClientes(string valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Usuario where nivel = 1";
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Usuario> objsUsuarios = new List<Usuario>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Id = Convert.ToInt32(dr["id"]);
                    objUsuario.Login = Convert.ToString(dr["login"]);
                    objUsuario.Nome = Convert.ToString(dr["nome"]);
                    objUsuario.Senha = Convert.ToString(dr["senha"]);
                    objUsuario.CpfCnpj = Convert.ToString(dr["cpf_cnpj"]);
                    objUsuario.Telefone = Convert.ToString(dr["telefone"]);
                    objUsuario.Email = Convert.ToString(dr["email"]);
                    objUsuario.Ativacao = Convert.ToBoolean(dr["ativacao"]);
                    objUsuario.Nivel = Convertt.ToNivelAcesso(dr["nivel"]);
                    objsUsuarios.Add(objUsuario);
                }

            }
            return objsUsuarios;
        }
        public List<Usuario> BuscarGeral(string valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Usuario";
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Usuario> objsUsuarios = new List<Usuario>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Id = Convert.ToInt32(dr["id"]);
                    objUsuario.Login = Convert.ToString(dr["login"]);
                    objUsuario.Nome = Convert.ToString(dr["nome"]);
                    objUsuario.Senha = Convert.ToString(dr["senha"]);
                    objUsuario.CpfCnpj = Convert.ToString(dr["cpf_cnpj"]);
                    objUsuario.Telefone = Convert.ToString(dr["telefone"]);
                    objUsuario.Email = Convert.ToString(dr["email"]);
                    objUsuario.Ativacao = Convert.ToBoolean(dr["ativacao"]);
                    objUsuario.Nivel = Convertt.ToNivelAcesso(dr["nivel"]);
                    objsUsuarios.Add(objUsuario);
                }

            }
            return objsUsuarios;
        }
        public Usuario BuscarUnidadeUsuario(Usuario obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Usuario where Usuario.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Usuario objUsuario = new Usuario();
            UnidadeDAO daoUnidade = new UnidadeDAO();

            if (dr.HasRows)
            {
                dr.Read();
                //BUSCANDO USUARIO
                objUsuario.Id = Convert.ToInt32(dr["id"]);
                objUsuario.Login = Convert.ToString(dr["login"]);
                objUsuario.Nome = Convert.ToString(dr["nome"]);
                objUsuario.Senha = Convert.ToString(dr["senha"]);
                objUsuario.CpfCnpj = Convert.ToString(dr["cpf_cnpj"]);
                objUsuario.Telefone = Convert.ToString(dr["telefone"]);
                objUsuario.Email = Convert.ToString(dr["email"]);
                objUsuario.Ativacao= Convert.ToBoolean(dr["ativacao"]);
                objUsuario.Nivel = Convertt.ToNivelAcesso(dr["nivel"]);
                //BUSCANDO AS UNIDADES DO USUARIO
                objUsuario.ObjsUnidades = daoUnidade.BuscarUnidadesUsuario(objUsuario);
            }
            return objUsuario;
        }
     
    }
}
