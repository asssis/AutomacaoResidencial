using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Agenda
    {
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        TimeSpan hora;
        public TimeSpan Hora
        {
            get { return hora; }
            set { hora = value; horaToString = Convertt.ToString(hora); }
        }
        string horaToString;
        public string HoraToString
        {
            get { return horaToString; }
            set { horaToString = value; }
        }

        bool domingo;
        public bool Domingo
        {
            get { return domingo; }
            set { domingo = value; }
        }

        bool segunda;
        public bool Segunda
        {
            get { return segunda; }
            set { segunda = value; }
        }

        bool terca;
        public bool Terca
        {
            get { return terca; }
            set { terca = value; }
        }

        bool quarta;
        public bool Quarta
        {
            get { return quarta; }
            set { quarta = value; }
        }

        bool quinta;
        public bool Quinta
        {
            get { return quinta; }
            set { quinta = value; }
        }

        bool sexta;
        public bool Sexta
        {
            get { return sexta; }
            set { sexta = value; }
        }

        bool sabado;
        public bool Sabado
        {
            get { return sabado; }
            set { sabado = value; }
        }
    }
}
