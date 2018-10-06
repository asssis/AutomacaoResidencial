using Negocio.Bo;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeControl.Forms.Cliente
{
    public partial class WFDivisao : System.Web.UI.Page
    {
        //DECLARANDO VARIAVEIS
        DivisaoBO boDivisao;

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
            boDivisao = new DivisaoBO();
            Unidade obj = (Unidade)Session["objUnidade"];
            if (obj != null)
                CarregarControles(obj);
            else
                Response.Redirect(@"~\Forms\Cliente\WFUnidade.aspx");
        }
        protected void Selecionar(object Botao)
        {
            Divisao obj = boDivisao.BuscarDivisaoIdBotao(((Button)Botao).ID);
            Session["objDivisao"] = obj;
            Response.Redirect(@"~\Forms\Cliente\WFDispositivo.aspx");
        }
        protected void Sair()
        {
            Session.Remove("objAutenticacao");
            Response.Redirect(@"~\Forms\WFLogin.aspx");
        }
        protected void CarregarControles(Unidade obj)
        {
            divVisualizacaoDivisao.Controls.Clear();
            if (obj != null)
            {
            CriarControlesPrincipais(obj.Descricao);
            CriarControleNavegacao();
            obj = boDivisao.BuscarDivisoesUnidade(obj);

            if (obj != null)
                if (obj.ObjsDivisoes != null)
                {
                    for (int i = 0; i < obj.ObjsDivisoes.Count; i++)
                        CriarControleDinamico(obj.ObjsDivisoes[i]);
                }
                else
                {
                    throw new Exception("Nenhuma divisão cadastrada!");
                }
        }
        }

        //METODOS EXTRAS
        protected void CriarControleNavegacao()
        {
            LinkButton btnLink = new LinkButton();

            btnLink.Text = "HOME";
            btnLink.CssClass = "subtitulo clear";
            btnLink.Attributes.Add("href", "WFUnidade.aspx");
            divVisualizacaoDivisao.Controls.Add(btnLink);

            HtmlGenericControl p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            divVisualizacaoDivisao.Controls.Add(p);

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
            btnLink.Enabled = false;
            btnLink.Attributes.Add("href", @"WFDivisao.aspx");
            divVisualizacaoDivisao.Controls.Add(btnLink);
                        
        }
        protected void CriarControlesPrincipais(String titulo)
        {

            Label lblTituloUnidade = new Label();
            lblTituloUnidade.CssClass = "titulo";
            lblTituloUnidade.Text = titulo;
            divVisualizacaoDivisao.Controls.Add(lblTituloUnidade);

            //ADICIONANDO O BOTÃO SAIR
            Button btn = new Button();
            btn.ID = "btnSair";
            btn.CssClass = "btn-touch-sair";
            btn.Text = "X";
            btn.Click += btnSair_Click;
            btn.EnableViewState = true;
            divVisualizacaoDivisao.Controls.Add(btn);
        }
        protected void CriarControleDinamico(Divisao obj)
        {
            Button btn = new Button();
            btn.ID = "btn" + obj.Id.ToString();
            btn.CssClass = "btn-touch-inteiro";
            btn.Text = obj.Descricao;
            btn.Click += btnSelecionar_Click;
            btn.EnableViewState = true;
            divVisualizacaoDivisao.Controls.Add(btn);
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }     
    }
}