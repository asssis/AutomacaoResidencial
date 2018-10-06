using Negocio.Bo;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeControl.Forms.Cliente
{
    public partial class WFBuscarAgendamentos : System.Web.UI.Page
    {

        //DECLARANDO VARIAVEIS
        EventoBO boEvento;
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
        private void btnSelecionar_Click(object sender, EventArgs e)
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
            boEvento = new EventoBO();
            Usuario obj = (Usuario)Session["objAutenticacao"];
            CarregarControles(obj);
        }

        private void CarregarControles(Usuario obj)
        {
            CriarControlesPrincipais();
            CriarControleNavegacao();
            if (obj != null)
            {
            
                List<Dispositivo> objsDispositivo = boEvento.BuscarEventosUsuario(obj);
                if (objsDispositivo != null)
                    for (int i = 0; i < objsDispositivo.Count; i++)
                        if(objsDispositivo[i].ObjsEventos != null)
                        CriarControleDinamico(objsDispositivo[i]);
            }
        }
        protected void CriarControleDinamico(Dispositivo obj)
        {
            StringBuilder descricao = new StringBuilder();
            descricao.Append(obj.ObjDivisao.ObjUnidade.Descricao);
            descricao.Append("/");
            descricao.Append(obj.ObjDivisao.Descricao);
            descricao.Append("/");
            descricao.Append(obj.Nome);
            descricao.Append("  (");
            descricao.Append(obj.ObjsEventos.Count);

            descricao.Append(")");
            Button btn = new Button();
            btn.ID = "btn" + obj.Id.ToString();
            btn.CssClass = "btn-touch-inteiro";
            btn.Text = descricao.ToString().ToUpper();
            btn.Click += btnSelecionar_Click;
            btn.EnableViewState = true;
            divVisualizacaoAgendamento.Controls.Add(btn);
        }

      
        protected void Selecionar(object Botao)
        {
            Dispositivo obj = new DispositivoBO().BuscarDispositivoIdBotao(((Button)Botao).ID);
            Session["objDispositivo"] = obj;
            Session["objUnidade"] = obj.ObjDivisao.ObjUnidade;
            Session["objDivisao"] = obj.ObjDivisao;
            Response.Redirect(@"~\Forms\Cliente\WFBuscarEvento.aspx");
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
            btnLink.CssClass = "subtitulo";
            btnLink.Attributes.Add("href", "WFUnidade.aspx");
            btnLink.Enabled = true;
            divVisualizacaoAgendamento.Controls.Add(btnLink);

            HtmlGenericControl p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            divVisualizacaoAgendamento.Controls.Add(p);

            btnLink = new LinkButton();
            btnLink.Text = "AGENDAMENTOS";
            btnLink.CssClass = "subtitulo";
            btnLink.Attributes.Add("href", "WFUnidade.aspx");
            btnLink.Enabled = false;
            divVisualizacaoAgendamento.Controls.Add(btnLink);
        }
        protected void CriarControlesPrincipais()
        {
            Label lblTituloUnidade = new Label();
            lblTituloUnidade.CssClass = "titulo";
            lblTituloUnidade.Text = "AGENDAMENTOS";
            divVisualizacaoAgendamento.Controls.Add(lblTituloUnidade);


            //ADICIONANDO O BOTÃO SAIR
            Button btn = new Button();
            btn.ID = "btnSair";
            btn.CssClass = "btn-touch-sair";
            btn.Text = "X";
            btn.Click += btnSair_Click;
            btn.EnableViewState = true;
            divVisualizacaoAgendamento.Controls.Add(btn);
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }

    }
}