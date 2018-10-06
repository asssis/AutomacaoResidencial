using Negocio.Dao;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Bo
{
    public class ComandoBO
    {
        //DECLARANDO VARIAVEIS
        ComandoDAO daoComando;

        //METODO CONSTRUTOR
        public ComandoBO()
        {
            daoComando = new ComandoDAO();
        }

        //METODOS PRINCIPAIS
        public string Gravar(Comando obj)
        {
            return daoComando.Gravar(obj);
        }
        public string Alterar(Comando obj)
        {
            return daoComando.Alterar(obj);
        }
        public string Deletar(Comando obj)
        {
            return daoComando.Deletar(obj);
        }

        //METODOS DE BUSCAS
        public Comando BuscarId(int valor)
        {
            return daoComando.BuscarId(valor);
        }
        public Comando BuscarId(Comando obj)
        {
            return daoComando.BuscarId(obj);
        }
        public List<Comando> BuscarTodos()
        {
            return daoComando.BuscarTodos();
        }
        public List<Comando> BuscarComandoControle(Controle obj)
        {
            return daoComando.BuscarComandosControle(obj);
        }
       
        //METODOS EXTRAS
        public Comando BuscarComandoIdBotao(string valor)
        {
            string id = "";
            for (int i = 3; i < valor.Count(); i++)
            {
                id = id + valor[i].ToString();
            }
            return BuscarId(Convert.ToInt32(id));
        }
        public bool ValidarCamposObrigatorio(Comando obj)
        {
            if (obj.ObjControle != null && obj.Estilo != "")
                return true;
            else
                return false;
        }
        public bool ValidarComando(Comando obj)
        {
            if (daoComando.BuscarId(obj) != null)
                return true;
            else
                return false;
        }

        public bool VerificarHistoricoComando(Comando obj)
        {
            return daoComando.VerificarHistoricoComando(obj);
        }

        public bool VerificarEventoComando(Comando obj)
        {
            return daoComando.VerificarEventoComando(obj);
        }

        public bool VerificarLeitorComando(Comando obj)
        {
            return daoComando.VerificarLeitorComando(obj);
        }
    }
}
