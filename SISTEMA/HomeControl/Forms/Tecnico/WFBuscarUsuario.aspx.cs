using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Bo;
using Negocio.Model;

namespace HomeControl.Forms.Tecnico
{
    public partial class WFBuscarUsuario : System.Web.UI.Page
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
        protected void gvPesquisaUsuario_SelectedIndexChanged(object sender, EventArgs e)
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
            UsuarioBO bo = new UsuarioBO();
            Session["objUsuario"] = bo.BuscarId((int)gvPesquisaUsuario.SelectedValue);

            if ((string)Session["Retorno"] != "")
                Response.Redirect((string)Session["Retorno"]);
            else
                Response.Redirect(@"~\Forms\Tecnico\WFManterUnidade.aspx");
        }
        protected void Pesquisa()
        {
            UsuarioBO boUsuario = new UsuarioBO();
            switch (ddlPesquisa.Text)
            {
                case "Geral":
                    gvPesquisaUsuario.DataSource = boUsuario.BuscarGeralClientes(txtPesquisa.Text);
                    gvPesquisaUsuario.DataBind();
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