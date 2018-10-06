using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Convertt
    {

        public static int ToInt32(Object valor)
        {
            try
            {
                return System.Convert.ToInt32(valor);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static DateTime ToDateTime(object valor)
        {
            try
            {
                return Convert.ToDateTime(valor);
            }
            catch (Exception)
            {
                DateTime data = System.Convert.ToDateTime("00/00/0001");
                return data;
            }
        }
        //METODOS EXTRRAS
        public static string ToRestanteDias(DateTime valor)
        {
            TimeSpan time = DateTime.Now.Subtract(valor);
            StringBuilder timeRetorno = new StringBuilder();
            if (time.TotalDays >= 31)
                return "ANTIGO";
            else
            {
                if (time.Days > 0)
                {
                    timeRetorno.Append(time.Days);
                    timeRetorno.Append(" DIA, ");
                }
                if (time.Minutes > 0)
                {
                    timeRetorno.Append(time.Hours.ToString().PadLeft(2, '0'));
                    timeRetorno.Append(":");
                    timeRetorno.Append(time.Minutes.ToString().PadLeft(2, '0'));
                }
                else if (time.Seconds < 60)
                {
                    return "AGORA";
                }

                return timeRetorno.ToString();
            }
        }
        public static string ToString(object valor)
        {
            try
            {
                return System.Convert.ToString(valor);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static TipoControle ToTipoControle(Object valor)
        { 
            switch (ToString(valor))
            {
                case "SIMPLES":
                    return TipoControle.SIMPLES;
                case "LOGICO":
                    return TipoControle.LOGICO;
                case "GRADUAL":
                    return TipoControle.GRADUAL;
                case "ESPECIFICO":
                    return TipoControle.ESPECIFICO;
                case "1":
                    return TipoControle.SIMPLES;
                case "2":
                    return TipoControle.LOGICO;
                case "3":
                    return TipoControle.GRADUAL;
                case "4":
                    return TipoControle.ESPECIFICO;
                default:
                    return TipoControle.NULL;
            }
        }

        public static double Arredondar(double h)
        {
            if (h >= 0.0025)
                return h;
            else
                return 0.0025;
        }

        public static double ToDouble(object valor)
        {
            try
            {
                return Convert.ToDouble(valor);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static NivelAcesso ToNivelAcesso(Object valor)
        {
            switch (ToString(valor))
            {
                case "CLIENTE":
                    return NivelAcesso.CLIENTE;
                case "TECNICO":
                    return NivelAcesso.TECNICO;
                case "ADMINISTRADOR":
                    return NivelAcesso.ADMINISTRADOR;
                case "1":
                    return NivelAcesso.CLIENTE;
                case "2":
                    return NivelAcesso.TECNICO;
                case "3":
                    return NivelAcesso.ADMINISTRADOR;
                default:
                    return NivelAcesso.NULL;
            }
        }

        public static string ToString(Condicao valor)
        {
            switch (valor)
            {
                case Condicao.MENOR:
                    return "MENOR";
                case Condicao.MAIOR:
                    return "MAIOR";
                case Condicao.IGUAL:
                    return "IGUAL";
                case Condicao.DIFERENTE:
                    return "DIFERENTE";
                default:
                    return "";
            }
        }
             
        public static String ToSemanaSimples(int valor)
        {
            switch (valor)
            {
                case 1:
                    return "D";
                case 2:
                    return "S";
                case 3:
                    return "T";
                case 4:
                    return "Q";
                case 5:
                    return "Q";
                case 6:
                    return "S";
                case 7:
                    return "S";
                default:
                    return "";

            }
        }

        public static string ToString(TipoControle valor)
        {
            switch (valor)
            {
                case TipoControle.SIMPLES:
                    return "SIMPLES";
                case TipoControle.LOGICO:
                    return "LOGICO";
                case TipoControle.GRADUAL:
                    return "GRADUAL";
                case TipoControle.ESPECIFICO:
                    return "ESPECIFICO";
                default:
                    return "";
            }
        }
        public static string ToString(NivelAcesso valor)
        {
            switch (valor)
            {
                case NivelAcesso.CLIENTE:
                    return "CLIENTE";
                case NivelAcesso.TECNICO:
                    return "TECNICO";
                case NivelAcesso.ADMINISTRADOR:
                    return "ADMINISTRADOR";
                default:
                    return "";
            }

        }
        public static string ToString(TimeSpan valor)
        {
            StringBuilder hora = new StringBuilder();
            hora.Append(valor.Hours.ToString().PadLeft(2,'0'));
            hora.Append(":");
            hora.Append(valor.Minutes.ToString().PadLeft(2, '0'));
            return hora.ToString();
        }

        public static TimeSpan ToTimeSpan(string valor)
        {
            try
            {
                return TimeSpan.Parse(valor);
            }
            catch (Exception)
            {
                return TimeSpan.Parse("00:00");
            }
        }


        public static TipoLeitor ToTipoLeitor(Object valor)
        {
            switch (ToString(valor))
            {
                case "OPTOACOPLADOR":
                    return TipoLeitor.OPTOACOPLADOR;
                case "AMPERIMETRO":
                    return TipoLeitor.AMPERIMETRO;
                case "5":
                    return TipoLeitor.OPTOACOPLADOR;
                case "6":
                    return TipoLeitor.AMPERIMETRO;
                default:
                    return TipoLeitor.NULL;
            }
        }
        public static string ToString(TipoLeitor valor)
        {
            switch (valor)
            {
                case TipoLeitor.OPTOACOPLADOR:
                    return "OPTOACOPLADOR";
                case TipoLeitor.AMPERIMETRO:
                    return "AMPERIMETRO";
                default:
                    return "";
            }
        }
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
        public static Condicao ToCondicao(object valor)
        {
            switch (ToString(valor))
            {
                case "MENOR":
                    return Condicao.MENOR;
                case "MAIOR":
                    return Condicao.MAIOR;
                case "IGUAL":
                    return Condicao.IGUAL;
                case "DIFERENTE":
                    return Condicao.DIFERENTE;
                case "1":
                    return Condicao.MENOR;
                case "2":
                    return Condicao.MAIOR;
                case "3":
                    return Condicao.IGUAL;
                case "4":
                    return Condicao.DIFERENTE;
                default:
                    return Condicao.NULL;
            }
        }
        public static string ToStringAtivacao(bool valor)
        {
            if (valor)
                return "ATIVADO";
            else
                return "DESATIVADO";
        }

        public static bool ToAtivacao(string valor)
        {     
            switch (valor)
	        {
                case "ATIVADO":
                    return true;
                case "DESATIVADO":
                    return false;
                default:
                    return false;
	        }
        }

        public static string ToDiaSemana(int valor)
        {
            if (valor == 0)
                return "DOM";
            else if (valor == 1)
                return "SEG";
            else if (valor == 2)
                return "TER";
            else if (valor == 3)
                return "QUA";
            else if (valor == 4)
                return "QUI";
            else if (valor == 5)
                return "SEX";
            else if (valor == 6)
                return "SAB";
            else
                return "";
        }
        public static string ToDiaSemanaSimplificada(int valor)
        {
            if (valor == 0)
                return "D";
            else if (valor == 1)
                return "S";
            else if (valor == 2)
                return "T";
            else if (valor == 3)
                return "Q";
            else if (valor == 4)
                return "Q";
            else if (valor == 5)
                return "S";
            else if (valor == 6)
                return "S";
            else
                return "";
        }
        public static string TransformarVirgulaPonto(double val)
        {
            string con = "";
            string valor = Convert.ToString(val);
            for (int i = 0; i < valor.Count(); i++)
            {
                if (valor[i].ToString() == ",")
                    con = con + ".";
                else
                    con = con + valor[i].ToString();
            }
            return con;
        }
        public static string ToFormatCasasDecimais(double val)
        {
            string con = "";
            string valor = Convert.ToString(val);
            for (int i = 0; i < valor.Count(); i++)
            {
                if (valor[i].ToString() == "," || valor[i].ToString() ==".")
                {
                    con = con + valor[i];
                    try
                    {
                    con = con + valor[i + 1];
                    con = con + valor[i + 2];
                    con = con + valor[i + 3];
                    con = con + valor[i + 4];
                    }
                    catch (Exception)
                    {
                    }
                    i = valor.Count() + 1;
                }
                else
                    con = con + valor[i].ToString();
            }
            return con;
        }
    }
}
