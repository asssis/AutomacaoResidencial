using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Historico
    {
        public Historico()
        {
            objComando = new Comando();
            objDispositivo = new Dispositivo();
        }
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        Comando objComando;
        public Comando ObjComando
        {
            get { return objComando; }
            set { objComando = value; }
        }

        Dispositivo objDispositivo;
        public Dispositivo ObjDispositivo
        {
            get { return objDispositivo; }
            set { objDispositivo = value; }
        }

        DateTime momento;
        public DateTime Momento
        {
            get { return momento; }
            set { momento = value; }
        }

        double consumoEnergia;
        public double ConsumoEnergia
        {
            get { return consumoEnergia; }
            set { consumoEnergia = value; }
        }

        double consumoAgua;
        public double ConsumoAgua
        {
            get { return consumoAgua; }
            set { consumoAgua = value; }
        }
    }
}
