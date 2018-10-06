using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Evento
    {
        public Evento()
        {
            objComando = new Comando();
            objDispositvo = new Dispositivo();
            objAgenda = new Agenda();
        }
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        Comando objComando;
        public Comando ObjComando
        {
            get { return objComando; }
            set { objComando = value; }
        }

        Dispositivo objDispositvo;
        public Dispositivo ObjDispositvo
        {
            get { return objDispositvo; }
            set { objDispositvo = value; }
        }

        Agenda objAgenda;
        public Agenda ObjAgenda
        {
            get { return objAgenda; }
            set { objAgenda = value; }
        }

        string potencia;
        public string Potencia
        {
            get { return potencia; }
            set { potencia = value; }
        }

        string retorno;
        public string Retorno
        {
            get
            {
                return retorno;
            }

            set
            {
                retorno = value;
            }
        }

    }
}
