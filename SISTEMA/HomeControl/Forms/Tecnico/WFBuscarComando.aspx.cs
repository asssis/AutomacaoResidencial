using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Negocio.Model;
using Negocio.Bo;

namespace HomeControl.Forms.Tecnico
{
    public partial class WFBuscarComando : System.Web.UI.Page
    {
        ComandoBO boComando;
        ControleBO boControle;
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
        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                Selecionar(sender);
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }
        //METODOS PRINCIPAIS
        protected void Load()
        {

            boComando = new ComandoBO();
            boControle = new ControleBO();

            Controle objControle = (Controle)Session["objControle"];
            if (objControle != null)
            {                
                CarregarControle(objControle);
            }
            else
            {
                Response.Redirect(@"~\Forms\Tecnico\WFManterLeitor.aspx");
            }
           
        }
        protected void Selecionar(object sender)
        {

            Session["objComando"] = boComando.BuscarComandoIdBotao(((Button)sender).ID);

                if ((string)Session["Retorno"] != null)
                    Response.Redirect((string)Session["Retorno"]);
                else
                    Response.Redirect(@"~\Forms\Tecnico\WFManterComando.aspx");                
        }

        //METODOS EXTRAS
        protected void CarregarControle(Controle obj)
        {
            if (obj != null)
            {
                obj.ObjsComandos = boComando.BuscarComandoControle(obj);
                divVisualizacaoControle.Controls.Clear();

                Label lblTituloControle = new Label();
                lblTituloControle.CssClass = "titulo";
                lblTituloControle.Text = obj.Modelo;
                divVisualizacaoControle.Controls.Add(lblTituloControle);

                if (obj != null)
                    if (obj.ObjsComandos != null)
                        for (int i = 0; i < obj.ObjsComandos.Count; i++)
                        {
                            if (obj.ObjsComandos[i].Estilo != "range-touch-inteiro")
                            {
                                Button btn = new Button();
                                btn.ID = "btn" + obj.ObjsComandos[i].Id.ToString();
                                btn.CssClass = obj.ObjsComandos[i].Cor + " " + obj.ObjsComandos[i].Estilo;
                                btn.Text = obj.ObjsComandos[i].Nome;
                                btn.Click += btnSelecionar_Click;
                                btn.EnableViewState = true;
                                divVisualizacaoControle.Controls.Add(btn);
                            }
                            else if (obj.ObjsComandos[i].Estilo == "range-touch-inteiro")
                            {
                                TextBox range = new TextBox();
                                range.ID = "txt" + obj.ObjsComandos[i].Id.ToString();
                                range.CssClass = obj.ObjsComandos[i].Estilo + " btn-range-margin";
                                range.TextMode = TextBoxMode.Range;
                                range.Enabled = false;
                                Button btn = new Button();
                                btn.ID = "btn" + obj.ObjsComandos[i].Id.ToString();

                                btn.CssClass = "btn-selecionar-range";
                                btn.Text = obj.ObjsComandos[i].Nome;
                                btn.Click += btnSelecionar_Click;
                                btn.Text = "SELECIONAR";
                                btn.EnableViewState = true;
                                divVisualizacaoControle.Controls.Add(range);
                                divVisualizacaoControle.Controls.Add(btn);
                            }
                        }
                if (obj != null)
                    divPreVisualizacao.Attributes.Add("class", " inicio bloco-inteiro tela-preta");
                else
                    divPreVisualizacao.Attributes.Add("class", "invisible");
            }
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
             ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }

    }
}