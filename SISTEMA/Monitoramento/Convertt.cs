using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitoramento.webHomeControl;
namespace Monitoramento
{
    public class Convertt
    {

        public static int ToInt(TipoLeitor valor)
        {
            switch (valor)
            {
                case TipoLeitor.OPTOACOPLADOR:
                    return 5;
                case TipoLeitor.AMPERIMETRO:
                    return 6;
                default:
                    return 0;
            }
        }

        public static string ToComando(string comando)
        {
            string con = "";
            for (int i = 0; i < comando.Count(); i++)
            {
                if (comando[i].ToString() == ",")
                    con = con + ".";
                else
                    con = con + comando[i].ToString();
            }
            return con;
        }

        public static decimal ToDecimal(string resultado)
        {
            try
            {
                return Convert.ToDecimal(resultado);
            }
            catch (Exception)
            {
                return Convert.ToDecimal(0);
            }
        }
        public static int ToInt32(Object resultado)
        {
            try
            {
                return Convert.ToInt32(resultado);
            }
            catch (Exception)
            {
                return Convert.ToInt32(0);
            }
        }

        public static string ToComando(decimal comando)
        {
            return ToComando(Convert.ToString(comando));
        }
        public static string ToValorS(string valor)
        {
            string  val = "";
            for (int i = 0; i < valor.Count(); i++)
            {

                if (valor[i].ToString() == ".")
                    val = val + ",";
                else if (valor[i] !=  '\r')
                    val = val + valor[i].ToString();
            }
            return val;
        }
        public static decimal ToValorD(string valor)
        {
            try
            {
                string val = "";
                for (int i = 0; i < valor.Count(); i++)
                {

                    if (valor[i].ToString() == ".")
                        val = val + ",";
                    else if (valor[i] != '\r')
                        val = val + valor[i].ToString();
                }
                return Convert.ToDecimal(val);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static string JoinLeitor(TipoLeitor tipo, int pino, decimal comando)
        {
            StringBuilder cmd = new  StringBuilder();
            cmd.Append(ToInt(tipo));
            cmd.Append(pino.ToString().PadLeft(2, '0'));
            cmd.Append(ToComando(comando));
            return cmd.ToString();
        }
        public static string InformarUsuario(Evento objEvento)
        {
            StringBuilder msn = new StringBuilder();

            if (objEvento.ObjComando.Estilo == "range-touch-inteiro")
                msn.Append(objEvento.Potencia);
            else
                msn.Append(objEvento.ObjComando.Nome);
            msn.Append(", ");
            msn.Append(objEvento.ObjDispositvo.Nome);
            msn.Append(", ");
            msn.Append(objEvento.ObjDispositvo.ObjDivisao.Descricao);
            return msn.ToString();
        }

        public static string InformarUsuario(Dispositivo objDispositivo, Leitor objLeitor)
        {
            StringBuilder msn = new StringBuilder();
            msn.Append(objLeitor.ObjComando.Nome);
            msn.Append(", ");
            msn.Append(objDispositivo.Nome);
            msn.Append(", ");
            msn.Append(objDispositivo.ObjDivisao.Descricao);
            return msn.ToString();
        }

        public static string ToComando(Evento objEvento)
        {
            TipoControle tipo = objEvento.ObjDispositvo.ObjControle.Tipocontrole;
            int pino = Convert.ToInt32(objEvento.ObjDispositvo.PinoEntrada);
            string cmd;
            if (objEvento.ObjComando.Estilo == "range-touch-inteiro")
                cmd = objEvento.Potencia;
            else
                cmd = objEvento.ObjComando.Cmd;

            StringBuilder comando = new StringBuilder();
            comando.Append((int)tipo);
            comando.Append(pino.ToString().PadLeft(2, '0'));
            comando.Append(ToComando(cmd));
            return comando.ToString();
        }
    }
}
