using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Negocio;
using System.Web.UI;

namespace HomeControl.WebService
{
    /// <summary>
    /// Summary description for webHomeControl
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(true)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class webHomeControl : System.Web.Services.WebService
    {
        [WebMethod]
        public Negocio.Model.Unidade LogarUnidade(Negocio.Model.Usuario objUsuario, Negocio.Model.Unidade objUnidade)
        {
            Negocio.Bo.UsuarioBO boEvento = new Negocio.Bo.UsuarioBO();
            return boEvento.LogarUnidade(objUsuario, objUnidade);
        }

        [WebMethod]
        public Negocio.Model.Evento BuscarEvento(Negocio.Model.Unidade obj)
        {
            try
            {
                Negocio.Bo.EventoBO boEvento = new Negocio.Bo.EventoBO();
                Negocio.Model.Evento objEvento = boEvento.BuscarEventoMemoria(obj);
                boEvento.DeletarEventoMemoria(objEvento);
                if (objEvento == null)
                {
                    Negocio.Model.Evento retorno = new Negocio.Model.Evento();
                    retorno.Retorno = "null";
                    return retorno;
                }
                objEvento.Retorno = "cheio";
                return objEvento;
               }
            catch (Exception msn)
            {
                try
                {
                    ListaEventos objLista = ListaEventos.Instancia;
                    Negocio.Model.Erros objErro = new Negocio.Model.Erros();
                    objErro.Id = objLista.ObjsErros.Count() + 1;
                    objErro.Texto = msn.Message;
                    objErro.Momento = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    objLista.ObjsErros.Add(objErro);
                    List<Negocio.Model.Erros> objsErros = objLista.ObjsErros;
                    Negocio.ListaEventos.Instancia.ObjsEventos = new List<Negocio.Model.Evento>();
                    objLista.ObjsErros = objsErros;
                }
                catch 
                {
                }

                Negocio.Model.Evento retorno = new Negocio.Model.Evento();
                retorno.Retorno = msn.Message;
                return retorno;
            }
        }

        [WebMethod]
        public List<Negocio.Model.Evento> BuscarEventoBanco(Negocio.Model.Unidade obj)
        {
            try
            {
                Negocio.Bo.UnidadeBO boUnidade = new Negocio.Bo.UnidadeBO();
                return boUnidade.BuscarEventosUnidade(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }


        [WebMethod]
        public List<Negocio.Model.Dispositivo> BuscarLeitoresUnidade(Negocio.Model.Unidade obj)
        {
            Negocio.Bo.UnidadeBO bo = new Negocio.Bo.UnidadeBO();
            return bo.BuscarLeitoresUnidade(obj);
        }

        [WebMethod]
        public bool GravarEvento(Negocio.Model.Evento obj)
        {
            Negocio.Bo.EventoBO boEvento = new Negocio.Bo.EventoBO();
            return boEvento.GravarEventoMemoria(obj);
        }

        [WebMethod]
        public bool GravarHistorico(Negocio.Model.Historico obj)
        {
            Negocio.Bo.HistoricoBO boHistorico = new Negocio.Bo.HistoricoBO();
            return boHistorico.Gravar(obj);
        }
    }
}
