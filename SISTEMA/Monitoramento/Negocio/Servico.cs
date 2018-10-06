using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitoramento.webHomeControl;

namespace Monitoramento.Negocio
{
    public class Servico
    {
        public void GravarHistorico(Evento obj)
        {
            Historico objHistorico = new Historico();
            objHistorico.ObjDispositivo = obj.ObjDispositvo;
            objHistorico.ObjComando = obj.ObjComando;
            Double porcentagem = 1;
            if (obj.Potencia != null)
                porcentagem = Convert.ToDouble(obj.Potencia) / 100;
            objHistorico.ConsumoAgua = Convert.ToDouble(obj.ObjComando.ConsumoAgua) * porcentagem;
            objHistorico.ConsumoEnergia = Convert.ToDouble(obj.ObjComando.ConsumoEnergia) * porcentagem;

            if (obj.ObjComando.Estilo == "range-touch-inteiro")
                objHistorico.Descricao = obj.Potencia;
            else
                objHistorico.Descricao = obj.ObjComando.Nome;
            objHistorico.Momento = DateTime.Now;

            webHomeControlSoapClient web = new webHomeControlSoapClient();
            web.GravarHistorico(objHistorico);
        }
    }
}
