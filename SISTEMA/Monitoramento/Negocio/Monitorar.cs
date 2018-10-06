using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitoramento.webHomeControl;

namespace Monitoramento.Negocio
{
    public class Monitorar
    {
        public List<string> LeituraDispositivo(Dispositivo obj)
        {
            List<string> objsResultado = new List<string>();
            for (int i = 0; i < obj.ObjsLeitores.Count(); i++)
            {
            Leitor objLeitor = obj.ObjsLeitores[i];
                Sensores boSensores = new Sensores();
                if (objLeitor.TipoLeitor == TipoLeitor.AMPERIMETRO)
                {
                  string msn =  boSensores.Amperimetro(obj, obj.ObjsLeitores[i]);
                  if (msn != "")
                      objsResultado.Add(msn);
                }
            }
            
            return objsResultado;
        }
        public string VerificarEvento(Unidade objUnidade)
        {
            webHomeControlSoapClient webService = new webHomeControlSoapClient();
            Evento objEvento = webService.BuscarEvento(objUnidade);
            if (objEvento == null)
                return "Falha na counicação com serviço";
            else if (objEvento != null)
                if (objEvento.Retorno != "null" && objEvento.Retorno != "cheio")
                {
                    return objEvento.Retorno;
                }
                else if (objEvento.Retorno == "cheio")
                {
                    if (objEvento.ObjAgenda == null)
                    {
                        return EfetuarEvento(objEvento);
                    }
                    else
                    {
                        GravarEvento(objEvento);
                    }
                }
            return "";
        }
        public void GravarEvento(Evento objEvento)
        {
            for (int i = 0; i < frmMonitorar.objsEventos.Count(); i++)
                if (frmMonitorar.objsEventos[i].Id == objEvento.Id)
                    frmMonitorar.objsEventos.Remove(frmMonitorar.objsEventos[i]);
            frmMonitorar.objsEventos.Add(objEvento);
        }
        public static string EfetuarEvento(Evento objEvento)
        {
            Conexao con = new Conexao(objEvento.ObjDispositvo.Porta);
            if (objEvento.Potencia != null)
                objEvento.ObjComando.Cmd = objEvento.Potencia;
            string cmd = Convertt.ToComando(objEvento);

            con.Enviar(cmd);
            Servico boServico = new Servico();
            if(objEvento.ObjDispositvo.ObjControle.Tipocontrole != TipoControle.SIMPLES || objEvento.ObjComando.Cmd != "2")
                boServico.GravarHistorico(objEvento);
            return Convertt.InformarUsuario(objEvento);
        }
    }
}
