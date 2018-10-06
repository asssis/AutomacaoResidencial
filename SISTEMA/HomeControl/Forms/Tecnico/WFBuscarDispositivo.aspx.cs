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
    public partial class WFBuscarDispositivo : System.Web.UI.Page
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
                ExibirMensagem("e", msn.Message);
            }
        }
        protected void gvPesquisaDispositivo_SelectedIndexChanged(object sender, EventArgs e)
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
            DispositivoBO bo = new DispositivoBO();
            Session["objDispositivo"] = bo.BuscarId(Convert.ToInt32(gvPesquisaDispositivo.SelectedValue));
      
            if ((string)Session["Retorno"] != null)
                Response.Redirect((string)Session["Retorno"]);
            else
                Response.Redirect(@"~\Forms\Tecnico\WFManterDispositivo.aspx");
        }
        protected void Pesquisa()
        {
            DispositivoBO boDivisao = new DispositivoBO();
            switch (ddlPesquisa.Text)
            {
                case "Geral":
                    gvPesquisaDispositivo.DataSource = boDivisao.BuscarGeral(txtPesquisa.Text);
                    gvPesquisaDispositivo.DataBind();
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