using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeControl.Mpage
{
    public partial class MPAdministrador : System.Web.UI.MasterPage
    {
        //CHAMADA DE EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Load();
            }
            catch (Exception)
            {

            }
        }

        protected void lkbSair_Click(object sender, EventArgs e)
        {
            try
            {
                Sair();
            }
            catch (Exception)
            {
            }
        }
        //METODOS PRINCIPAIS
        protected void Load()
        {
            Usuario obj = (Usuario)Session["objAutenticacao"];
            if (obj == null)
                Response.Redirect(@"~\Forms\WFLogin.aspx");
            else
                if(obj.Nivel!= NivelAcesso.ADMINISTRADOR)
                    Response.Redirect(@"~\Forms\WFLogin.aspx");
        }

        protected void Sair()
        {

            Session.Remove("objAutenticacao");
            Session.Remove("objUsuario");
            Session.Remove("objUnidade");
            Session.Remove("objDivisão");
            Session.Remove("objDispositivo");
            Session.Remove("objControle");
            Session.Remove("objComando");
            Session.Remove("objRetorno");
            Response.Redirect(@"~\Forms\WFLogin.aspx");
        }
    }
}