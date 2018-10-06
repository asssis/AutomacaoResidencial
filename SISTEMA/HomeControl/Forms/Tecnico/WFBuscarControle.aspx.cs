using Negocio.Bo;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeControl.Forms.Tecnico
{
    public partial class WFBuscarControle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void gvPesquisaControle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Selecionar();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }
        protected void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                Pesquisa();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }   
        }

        //METODOS PRINCIPAIS
        protected void Selecionar()
        {
            ControleBO bo = new ControleBO();
            Session["objControle"] = bo.BuscarId((int)gvPesquisaControle.SelectedValue);
            
            if ((string)Session["Retorno"] != null)
                Response.Redirect((string)Session["Retorno"]);
            else
                Response.Redirect(@"~\Forms\Tecnico\WFManterControle.aspx");
        }
        protected void Pesquisa()
        {
            ControleBO boControle = new ControleBO();
            switch (ddlPesquisa.Text)
            {
                case "Geral":
                    gvPesquisaControle.DataSource = boControle.BuscarGeral(txtPesquisa.Text);
                    gvPesquisaControle.DataBind();
                    break;
            }
        }

        //METODOS EXTRAS
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }
    }
}