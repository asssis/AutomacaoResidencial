using Negocio.Bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeControl.Forms.Tecnico
{
    public partial class WFBuscarLeitor : System.Web.UI.Page
    {

        //CHAMADOS EVENTOS
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
                ExibirMensagem("e", "Erro " + msn.Message);
            }
        }
        protected void gvPesquisaLeitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Selecionar();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", "Erro " + msn.Message);
            }
        }

        //METODOS PRINCIPAIS
        protected void Selecionar()
        {
            LeitorBO bo = new LeitorBO();
            Session["objLeitor"] = bo.BuscarId(Convert.ToInt32(gvPesquisaLeitor.SelectedValue));

            if ((string)Session["Retorno"] != null)
                Response.Redirect((string)Session["Retorno"]);
            else
                Response.Redirect(@"~\Forms\Tecnico\WFManterLeitor.aspx");
        }
        protected void Pesquisa()
        {
            LeitorBO boLeitor = new LeitorBO();
            switch (ddlPesquisa.Text)
            {
                case "Geral":
                    gvPesquisaLeitor.DataSource = boLeitor.BuscarGeral(txtPesquisa.Text);
                    gvPesquisaLeitor.DataBind();
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