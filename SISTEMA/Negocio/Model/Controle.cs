using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Controle
    {
        public Controle()
        {
        }
        public Controle(List<Comando> objsComando)
        {
            this.ObjsComandos = objsComando;
        }

        List<Comando> objsComandos;
        public List<Comando> ObjsComandos
        {
            get { return objsComandos; }
            set { objsComandos = value; }
        }

        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string equipamento;
        public string Equipamento
        {
            get { return equipamento; }
            set { equipamento = value; }
        }

        string marca;
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        string modelo;
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        TipoControle tipocontrole;
        public TipoControle Tipocontrole
        {
            get { return tipocontrole; }
            set { tipocontrole = value; }
        }
        public string _Tipocontrole
        {
            get { return Convertt.ToString(tipocontrole); }
        }
    }
}
