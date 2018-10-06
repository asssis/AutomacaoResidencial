using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Bo;
using Negocio.Model;

namespace HomeControl.Forms.Administrador
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
                ExibirMensagem("e", "Erro :" + msn.Message);
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
                ExibirMensagem("e", "Erro :" + msn.Message);
            } 
        }

        //METODOS PRINCIPAIS
        protected void Selecionar()
        {
            UsuarioBO bo = new UsuarioBO();
            Unidade objUnidade = (Unidade)Session["objUnidade"];

            Session["objUsuario"] = bo.BuscarId((int)gvPesquisaUsuario.SelectedValue);

            if (objUnidade != null)
            objUnidade.ObjUsuario = (Usuario)Session["objUsuario"];

            if ((string)Session["Retorno"] != "")
                Response.Redirect((string)Session["Retorno"]);
            else
                Response.Redirect(@"~\Forms\Administrador\WFManterUsuario.aspx");
        }
        protected void Pesquisa()
        {
            UsuarioBO boUsuario = new UsuarioBO();
            switch (ddlPesquisa.Text)
            {
                case "Geral":
                    gvPesquisaUsuario.DataSource = boUsuario.BuscarGeral(txtPesquisa.Text);
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