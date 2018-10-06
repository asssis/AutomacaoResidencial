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
    public partial class WFBuscarUnidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void gvPesquisaUnidade_SelectedIndexChanged(object sender, EventArgs e)
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

        //METODOS PRINCIPAIS
        protected void Selecionar()
        {
            UnidadeBO bo = new UnidadeBO();
            Session["objUnidade"] = bo.BuscarId((int)gvPesquisaUnidade.SelectedValue);

            if ((string)Session["Retorno"] != "")
                Response.Redirect((string)Session["Retorno"]);
            else
                Response.Redirect(@"~\Forms\Tecnico\WFManterUnidade.aspx");
        }
        protected void Pesquisa()
        {
            UnidadeBO boUnidade = new UnidadeBO();
            switch (ddlPesquisa.Text)
            {
                case "Geral":
                    gvPesquisaUnidade.DataSource = boUnidade.BuscarGeral(txtPesquisa.Text);
                    gvPesquisaUnidade.DataBind();
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