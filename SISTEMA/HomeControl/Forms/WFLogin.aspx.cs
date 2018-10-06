using Negocio.Bo;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeControl.Forms
{
    public partial class WFLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnFazerLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Logar();
            }
            catch
            {
                ExibirMensagem("Usuário não encontrador");
            }
        }
        protected void Logar()
        {
            UsuarioBO bo = new UsuarioBO();
            Usuario obj = bo.Logar(PreecherObjeto());
            switch (obj.Nivel)
            {
                case NivelAcesso.CLIENTE:
                    Session["objAutenticacao"] = obj;
                    Response.Redirect(@"~\Forms\Cliente\WFUnidade.aspx");
                    break;
                case NivelAcesso.TECNICO:
                    Session["objAutenticacao"] = obj;
                    Response.Redirect(@"~\Forms\Tecnico\WFIndex.aspx");
                    break;
                case NivelAcesso.ADMINISTRADOR:
                    Session["objAutenticacao"] = obj;
                    Response.Redirect(@"~\Forms\Administrador\WFIndex.aspx");
                    break;
                default:
                    ExibirMensagem("Usuario não encontrado!");
                    break;
            }
        }
        protected Usuario PreecherObjeto()
        {
            Usuario obj = new Usuario();
            obj.Senha = txtSenha.Text;
            obj.Login = txtUsuario.Text;
            return obj;
        }
        protected void ExibirMensagem( string mensagem)
        {
            lblMsn.Text = mensagem;
        }
    }
}