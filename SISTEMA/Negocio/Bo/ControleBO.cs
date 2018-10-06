using Negocio.Dao;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Bo
{
    public class ControleBO
    {
        //DECLARANDO VARIAVEIS
        ControleDAO daoControle;

        //METODO CONSTRUTORE
        public ControleBO()
        {
            daoControle = new ControleDAO();
        }

        //METODOS PRINCIPAIS
        public string Alterar(Controle obj)
        {
            return daoControle.Alterar(obj);
        }
        public string Gravar(Controle obj)
        {
            return daoControle.Gravar(obj);
        }
        public string Deletar(Controle obj)
        {
            return daoControle.Deletar(obj);
        }

        public Controle BuscarId(int valor)
        {
            return daoControle.BuscarId(valor);
        }
        public Controle BuscarId(Controle obj)
        {
            ControleDAO dao = new ControleDAO();
            return dao.BuscarId(obj);
        }
        public List<Controle> BuscarGeral(string valor)
        {
            ControleDAO dao = new ControleDAO();
            return dao.BuscarTodos();
        }
        public Controle BuscarComandosControle(Controle obj)
        {
            return daoControle.BuscarComandosControle(obj);
        }

        //VALIDANDO CONTROLE
        public bool ValidarModelo(Controle obj)
        {
            if (daoControle.BuscarModelo(obj) != null)
                return true;
            else
                return false;
        }
        public bool ValidarControle(Controle obj)
        {
            if (daoControle.BuscarId(obj) != null)
                return true;
            else
                return false;
        }
        public bool ValidarCamposObrigatorio(Controle obj)
        {
            if (obj.Marca != "" && obj.Modelo != "" && obj.Tipocontrole != TipoControle.NULL)
                return true;
            else
                return false;
        }
        public Comando BuscarComandoIdBotao(string valor)
        {
            string id = "";
            for (int i = 3; i < valor.Count(); i++)
            {
                id = id + valor[i].ToString();
            }
            ComandoBO boComando = new ComandoBO();
            return boComando.BuscarId(Convert.ToInt32(id));
        }
        public bool GravarEvento(Evento objEvento)
        {
            EventoBO boEvento = new EventoBO();           
            return boEvento.GravarEventoMemoria(objEvento);
        }

        public string ToComandoHistorico(string p)
        {
            string texto = "";
            for (int i = 0; i < p.Count(); i++)
            {
                if (p[i] != '%')
                texto = texto + p[i].ToString();
            }
            return texto;
        }

        public bool VerificarComandoControle(Controle obj)
        {
            return daoControle.VerificarComandoControle(obj);
        }

        public bool VerificarDispositivoControle(Controle obj)
        {
            return daoControle.VerificarDispositivoControle(obj);
        }
    }
}
