using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dao
{
    public class AgendaDAO
    {
        //METODOS PRINCIPAIS
        public int Gravar(Agenda obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Agenda (hora, domingo, segunda, terca, quarta, quinta, sexta, sabado) VALUES (@hora, @domingo, @segunda, @terca, @quarta, @quinta, @sexta, @sabado) Select(SCOPE_IDENTITY()) as matricula";
                comando.Parameters.AddWithValue("@hora", obj.Hora);
                comando.Parameters.AddWithValue("@domingo", obj.Domingo);
                comando.Parameters.AddWithValue("@segunda", obj.Segunda);
                comando.Parameters.AddWithValue("@terca", obj.Terca);
                comando.Parameters.AddWithValue("@quarta", obj.Quarta);
                comando.Parameters.AddWithValue("@quinta", obj.Quinta);
                comando.Parameters.AddWithValue("@sexta", obj.Sexta);
                comando.Parameters.AddWithValue("@sabado", obj.Sabado);

                SqlDataReader dr = Conexao.Selecionar(comando);
                dr.Read();
                obj.Id = Convertt.ToInt32(dr["matricula"]);
                return obj.Id;
  
        }
        public string Alterar(Agenda obj)
        {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Update Agenda set hora = @hora, domingo = @domingo, segunda = @segunda, terca = @terca, quarta = @quarta, quinta = @quinta, sexta = @sexta, sabado = @sabado from Agenda where Agenda.id = @id";
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@hora", obj.Hora);
                comando.Parameters.AddWithValue("@domingo", obj.Domingo);
                comando.Parameters.AddWithValue("@segunda", obj.Segunda);
                comando.Parameters.AddWithValue("@terca", obj.Terca);
                comando.Parameters.AddWithValue("@quarta", obj.Quarta);
                comando.Parameters.AddWithValue("@quinta", obj.Quinta);
                comando.Parameters.AddWithValue("@sexta", obj.Sexta);
                comando.Parameters.AddWithValue("@sabado", obj.Sabado);
                Conexao.CRUD(comando);
                return "Evento alterado com sucesso";
        }
        public void Deletar(Agenda obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "delete from Agenda where Agenda.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            Conexao.CRUD(comando);
        }

        //METODOS DE BUSCAS
        public Agenda BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Agenda where Agenda.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Agenda objAgenda = new Agenda();
            ControleDAO daoControle = new ControleDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objAgenda.Id = Convert.ToInt32(dr["id"]);
                objAgenda.Hora = (TimeSpan)(dr["hora"]);
                objAgenda.Domingo = Convert.ToBoolean(dr["domingo"]);
                objAgenda.Segunda = Convert.ToBoolean(dr["segunda"]);
                objAgenda.Terca = Convert.ToBoolean(dr["terca"]);
                objAgenda.Quarta = Convert.ToBoolean(dr["quarta"]);
                objAgenda.Quinta = Convert.ToBoolean(dr["quinta"]);
                objAgenda.Sexta = Convert.ToBoolean(dr["sexta"]);
                objAgenda.Sabado = Convert.ToBoolean(dr["sabado"]);
                return objAgenda;
            }
            return null;
        }
        public Agenda BuscarId(Agenda obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Agenda where Agenda.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Agenda objAgenda = new Agenda();
            ControleDAO daoControle = new ControleDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objAgenda.Id = Convert.ToInt32(dr["id"]);
                objAgenda.Hora = (TimeSpan)(dr["hora"]);
                objAgenda.Domingo = Convert.ToBoolean(dr["domingo"]);
                objAgenda.Segunda = Convert.ToBoolean(dr["segunda"]);
                objAgenda.Terca = Convert.ToBoolean(dr["terca"]);
                objAgenda.Quarta = Convert.ToBoolean(dr["quarta"]);
                objAgenda.Quinta = Convert.ToBoolean(dr["quinta"]);
                objAgenda.Sexta = Convert.ToBoolean(dr["sexta"]);
                objAgenda.Sabado = Convert.ToBoolean(dr["sabado"]);
                return objAgenda;
            }
            return null;
        }
    }
}
