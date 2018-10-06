using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Model;
using Negocio.Bo;
using System.Web.UI.HtmlControls;

namespace HomeControl.Forms.Cliente
{
    public partial class WFDispositivo : System.Web.UI.Page
    {
        //DECLARANDO VARIAVEIS
        DispositivoBO boDispositivo;

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
            boDispositivo = new DispositivoBO();
            Divisao obj = (Divisao)Session["objDivisao"];
            if (obj != null)
                CarregarControles(obj);
            else
                Response.Redirect(@"~\Forms\Cliente\WFDivisao.aspx");
        }
        protected void Selecionar(object Botao)
        {
            Dispositivo obj = boDispositivo.BuscarDispositivoIdBotao(((Button)Botao).ID);
            Session["objDispositivo"] = obj;
            Response.Redirect(@"~\Forms\Cliente\WFControle.aspx");
        }
        protected void CarregarControles(Divisao obj)
        {
            divVisualizacaoDispositivo.Controls.Clear();
            if (obj != null)
            {
                CriarControlesPrincipais(obj.Descricao);
                CriarControleNavegacao();
                //PROBLEMA COM POOL BEM AQUI!
                obj = boDispositivo.BuscarDispositivosDivisao(obj);
                if (obj != null)
                    if (obj.ObjsDispositivos != null)
                    {
                        for (int i = 0; i < obj.ObjsDispositivos.Count; i++)
                            CriarControleDinamico(obj.ObjsDispositivos[i]);
                    }
                    else
                    {
                        throw new Exception("Nenhum dispositivo cadastrado!");
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
            btnLink.Text = "HOME";
            btnLink.CssClass = "subtitulo clear";
            btnLink.Attributes.Add("href", "WFUnidade.aspx");
            divVisualizacaoDispositivo.Controls.Add(btnLink);

            HtmlGenericControl p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            divVisualizacaoDispositivo.Controls.Add(p);

            btnLink = new LinkButton();
            try
            {
                btnLink.Text = ((Unidade)Session["objUnidade"]).Descricao.ToUpper();
            }
            catch (Exception)
            {
                btnLink.Text = "UNIDADE";
            }
            btnLink.CssClass = "subtitulo";
            btnLink.Attributes.Add("href", "WFDivisao.aspx");
            divVisualizacaoDispositivo.Controls.Add(btnLink);

             p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            divVisualizacaoDispositivo.Controls.Add(p);

            btnLink = new LinkButton();
            try
            {
                btnLink.Text = ((Divisao)Session["objDivisao"]).Descricao.ToUpper();
            }
            catch (Exception)
            {
                btnLink.Text = "DIVISÃO";
            }
            btnLink.Enabled = false;
            btnLink.CssClass = "subtitulo";
            divVisualizacaoDispositivo.Controls.Add(btnLink);
        }
        protected void CriarControlesPrincipais(String titulo)
        {
            //ADICIONADO O TITULO DO CONTROLE
            Label lblTituloUnidade = new Label();
            lblTituloUnidade.CssClass = "titulo";
            lblTituloUnidade.Text = titulo;
            divVisualizacaoDispositivo.Controls.Add(lblTituloUnidade);

            //ADICIONANDO O BOTÃO SAIR
            Button btn = new Button();
            btn.ID = "btnSair";
            btn.CssClass = "btn-touch-sair";
            btn.Text = "X";
            btn.Click += btnSair_Click;
            btn.EnableViewState = true;
            divVisualizacaoDispositivo.Controls.Add(btn);
        }
        protected void CriarControleDinamico(Dispositivo obj)
        {
            Button btn = new Button();
            btn.ID = "btn" + obj.Id.ToString();
            btn.CssClass = "btn-touch-inteiro";
            btn.Text = obj.Nome;
            btn.Click += btnSelecionar_Click;
            btn.EnableViewState = true;
            divVisualizacaoDispositivo.Controls.Add(btn);
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }     
    }
}