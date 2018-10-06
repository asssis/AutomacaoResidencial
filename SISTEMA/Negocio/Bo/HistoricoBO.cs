using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using Negocio.Model;
using Negocio.Bo;
using Negocio.Dao;
using System.Text;

namespace Negocio.Bo
{
    public class HistoricoBO
    {
             //VARIAVEIS
        HistoricoDAO daoHistorico;
        int indiceGrafico = 100;

        //METODO CONSTRUTOR
        public HistoricoBO()
        {
            daoHistorico = new HistoricoDAO();
        }

        //METODOS PRINCIPAIS
        public bool Gravar(Historico objHistorico)
        {
            return daoHistorico.Gravar(objHistorico);
        }
        public Historico BuscarId(Historico objHistorico)
        {
            return daoHistorico.BuscarId(objHistorico);
        }
        public List<Historico> BuscarHistoricoDispositivo(Dispositivo obj)
        {
            return daoHistorico.BuscarHistoricoDispositivo(obj);
        }

        public List<Historico> BuscarHistorico(Dispositivo obj, DateTime valor)
        {
            DateTime primeiroDiaSemana = valor;
            DateTime ultimoDiaSemana = valor;
            int semana = Convert.ToInt32(valor.DayOfWeek);
            while (semana > 0)
            {
                primeiroDiaSemana = primeiroDiaSemana.AddDays(-1);
                semana = Convert.ToInt32(primeiroDiaSemana.DayOfWeek);
            }
            while (semana < 6)
            {
                ultimoDiaSemana = ultimoDiaSemana.AddDays(1);
                semana = Convert.ToInt32(ultimoDiaSemana.DayOfWeek);
            }
            primeiroDiaSemana = Convert.ToDateTime(primeiroDiaSemana.ToString("dd-MM-yyyy"));
            ultimoDiaSemana = Convert.ToDateTime(ultimoDiaSemana.ToString("dd-MM-yyyy"));
           return daoHistorico.BuscarHistoricoDispositivo(obj, primeiroDiaSemana, ultimoDiaSemana);
        }
        public string[,] ConstruirGraficoEnergiaDispositivo(Dispositivo obj, DateTime valor)
        {
            List<Historico> objs = BuscarHistorico(obj, valor);
            double[] horasLigado = new double[7];
            if (objs == null)
                return MontarGraficoNull(BuscarPrimeiroDia(valor), "KWH");
            else
            for (int i = 1; i < objs.Count(); i++)
            {
                int semana = Convert.ToInt32(objs[i-1].Momento.DayOfWeek);
                TimeSpan hora = objs[i].Momento.Subtract(objs[i - 1].Momento);
                double consumo;
                    //if (objs[i - 1].ObjComando.ConsumoEnergia != 0 && objs[i].ObjComando.ConsumoEnergia == 0)
                    if (objs[i - 1].ConsumoEnergia > objs[i].ConsumoEnergia)
                    {
                    double h = Convert.ToDouble(hora.TotalHours);
                 
                    double c = Convert.ToDouble(objs[i - 1].ConsumoEnergia);
                    consumo = (c * Convertt.Arredondar(h)) / 1000;
                }
                else
                    consumo = 0;
                horasLigado[semana] = horasLigado[semana] + consumo;
            }
            
            return MontarGrafico(horasLigado,BuscarPrimeiroDia(valor), "KWH");
                            
        }
        public string[,] ConstruirGraficoAguaDispositivo(Dispositivo obj, DateTime valor)
        {
            List<Historico> objs = BuscarHistorico(obj, valor);
            double[] horasLigado = new double[7];
            if (objs == null)
                return MontarGraficoNull(BuscarPrimeiroDia(valor),"L");
            else
                for (int i = 1; i < objs.Count(); i++)
                {
                    int semana = Convert.ToInt32(objs[i - 1].Momento.DayOfWeek);
                    TimeSpan hora = objs[i].Momento.Subtract(objs[i - 1].Momento);
                    double consumo;
                    if (objs[i - 1].ConsumoAgua > objs[i].ObjComando.ConsumoAgua)
                    {
                        double h = Convert.ToDouble(hora.TotalHours);

                        double c = Convert.ToDouble(objs[i - 1].ConsumoAgua);
                        consumo = c * h / 1000;
                    }
                    else
                        consumo = 0;
                    horasLigado[semana] = horasLigado[semana] + consumo;
                }

            return MontarGrafico(horasLigado,BuscarPrimeiroDia(valor), "L");

        }
    
