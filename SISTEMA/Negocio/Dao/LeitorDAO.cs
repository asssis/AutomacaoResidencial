using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dao
{
    public class LeitorDAO
    {

        //METODOS PRINCIPAIS
        public string Gravar(Leitor obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO Leitor (nome, condicao, valor, sensibilidade, id_dispositivo, id_comando, tipo, pinosaida, porta) VALUES (@nome, @condicao, @valor, @sensibilidade, @id_dispositivo, @id_comando, @tipo, @pinosaida, @porta) Select(SCOPE_IDENTITY()) as matricula";
            comando.Parameters.AddWithValue("@nome", obj.Nome);
            comando.Parameters.AddWithValue("@condicao", (int)obj.Condicao);
            comando.Parameters.AddWithValue("@tipo", (int)obj.TipoLeitor);
            comando.Parameters.AddWithValue("@pinosaida", obj.PinoSaida);
            comando.Parameters.AddWithValue("@porta", obj.Porta);
            comando.Parameters.AddWithValue("@valor", obj.Valor);
            comando.Parameters.AddWithValue("@sensibilidade", obj.Sensibilidade);
            comando.Parameters.AddWithValue("@id_dispositivo", obj.ObjDispositivo.Id);
            comando.Parameters.AddWithValue("@id_comando", obj.ObjComando.Id);

            SqlDataReader dr = Conexao.Selecionar(comando);
            dr.Read();

            obj.Id = Convertt.ToInt32(dr["matricula"]);
            return "Leitor gravado com sucesso, Nº Matricula " + obj.Id.ToString();

        }
        public string Alterar(Leitor obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "UPDATE Leitor set nome = @nome, condicao = @condicao, valor = @valor, sensibilidade = @sensibilidade, id_dispositivo = @id_dispositivo, id_comando = @id_comando, tipo = @tipo, pinosaida = @pinosaida, porta = @porta from Leitor where Leitor.id = @id";

            comando.Parameters.AddWithValue("@id", obj.Id);
            comando.Parameters.AddWithValue("@nome", obj.Nome);
            comando.Parameters.AddWithValue("@condicao", obj.Condicao);
            comando.Parameters.AddWithValue("@valor", obj.Valor);
            comando.Parameters.AddWithValue("@pinosaida", obj.PinoSaida);
            comando.Parameters.AddWithValue("@porta", obj.Porta);
            comando.Parameters.AddWithValue("@sensibilidade", obj.Sensibilidade);
            comando.Parameters.AddWithValue("@id_dispositivo", obj.ObjDispositivo.Id);
            comando.Parameters.AddWithValue("@id_comando", obj.ObjComando.Id);
            comando.Parameters.AddWithValue("@tipo", (int)obj.TipoLeitor);
            Conexao.CRUD(comando);
            return "Leitor alterada com sucesso";
        }


        public string Deletar(Leitor obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Delete from Leitor where Leitor.id = @id";

            comando.Parameters.AddWithValue("@id", obj.Id);

            Conexao.CRUD(comando);
            return "Leitor deletado com sucesso";
        }

        //METODOS DE BUSCAS
        public Leitor BuscarId(int valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Leitor where Leitor.id = @id";
            comando.Parameters.AddWithValue("@id", valor);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Leitor objLeitor = new Leitor();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            ComandoDAO daoComando = new ComandoDAO();
            if (dr.HasRows)
            {
                 dr.Read();
                    objLeitor.Id = Convert.ToInt32(dr["id"]);
                    objLeitor.Nome = Convert.ToString(dr["nome"]);
                    //BUSCANDO UNIDADE
                    objLeitor.Sensibilidade = Convert.ToDecimal(dr["sensibilidade"]);
                    objLeitor.Valor = Convert.ToDecimal(dr["valor"]);
                    objLeitor.TipoLeitor = Convertt.ToTipoLeitor(dr["tipo"]);
                    objLeitor.Condicao = Convertt.ToCondicao(dr["condicao"]);
                    objLeitor.ObjDispositivo = daoDispositivo.BuscarId((int)dr["id_dispositivo"]);
                    objLeitor.ObjComando = daoComando.BuscarId((int)dr["id_comando"]);
                    objLeitor.PinoSaida = Convertt.ToInt32(dr["pinosaida"]);
                    objLeitor.Porta = Convert.ToString(dr["porta"]);

                return objLeitor;
            }
            return null;
        }
        public Leitor BuscarId(Leitor obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Leitor where Leitor.id = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            Leitor objLeitor = new Leitor();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            ComandoDAO daoComando = new ComandoDAO();
            if (dr.HasRows)
            {
               dr.Read();
                    objLeitor.Id = Convert.ToInt32(dr["id"]);
                    objLeitor.Nome = Convert.ToString(dr["nome"]);
                    //BUSCANDO UNIDADE
                    objLeitor.Sensibilidade = Convert.ToDecimal(dr["sensibilidade"]);
                    objLeitor.Valor = Convert.ToDecimal(dr["valor"]);
                    objLeitor.TipoLeitor = Convertt.ToTipoLeitor(dr["tipo"]);
                    objLeitor.Condicao = Convertt.ToCondicao(dr["condicao"]);
                    objLeitor.ObjDispositivo = daoDispositivo.BuscarId((int)dr["id_dispositivo"]);
                    objLeitor.ObjComando = daoComando.BuscarId((int)dr["id_comando"]);
                    objLeitor.PinoSaida = Convertt.ToInt32(dr["pinosaida"]);
                    objLeitor.Porta = Convert.ToString(dr["porta"]);

                return objLeitor;
            }
            return null;
        }

        public bool VerificarLeitorDispositivo(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Leitor where Leitor.id_dispositivo = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            return dr.HasRows;
        }
        public List<Leitor> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Leitor";
            SqlDataReader dr = Conexao.Selecionar(comando);
            List<Leitor> objsLeitores = new List<Leitor>();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            ComandoDAO daoComando = new ComandoDAO();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Leitor objLeitor = new Leitor();
                    objLeitor.Id = Convert.ToInt32(dr["id"]);
                    objLeitor.Nome = Convert.ToString(dr["nome"]);
                    //BUSCANDO UNIDADE
                    objLeitor.Sensibilidade = Convert.ToDecimal(dr["sensibilidade"]);
                    objLeitor.Valor = Convert.ToDecimal(dr["valor"]);
                    objLeitor.TipoLeitor = Convertt.ToTipoLeitor(dr["tipo"]);
                    objLeitor.Condicao = Convertt.ToCondicao(dr["condicao"]);
                    objLeitor.ObjDispositivo = daoDispositivo.BuscarId((int)dr["id_dispositivo"]);
                    objLeitor.ObjComando = daoComando.BuscarId((int)dr["id_comando"]);
                    objLeitor.PinoSaida = Convertt.ToInt32(dr["pinosaida"]);
                    objLeitor.Porta = Convert.ToString(dr["porta"]);
                    objsLeitores.Add(objLeitor);
                }
                return objsLeitores;
            }
            return null;
        }

        public List<Leitor> BuscarLeitoresDispositivo(Dispositivo obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from Leitor where Leitor.id_dispositivo = @id";
            comando.Parameters.AddWithValue("@id", obj.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            ComandoDAO daoComando = new ComandoDAO();
            DispositivoDAO daoDispositivo = new DispositivoDAO();
            List<Leitor> objs = new List<Leitor>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Leitor objLeitor = new Leitor();

                    objLeitor.Id = Convert.ToInt32(dr["id"]);
                    objLeitor.Nome = Convert.ToString(dr["nome"]);
                    objLeitor.Sensibilidade = Convert.ToDecimal(dr["sensibilidade"]);
                    objLeitor.Valor = Convert.ToDecimal(dr["valor"]);
                    objLeitor.TipoLeitor = Convertt.ToTipoLeitor(dr["tipo"]);
                    objLeitor.Condicao = Convertt.ToCondicao(dr["condicao"]);
                    objLeitor.ObjDispositivo.Id = Convertt.ToInt32(dr["id_dispositivo"]);
                    objLeitor.ObjComando = daoComando.BuscarId((int)dr["id_comando"]);
                    objLeitor.PinoSaida = Convertt.ToInt32(dr["pinosaida"]);
                    objLeitor.Porta = Convert.ToString(dr["porta"]);

                    objs.Add(objLeitor);
                }
                return objs;
            }
            return null;
        }
    }
}
