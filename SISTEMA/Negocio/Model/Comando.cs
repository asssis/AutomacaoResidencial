using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Comando
    {
        public Comando()
        {
            objControle = new Controle();
        }

        Controle objControle;
        public Controle ObjControle
        {
            get { return objControle; }
            set { objControle = value; }
        }

        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string cmd;
        public string Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }

        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        string estilo;
        public string Estilo
        {
            get { return estilo; }
            set { estilo = value; }
        }

        string cor;
        public string Cor
        {
            get { return cor; }
            set { cor = value; }
        }

        int consumoEnergia;
        public int ConsumoEnergia
        {
            get { return consumoEnergia; }
            set { consumoEnergia = value; }
        }

        int consumoAgua;
        public int ConsumoAgua
        {
            get { return consumoAgua; }
            set { consumoAgua = value; }
        }
    }
}