        //METODOS EXTRAS
        public DateTime BuscarPrimeiroDia(DateTime primeiroDiaSemana)
        {
            int semana = Convert.ToInt32(Convertt.ToDateTime(primeiroDiaSemana).DayOfWeek);
            while (semana > 0)
            {
                primeiroDiaSemana = primeiroDiaSemana.AddDays(-1);
                semana = Convert.ToInt32(primeiroDiaSemana.DayOfWeek);
            }
            return primeiroDiaSemana;
        }
        public string[,] MontarGraficoNull(DateTime dataInicial, string unidade)
        {
            string[,] colunas = new string[3, 8];
            for (int i = 0; i < 7; i++)
            {
                
                StringBuilder dia = new StringBuilder();
                dia.Append(Convertt.ToDiaSemana(i));
                dia.Append(" ");
                dia.Append(dataInicial.AddDays(i).ToString("dd"));
                
                //0 nome
                //1 valor
                //2 tamanho
                colunas[0, i] = dia.ToString();
                colunas[1, i] = "0,00" + unidade;
                colunas[2, i] = "calc(0% - 160px)";
            }
            return colunas;
        }
        public string[,]MontarGrafico(double[] dados, DateTime dataInicial, string unidade)
        {
            double index = BuscarMaiorValor(dados);
            string[,] colunas = new string[4, 8];
            for (int i = 0; i < dados.Count(); i++)
            { 
                //0 nome
                //1 valor
                //2 tamanho
                //3 valor integral
              
                StringBuilder dia = new StringBuilder();
                dia.Append(Convertt.ToDiaSemana(i));
                dia.Append(" ");
                dia.Append(dataInicial.AddDays(i).ToString("dd"));
                colunas[0, i] = dia.ToString();

                colunas[1, i] = Convertt.ToFormatCasasDecimais(dados[i]) + unidade;

                double valor = (dados[i] * indiceGrafico) / index;
                colunas[2, i] = "calc(" + Convertt.TransformarVirgulaPonto(valor) + "%  - 160px)";

                colunas[3, i] = Convertt.ToFormatCasasDecimais(dados[i]);
            }
            return colunas; 
        }

        public bool VerificarHistoricoDispositivo(Dispositivo obj)
        {
            return daoHistorico.VerificarHistoricoDispositivo(obj);
        }

        public double BuscarMaiorValor(double[] valores)
        {
            double valor = 0;
            for (int i = 0; i < valores.Count(); i++)
                if (valor < valores[i])
                    valor = valores[i];
            if (valor == 0)
                return 100;
            else
                return valor;
        }
        public string ConvertData(DateTime valor)
        {
            if (DateTime.Now.Day == valor.Day && DateTime.Now.Month == valor.Month && DateTime.Now.Year == valor.Year)
            {
                return "HOJE";
            }
            if ((DateTime.Now.Day - 1) == valor.Day && DateTime.Now.Month == valor.Month && DateTime.Now.Year == valor.Year)
            {
                return "OTEM";
            }

            return valor.ToString("dd/MM/yyyy");
        }
        public double CalcularTotal(string[,] dados)
        {
            double valor = 0;
            for (int i = 0; i < 7; i++)
                valor = valor + Convertt.ToDouble(dados[3, i]);
            return valor;
        }

        public Historico BuscarUltimoHistoricoDispositivo(Dispositivo obj)
        {
            return daoHistorico.BuscarUltimoHistoricoDispositivo(obj);
        }
    }
}
