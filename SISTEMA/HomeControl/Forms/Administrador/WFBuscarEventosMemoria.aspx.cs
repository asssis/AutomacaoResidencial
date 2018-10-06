using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Negocio.Model;

namespace HomeControl.Forms.Administrador
{
    public partial class WFBuscarEventosMemoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                IList<Evento> objs =  ListaEventos.Instancia.ObjsEventos;
                gvPesquisarEventos.DataSource = objs;
                gvPesquisarEventos.DataBind();
            }
            catch
            {
                ExibirMensagem("a", "Falha ao buscar eventos.");
            }
        }

        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }

        protected void btnPesquisa_Click(object sender, EventArgs e)
        {

        }
    }
}