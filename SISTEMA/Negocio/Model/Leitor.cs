using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace Negocio.Model
{
    public class Leitor
    {
        public Leitor()
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

        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        int pinoSaida;
        public int PinoSaida
        {
            get { return pinoSaida; }
            set { pinoSaida = value; }
        }

        string porta;
        public string Porta
        {
            get { return porta; }
            set { porta = value; }
        }

        decimal sensibilidade;
        public decimal Sensibilidade
        {
            get { return sensibilidade; }
            set { sensibilidade = value; }
        }

        Condicao condicao;
        public Condicao Condicao
        {
            get { return condicao; }
            set { condicao = value; }
        }
        public string _Condicao
        {
            get { return Convertt.ToString(condicao); }
        }


        TipoLeitor tipoLeitor;
        public TipoLeitor TipoLeitor
        {
            get { return tipoLeitor; }
            set { tipoLeitor = value; }
        }

        Dispositivo objDispositivo;
        public Dispositivo ObjDispositivo
        {
            get { return objDispositivo; }
            set { objDispositivo = value; }
        }

        Comando objComando;
        public Comando ObjComando
        {
            get { return objComando; }
            set { objComando = value; }
        }

        decimal valor;
        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        decimal resultado;
        public decimal Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        bool primeiraLeitura;
        public bool PrimeiraLeitura
        {
            get { return primeiraLeitura; }
            set { primeiraLeitura = value; }
        }
    }
}
