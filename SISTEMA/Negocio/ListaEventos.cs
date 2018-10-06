using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;

namespace Negocio
{
    public class ListaEventos
    {
        private ListaEventos()
        {
            objsEventos = new List<Evento>();
            ObjsErros = new List<Erros>();
        }
        private static ListaEventos instancia;
        public static ListaEventos Instancia
        {
            
            get {
                if (instancia == null)
                    instancia = new ListaEventos();
                return instancia;
            }
        }

        List<Evento> objsEventos;
        public List<Evento> ObjsEventos
        {
            get { return objsEventos; }
            set { objsEventos = value; }
        }


        List<Erros> objsErros;
        public List<Erros> ObjsErros
        {
            get
            {
                return objsErros;
            }

            set
            {
                objsErros = value;
            }
        }

    }
}
