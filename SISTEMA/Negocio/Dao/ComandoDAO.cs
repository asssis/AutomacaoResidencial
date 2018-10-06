using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dao
{
    public class ComandoDAO
    {
        //METODOS PRINCIPAIS
        public string Gravar(Comando obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Comando (cmd, nome, estilo, cor, id_controle, consumoenergia, consumoagua) VALUES (@cmd, @nome, @estilo, @cor, @id_controle, @consumoenergia, @consumoagua) Select(SCOPE_IDENTITY()) as matricula";
                comando.Parameters.AddWithValue("@cmd", obj.Cmd);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@estilo", obj.Estilo);
                comando.Parameters.AddWithValue("@cor", obj.Cor);
                comando.Parameters.AddWithValue("@id_controle", obj.ObjControle.Id);
                comando.Parameters.AddWithValue("@consumoenergia", obj.ConsumoEnergia);
                comando.Parameters.AddWithValue("@consumoagua", obj.ConsumoAgua);

                SqlDataReader dr = Conexao.Selecionar(comando);
                dr.Read();

                obj.Id = Convertt.ToInt32(dr["matricula"]);
                return "Comando gravado com sucesso, Nº Matricula " + obj.Id;
        }
        public string Alterar(Comando obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Comando set cmd = @cmd, nome = @nome, estilo = @estilo, cor = @cor, id_controle = @id_controle, consumoenergia = @consumoenergia, consumoagua = @consumoagua from Comando where Comando.id = @id";

                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@cmd", obj.Cmd);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@estilo", obj.Estilo);
                comando.Parameters.AddWithValue("@cor", obj.Cor);
                comando.Parameters.AddWithValue("@id_controle", obj.ObjControle.Id);
                comando.Parameters.AddWithValue("@consumoenergia", obj.ConsumoEnergia);
                comando.Parameters.AddWithValue("@consumoagua", obj.ConsumoAgua);
                Conexao.CRUD(comando);          
                return "Comando alterado com sucesso.";
        }
        public string Deletar(Comando obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "delete from Comando where Comando.id = @id";
                comando.Parameters.AddWithValue("@id", obj.Id);
                Conexao.CRUD(comando);
                return "Comando deletado com suceso.";
        }

        //METODOS DE BUSCAS
        public Comando BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Comando where Comando.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Comando objComando = new Comando();
            ControleDAO daoControle = new ControleDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objComando.Id = Convert.ToInt32(dr["id"]);
                objComando.Nome = Convert.ToString(dr["nome"]);
                objComando.Cmd = Convert.ToString(dr["cmd"]);
                objComando.Estilo = Convert.ToString(dr["estilo"]);
                objComando.Cor = Convert.ToString(dr["cor"]);
                objComando.ConsumoEnergia = Convertt.ToInt32(dr["consumoenergia"]);
                objComando.ConsumoAgua = Convertt.ToInt32(dr["consumoagua"]);
                //BUSCANDO CONTROLE
                objComando.ObjControle = daoControle.BuscarId(Convertt.ToInt32(dr["id_controle"]));
                return objComando;
            }
            return null;
        }
        public Comando BuscarId(Comando obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Comando where Comando.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Comando objComando = new Comando();
            ControleDAO daoControle = new ControleDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objComando.Id = Convert.ToInt32(dr["id"]);
                objComando.Nome = Convert.ToString(dr["nome"]);
                objComando.Cmd = Convert.ToString(dr["cmd"]);
                objComando.Estilo = Convert.ToString(dr["estilo"]);
                objComando.Cor = Convert.ToString(dr["cor"]);
                objComando.ConsumoEnergia = Convertt.ToInt32(dr["consumoenergia"]);
                objComando.ConsumoAgua = Convertt.ToInt32(dr["consumoagua"]);

                //BUSCANDO CONTROLE
                objComando.ObjControle.Id = Convert.ToInt32(dr["id_controle"]);
                objComando.ObjControle = daoControle.BuscarId(objComando.ObjControle);
                return objComando;
            }
            return null;
        }        
        public List<Comando> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Comando";
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Comando> objsComandos = new List<Comando>();
            ControleDAO daoControle = new ControleDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Comando objComando = new Comando();
                    objComando.Id = Convert.ToInt32(dr["id"]);
                    objComando.Nome = Convert.ToString(dr["nome"]);
                    objComando.Cmd = Convert.ToString(dr["cmd"]);
                    objComando.Estilo = Convert.ToString(dr["estilo"]);
                    objComando.Cor = Convert.ToString(dr["cor"]);
                    objComando.ConsumoEnergia = Convertt.ToInt32(dr["consumoenergia"]);
                    objComando.ConsumoAgua = Convertt.ToInt32(dr["consumoagua"]);

                    //BUSCANDO CONTROLE
                    objComando.ObjControle.Id = Convert.ToInt32(dr["id_controle"]);
                    objComando.ObjControle = daoControle.BuscarId(objComando.ObjControle);
                    objsComandos.Add(objComando);
                }
                return objsComandos;
            }
            return null;
        }        
        public List<Comando> BuscarComandosControle(Controle obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Comando where Comando.id_controle = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Comando> objsComandos = new List<Comando>();
            ControleDAO daoControle = new ControleDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Comando objComando = new Comando();
                    objComando.Id = Convert.ToInt32(dr["id"]);
                    objComando.Nome = Convert.ToString(dr["nome"]);
                    objComando.Cmd = Convert.ToString(dr["cmd"]);
                    objComando.Estilo = Convert.ToString(dr["estilo"]);
                    objComando.Cor = Convert.ToString(dr["cor"]);
                    objComando.ConsumoEnergia = Convertt.ToInt32(dr["consumoenergia"]);
                    objComando.ConsumoAgua = Convertt.ToInt32(dr["consumoagua"]);

                    //BUSCANDO CONTROLE
                    objComando.ObjControle = daoControle.BuscarId((int)dr["id_controle"]);
                    objsComandos.Add(objComando);
                }
                return objsComandos;
            }
            return null;
        }
        public bool VerificarHistoricoComando(Comando obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from historico where historico.id_comando = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            return dr.HasRows;
        }

        public bool VerificarEventoComando(Comando obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from evento where evento.id_comando = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            return dr.HasRows;
        }

        public bool VerificarLeitorComando(Comando obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from leitor where leitor.id_comando = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            return dr.HasRows;
        }

    }
}
