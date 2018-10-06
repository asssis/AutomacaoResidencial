using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dao
{
    public class ControleDAO
    {
        //METODOS PRINCIPAIS
        public string Gravar(Controle obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Controle (marca, modelo, equipamento, controle) VALUES (@marca, @modelo, @equipamento, @controle) Select(SCOPE_IDENTITY()) as matricula";
                comando.Parameters.AddWithValue("@marca", obj.Marca);
                comando.Parameters.AddWithValue("@modelo", obj.Modelo);
                comando.Parameters.AddWithValue("@equipamento", obj.Equipamento);             
                comando.Parameters.AddWithValue("@controle",(int)obj.Tipocontrole );
                
                SqlDataReader dr = Conexao.Selecionar(comando);
                dr.Read();

                obj.Id = Convertt.ToInt32(dr["matricula"]);
                return "Controle gravado com sucesso, Nº Matricula " + obj.Id.ToString();
  
        }
        public string Alterar(Controle obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Controle set marca = @marca, modelo = @modelo, equipamento = @equipamento, controle = @controle from Controle where Controle.id = @id";
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@marca", obj.Marca);
                comando.Parameters.AddWithValue("@modelo", obj.Modelo);
                comando.Parameters.AddWithValue("@equipamento", obj.Equipamento);
                comando.Parameters.AddWithValue("@controle", (int)obj.Tipocontrole);
                Conexao.CRUD(comando);
                return "Controle alterado com sucesso";
        }
        public string Deletar(Controle obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Delete * from Controle where Controle.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            Conexao.CRUD(comando);
            return "Controle deletado com sucesso.";
        }

        //METODOS DE BUSCAS
        public Controle BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Controle where Controle.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Controle objControle = new Controle();
            if (dr.HasRows)
            {
                dr.Read();
                objControle.Id = Convert.ToInt32(dr["id"]);
                objControle.Marca = Convert.ToString(dr["marca"]);
                objControle.Modelo = Convert.ToString(dr["modelo"]);
                objControle.Equipamento = Convert.ToString(dr["equipamento"]);
                objControle.Tipocontrole = Convertt.ToTipoControle(dr["controle"]);
                return objControle;
            }
            return null;
        }
        public Controle BuscarId(Controle obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Controle where Controle.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Controle objControle = new Controle();
            if (dr.HasRows)
            {
                dr.Read();
                    objControle.Id = Convert.ToInt32(dr["id"]);
                    objControle.Marca = Convert.ToString(dr["marca"]);
                    objControle.Modelo = Convert.ToString(dr["modelo"]);
                    objControle.Equipamento = Convert.ToString(dr["equipamento"]);
                    objControle.Tipocontrole = Convertt.ToTipoControle(dr["controle"]);
                    return objControle;
            }
            return null;                  
        }
        public List<Controle> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Controle";
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Controle> objsUnidades = new List<Controle>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Controle objControle = new Controle();
                    objControle.Id = Convert.ToInt32(dr["id"]);
                    objControle.Marca = Convert.ToString(dr["marca"]);
                    objControle.Modelo = Convert.ToString(dr["modelo"]);
                    objControle.Equipamento = Convert.ToString(dr["equipamento"]);
                    objControle.Tipocontrole = Convertt.ToTipoControle(dr["controle"]);
                    objsUnidades.Add(objControle);
                }
                return objsUnidades;
            }
            return null;
        }
        public Controle BuscarModelo(Controle obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Controle where Controle.modelo = @modelo";
            comando.Parameters.AddWithValue("@modelo", obj.Modelo);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Controle objControle = new Controle();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj.Id = Convert.ToInt32(dr["id"]);
                    objControle.Marca = Convert.ToString(dr["marca"]);
                    objControle.Modelo = Convert.ToString(dr["modelo"]);
                    objControle.Equipamento = Convert.ToString(dr["equipamento"]);
                    objControle.Tipocontrole = Convertt.ToTipoControle(dr["controle"]);
                }
                return objControle;
            }
            return null;
        }
        public Controle BuscarComandosControle(Controle obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Controle where Controle.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Controle objControle = new Controle();
            ComandoDAO daoComando = new ComandoDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objControle.Id = Convert.ToInt32(dr["id"]);
                objControle.Marca = Convert.ToString(dr["marca"]);
                objControle.Modelo = Convert.ToString(dr["modelo"]);
                objControle.Equipamento = Convert.ToString(dr["equipamento"]);
                objControle.Tipocontrole = Convertt.ToTipoControle(dr["controle"]);
                objControle.ObjsComandos = daoComando.BuscarComandosControle(obj);
                return objControle;
            }
            return null;
        }
        public bool VerificarComandoControle(Controle obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Comando where Comando.id_controle = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            return dr.HasRows;
        }
        public bool VerificarDispositivoControle(Controle obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Dispositivo where Dispositivo.id_controle = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            return dr.HasRows;
        }
    }
}
