using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Conexao
    {
        public static SqlConnection Conectar()
        {
            try
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["ConectarHomeControl"].ConnectionString;
                SqlConnection conexao = new SqlConnection(stringConexao);
                conexao.Open();
              
                return conexao;
            }
            catch (Exception msn)
            {
                throw new Exception ("Falha ao conectar com o banco de dados");
            }
        }
        public static void CRUD(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            comando.ExecuteNonQuery();
            con.Close();
        }
        public static SqlDataReader Selecionar(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
            SqlConnection.ClearPool(con);
            return dr;
        }
    }
}
