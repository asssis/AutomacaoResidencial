using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeControl.Mpage
{
    public partial class MPCliente : System.Web.UI.MasterPage
    {
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
        //METODOS PRINCIPAIS
        protected void Load()
        {
            Usuario obj = (Usuario)Session["objAutenticacao"];
            if (obj == null)
                Response.Redirect(@"~\Forms\WFLogin.aspx");
            else
                if (obj.Nivel != NivelAcesso.CLIENTE)
                Response.Redirect(@"~\Forms\WFLogin.aspx");
        }
    }
}