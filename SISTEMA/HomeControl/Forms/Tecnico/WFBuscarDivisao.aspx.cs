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
    public partial class WFBuscarDivisao : System.Web.UI.Page
    {
        //EVENTOS PRINCIPAIS
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
        protected void gvPesquisaDivisao_SelectedIndexChanged(object sender, EventArgs e)
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
            DivisaoBO bo = new DivisaoBO();
            Session["objDivisao"] = bo.BuscarId((int)gvPesquisaDivisao.SelectedValue);            

            if ((string)Session["Retorno"] != null)
                Response.Redirect((string)Session["Retorno"]);
            else
                Response.Redirect(@"~\Forms\Tecnico\WFManterDivisao.aspx");
        }
        protected void Pesquisa()
        {
            DivisaoBO boDivisao = new DivisaoBO();
            switch (ddlPesquisa.Text)
            {
                case "Geral":
                    gvPesquisaDivisao.DataSource = boDivisao.BuscarGeral(txtPesquisa.Text);
                    gvPesquisaDivisao.DataBind();
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