using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Model;
using Negocio.Bo;
using Negocio;
using System.Web.UI.HtmlControls;

namespace HomeControl.Forms.Cliente
{
    public partial class WFUnidade : System.Web.UI.Page
    {
        //DECLARANDO VARIAVEIS
        UnidadeBO boUnidade;

        //CHAMADOS EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Load();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }
        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                Selecionar(sender);
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }
        protected void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                Sair();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }

        //METODOS PRINCIPAIS
        protected void Load()
        {
            boUnidade = new UnidadeBO();
            Usuario obj = (Usuario)Session["objAutenticacao"];
            CarregarControles(obj);
        }
        protected void Selecionar(object Botao)
        {
            Unidade obj = boUnidade.BuscarUnidadeIdBotao(((Button)Botao).ID);
            Session["objUnidade"] = obj;
            Response.Redirect(@"~\Forms\Cliente\WFDivisao.aspx");
        }
        protected void CarregarControles(Usuario obj)
        {
            divVisualizacaoUnidade.Controls.Clear();
            CriarControlesPrincipais();
            CriarControleNavegacao();
            if (obj != null)
            {

                obj = boUnidade.BuscarUnidadesUsuario(obj);
                if (obj != null)
                    if (obj.ObjsUnidades != null)
                    {
                        for (int i = 0; i < obj.ObjsUnidades.Count; i++)
                            CriarControleDinamico(obj.ObjsUnidades[i]);
                    }
                    else
                    {

                        throw new Exception("Nenhuma unidade cadastrada!");
                    }
            }
        }
        protected void Sair()
        {
            Session.Remove("objAutenticacao");
            Response.Redirect(@"~\Forms\WFLogin.aspx");
        }

        //METODOS EXTRAS
        protected void CriarControleNavegacao()
        {
            LinkButton btnLink = new LinkButton();
            try
            {
                btnLink.Text = ((Unidade)Session["objUnidade"]).Descricao.ToUpper();
            }
            catch (Exception)
            {
                btnLink.Text = "HOME";
            }
            btnLink.CssClass = "subtitulo clear";
            btnLink.Attributes.Add("href", "WFUnidade.aspx");
            btnLink.Enabled = false;
            divVisualizacaoUnidade.Controls.Add(btnLink);
        }
        protected void CriarControlesPrincipais()
        {
            Label lblTituloUnidade = new Label();
            lblTituloUnidade.CssClass = "titulo";
            lblTituloUnidade.Text = "UNIDADES";
            divVisualizacaoUnidade.Controls.Add(lblTituloUnidade);


            //ADICIONANDO O BOTÃO SAIR
            Button btn = new Button();
            btn.ID = "btnSair";
            btn.CssClass = "btn-touch-sair";
            btn.Text = "X";
            btn.Click += btnSair_Click;
            btn.EnableViewState = true;
            divVisualizacaoUnidade.Controls.Add(btn);
        }
        protected void CriarControleDinamico(Unidade obj)
        {
                        Button btn = new Button();
                        btn.ID = "btn" + obj.Id.ToString();
                        btn.CssClass = "btn-touch-inteiro";
                        btn.Text = obj.Descricao;
                        btn.Click += btnSelecionar_Click;
                        btn.EnableViewState = true;
                        divVisualizacaoUnidade.Controls.Add(btn);
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }     
    }
}