using Negocio.Dao;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Bo
{
    public class EventoBO
    {
        //VARIAVEIS
        EventoDAO daoEvento;
        public ListaEventos objListaEventos;

        //METODO CONSTRUTOR
        public EventoBO()
        {
            objListaEventos = ListaEventos.Instancia;
            daoEvento = new EventoDAO();
        }

        //METODOS PRINCIPAIS MANIPULANDO MEMORIA
        public bool GravarEventoMemoria(Evento obj)
        {
            try
            {
                if (objListaEventos.ObjsEventos == null)
                    return false;
                else
                {
                    objListaEventos.ObjsEventos.Add(obj);
                    return true;
                }
            }
            catch
            {
                
                return false;
            }
        }
        public bool DeletarEventoMemoria(Evento obj)
        {
            try
            {
                objListaEventos.ObjsEventos.Remove(obj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Evento BuscarEventoMemoria(Unidade obj)
        {
            for (int i = 0; i < objListaEventos.ObjsEventos.Count; i++)
            {
                int eventoLista = objListaEventos.ObjsEventos[i].ObjDispositvo.ObjDivisao.ObjUnidade.Id;
                int evento = obj.Id;

                if (evento == eventoLista)
                {
                    return objListaEventos.ObjsEventos[i];
                }
            }
            return null;

        }
        public List<Dispositivo> BuscarEventosUsuario(Usuario obj)
        {
            List<Unidade> objsUnidade = new UnidadeBO().BuscarUnidadesUsuario(obj).ObjsUnidades;

            List<Divisao> objsDivisoes = new List<Divisao>();
            List<Dispositivo> objsDispositivos = new List<Dispositivo>();

            for (int i = 0; i < objsUnidade.Count; i++)
                objsDivisoes.AddRange(new DivisaoBO().BuscarDivisoesUnidade(objsUnidade[i]).ObjsDivisoes);

            for (int i = 0; i < objsDivisoes.Count; i++)
                objsDispositivos.AddRange(new DispositivoBO().BuscarDispositivosDivisao(objsDivisoes[i]).ObjsDispositivos);

            return objsDispositivos;
        }

        //METODOS PRINCIPAIS MANUPULANDO BASE DE DADOS
        public string GravarEventoBanco(Evento obj)
        {
            string msn = daoEvento.Gravar(obj);
            DispositivoBO boDispositivo = new DispositivoBO();
            obj.ObjDispositvo = boDispositivo.BuscarId(obj.ObjDispositvo);
            GravarEventoMemoria(obj);
            return msn;
        }
        public string AlterarEventoBanco(Evento obj)
        {
            string msn = daoEvento.Alterar(obj);
            DispositivoBO boDispositivo = new DispositivoBO();
            obj.ObjDispositvo = boDispositivo.BuscarId(obj.ObjDispositvo);
            GravarEventoMemoria(obj);
            return msn;
        }
        public string Deletar(Evento obj)
        {
            obj.ObjAgenda = null;
            obj.ObjComando = null;
            obj.ObjDispositvo = null;
            obj.Potencia = "";
            GravarEventoMemoria(obj);
            return daoEvento.Deletar(obj);
        }
        public string DeletarTodosEventosDispositivo(Dispositivo obj)
        {
            try
            {
                obj = new EventoBO().BuscarEventoDispositivo(obj);
                for (int i = 0; i < obj.ObjsEventos.Count; i++)
                    Deletar(obj.ObjsEventos[i]);
                return "Todos eventos foram deletados";
            }
            catch (Exception)
            {
                throw new Exception("Falha ao deletar os eventos");
            }
        }

        //METODOS DE BUSCAS
        public List<Evento> BuscaEventoBanco(Dispositivo obj)
        {
            return daoEvento.BuscarEventoBanco(obj);
        }
        public Evento BuscarEventoBancoId(Evento obj)
        {
            return daoEvento.BuscarId(obj);
        }
        public Evento BuscarEventoIdBotao(string valor)
        {
            string id = "";
            for (int i = 3; i < valor.Count(); i++)
            {
                id = id + valor[i].ToString();
            }
            return daoEvento.BuscarId(Convert.ToInt32(id));
        }
        public Dispositivo BuscarEventoDispositivo(Dispositivo obj)
        {
            return daoEvento.BuscarEventosDispositivo(obj);
        }

        //FAZENDO VALIDAÇÕES
        public bool ValidarMatricula(Evento obj)
        {
            if (daoEvento.BuscarId(obj) != null)
                return true;
            else
                return false;
        }
        public bool ValidarEvento(Evento obj)
        {
            if (obj.Potencia != null)
                return true;
            else if (BuscarEventoBancoId(obj) != null)
                return true;
            else
                return false;
        }
        public bool ValidarAgendamento(Evento obj)
        {
            if (obj.ObjAgenda.Domingo == true ||
                obj.ObjAgenda.Segunda == true ||
                obj.ObjAgenda.Terca == true ||
                obj.ObjAgenda.Quarta == true ||
                obj.ObjAgenda.Quinta == true ||
                obj.ObjAgenda.Sexta == true ||
                obj.ObjAgenda.Sabado == true)
                if (obj.ObjAgenda.Hora != TimeSpan.FromHours(0))
                {
                    if (obj.ObjComando != null)
                    {
                        if (obj.ObjComando.Id != 0)
                            return true;
                        else if (obj.Potencia != null)
                            return true;

                    }
                }
                return false;
        }
        public bool VerificarEventoDispositivo(Dispositivo obj)
        {
            return daoEvento.VerificarEventoDispositivo(obj);
        }
    }
}
