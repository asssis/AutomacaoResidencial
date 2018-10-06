using Monitoramento.webHomeControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoramento.Negocio
{
    public class Sensores
    {
        public string Amperimetro(Dispositivo objDispositivo, Leitor objLeitor)
        {
            Servico boServico = new Servico();
            string msn = "";
            Conexao con = new Conexao(objLeitor.Porta);
            string resultado = con.Leitura(Convertt.JoinLeitor(objLeitor.TipoLeitor, objLeitor.PinoSaida, objLeitor.Sensibilidade));
            if (resultado != "" && resultado != " INF")
            {
                bool ultima_condicao = CalcularOperador(objLeitor.Valor, objLeitor.Valor, objLeitor.Condicao);
                bool nova_condicao = CalcularOperador(Convertt.ToValorD(resultado), objLeitor.Valor, objLeitor.Condicao);
                decimal res = Convertt.ToDecimal(resultado);
                decimal res_maior = res + (res * 0.3m);
                decimal res_menor = res - (res * 0.3m);
                if (nova_condicao != ultima_condicao)
                    if (objLeitor.Resultado > res_maior || res_menor > objLeitor.Resultado)
                        if (objLeitor.PrimeiraLeitura)
                        {
                            Evento obj = new Evento();
                            obj.ObjComando = objLeitor.ObjComando;
                            if (objLeitor.Nome != "")
                                obj.ObjComando.Nome = objLeitor.Nome;
                            obj.ObjDispositvo = objDispositivo;
                            obj.ObjComando.ConsumoEnergia = Convertt.ToInt32(Convertt.ToDecimal(resultado) * Convert.ToDecimal(frmMonitorar.tensao));
                            boServico.GravarHistorico(obj);
                            msn = Convertt.InformarUsuario(objDispositivo, objLeitor);
                        }
                        else
                            objLeitor.PrimeiraLeitura = true;
                objLeitor.Resultado = Convertt.ToValorD(resultado);
                return msn;
            }
            return "";
        }

        public bool CalcularOperador(decimal resultado, decimal valor, Condicao cond)
        {
            if (resultado == valor && cond == Condicao.IGUAL)
                return true;
            else if (resultado > valor && cond == Condicao.MAIOR)
                return true;
            else if (resultado < valor && cond == Condicao.MENOR)
                return true;
            else if (resultado != valor && cond == Condicao.DIFERENTE)
                return true;
            else
                return false;
        }
       
        
    }
}
