using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Bo;
using Negocio.Model;
using System.Web.UI.HtmlControls;


namespace HomeControl.Forms.Cliente
{
    public partial class WFHistorico : System.Web.UI.Page
    {
        //DECLARANDO VARIAVEIS
        HistoricoBO boHistorico;
        ControleBO boControle;
        String Data;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Load();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }

        //METODOS PRINCIPAIS
        protected void Load()
        {
            boControle = new ControleBO();
            boHistorico = new HistoricoBO();
            Dispositivo obj = (Dispositivo)Session["objDispositivo"];
            if (obj != null)
                CarregarControles(obj);
            else
                Response.Redirect(@"~\Forms\Cliente\WFDispositivo.aspx");
        }

        //METODOS EXTRAS           
        protected void CarregarControles(Dispositivo obj)
        {
            if (obj != null)
            {
                List<Historico> objsHistoricos = boHistorico.BuscarHistoricoDispositivo(obj);
                divVisualizacaoHistorico.Controls.Clear();

                Label lblTituloUnidade = new Label();
                lblTituloUnidade.CssClass = "titulo";
                lblTituloUnidade.Text = obj.Nome;
                divVisualizacaoHistorico.Controls.Add(lblTituloUnidade);
                for (int i = 0; i < objsHistoricos.Count; i++)
                    CriarItensHistorico(objsHistoricos[i]);

            }
        }
        protected void CriarItensHistorico(Historico obj)
        {
            if (Data != obj.Momento.ToString("dd/MM/yyyy"))
            {
                Data = obj.Momento.ToString("dd/MM/yyyy");
                HtmlGenericControl pData = new HtmlGenericControl("p");
                pData.Attributes.Add("class", "data-historico");
                pData.InnerText = boHistorico.ConvertData(obj.Momento);
                divVisualizacaoHistorico.Controls.Add(pData);
            }

            HtmlGenericControl divItemHistorico = new HtmlGenericControl("div");
            divItemHistorico.Attributes.Add("class", "item-historico");

            HtmlGenericControl pItem = new HtmlGenericControl("div");
            pItem.Attributes.Add("class", "historico");
            pItem.InnerText = obj.Momento.ToString("HH:mm");
            divItemHistorico.Controls.Add(pItem);

            pItem = new HtmlGenericControl("p");
            pItem.InnerText = obj.ObjDispositivo.ObjDivisao.ObjUnidade.ObjUsuario.Nome.ToUpper();
            divItemHistorico.Controls.Add(pItem);

            pItem = new HtmlGenericControl("p");
            if (obj.ObjComando.Estilo == "btn-touch-nulo")
                pItem.InnerText = Convert.ToString(obj.ConsumoEnergia).ToUpper() + " KWH";
            else
                pItem.InnerText = obj.Descricao.ToUpper();

            divItemHistorico.Controls.Add(pItem);
            divVisualizacaoHistorico.Controls.Add(divItemHistorico);
        }
        void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }
    }
}