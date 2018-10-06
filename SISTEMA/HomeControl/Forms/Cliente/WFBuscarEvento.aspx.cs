using Negocio;
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
    public partial class WFBuscarEvento : System.Web.UI.Page
    {
        //DECLARANDO VARIAVEIS
        EventoBO boEvento;
        //CHAMADOS DE EVENTO
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
        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                Deletar();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }

        protected void Deletar()
        {
            hfMenu.Value = "deletar";
            ExibirMensagem("a", "Você confirmar a exclusão dos agendamentos?");
            Load();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Confirmar(sender);
                hfMenu.Value = "";
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
        protected void btnCriarAgendamento_Click(object sender, EventArgs e)
        {
            try
            {
                CriarAgendamento();
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
            Dispositivo obj = (Dispositivo)Session["objDispositivo"];
            if (obj != null)
                CarregarControles(obj);
            else
                Response.Redirect(@"~\Forms\Cliente\WFControle.aspx");
        }
        protected void Selecionar(object Botao)
        {
            Session["objEvento"] = boEvento.BuscarEventoIdBotao(((LinkButton)Botao).ID);
            Response.Redirect(@"~\Forms\Cliente\WFManterEvento.aspx");

        }

        private void Confirmar(object button)
        {
            if (((LinkButton)button).ID == "btnConfirmar")
                ExibirMensagem("s", new EventoBO().DeletarTodosEventosDispositivo((Dispositivo)Session["objDispositivo"]));
            else
                ExibirMensagem("s","Operação cancelada com sucesso.");
            hfMenu.Value = "";
            Load();

        }
        protected void CarregarControles(Dispositivo obj)
        {
            divVisualizacaoAgendamento.Controls.Clear();
            if (obj != null)
            {
                CriarControlesPrincipais("AGENDAMENTO");
                CriarControleNavegacao();
                List<Evento> objs = boEvento.BuscaEventoBanco(obj);
                if (objs != null)
                {
                    for (int i = 0; i < objs.Count; i++)
                        if (objs[i] != null)
                            if (objs[i].ObjAgenda != null)
                                CriarControleDinamico(objs[i]);
                }
                else
                    ExibirMensagem("a", "Nenhum evento cadastrado");
            }
        }
        protected void CriarAgendamento()
        {
            Evento objEvento = new Evento();
            objEvento.ObjDispositvo = (Dispositivo)Session["objDispositivo"];
            Session["objEvento"] = objEvento;
            Response.Redirect(@"~\Forms\Cliente\WFManterEvento.aspx");
        }
        protected void Sair()
        {
            Session.Remove("objAutenticacao");
            Response.Redirect(@"~\Forms\WFLogin.aspx");
        }
        protected void CriarControleNavegacao()
        {
            LinkButton btnLink = new LinkButton();
            btnLink.Text = "HOME";
            btnLink.CssClass = "subtitulo";
            btnLink.Attributes.Add("href", "WFUnidade.aspx");
            divVisualizacaoAgendamento.Controls.Add(btnLink);

            HtmlGenericControl p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            divVisualizacaoAgendamento.Controls.Add(p);

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
            btnLink.Attributes.Add("href", "WFUnidade.aspx");
            divVisualizacaoAgendamento.Controls.Add(btnLink);

            p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            btnLink.Attributes.Add("href", "WFDivisao.aspx");
            divVisualizacaoAgendamento.Controls.Add(p);

            btnLink = new LinkButton();
            try
            {
                btnLink.Text = ((Divisao)Session["objDivisao"]).Descricao.ToUpper();
            }
            catch (Exception)
            {
                btnLink.Text = "DIVISÃO";
            }
            btnLink.CssClass = "subtitulo";
            divVisualizacaoAgendamento.Controls.Add(btnLink);

            p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            btnLink.Attributes.Add("href", "WFDispositivo.aspx");
            divVisualizacaoAgendamento.Controls.Add(p);

            btnLink = new LinkButton();
            try
            {
                btnLink.Text = ((Dispositivo)Session["objDispositivo"]).Nome.ToUpper();
            }
            catch (Exception)
            {
                btnLink.Text = "DISPOSITIVO";
            }
            btnLink.CssClass = "subtitulo";
            divVisualizacaoAgendamento.Controls.Add(btnLink);

            p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            btnLink.Attributes.Add("href", "WFControle.aspx");
            divVisualizacaoAgendamento.Controls.Add(p);

            btnLink = new LinkButton();
            btnLink.Text = "AGENDA";
            btnLink.CssClass = "subtitulo";
            btnLink.Enabled = false;
            divVisualizacaoAgendamento.Controls.Add(btnLink);
        }
        //METODOS EXTRAS
        protected void CriarControlesPrincipais(String titulo)
        {
            //ADICIONADO O TITULO DO CONTROLE
            Label lblTituloUnidade = new Label();
            lblTituloUnidade.CssClass = "titulo";
            lblTituloUnidade.Text = titulo;
            divVisualizacaoAgendamento.Controls.Add(lblTituloUnidade);

            //ADICIONANDO O BOTÃO SAIR
            Button btn = new Button();
            btn.ID = "btnSair";
            btn.CssClass = "btn-touch-sair";
            btn.Text = "X";
            btn.Click += btnSair_Click;
            btn.EnableViewState = true;
            divVisualizacaoAgendamento.Controls.Add(btn);

            if (hfMenu.Value == "")
            {
                divMenuPrincipal.Controls.Clear();
                btn = new Button();
                btn.ID = "btnCriarAgendamento";
                btn.CssClass = "a-toch-dois-terco ativo";
                btn.Text = "CRIAR AGENDAMENTO";
                btn.Click += btnCriarAgendamento_Click;
                btn.EnableViewState = true;
                divMenuPrincipal.Controls.Add(btn);

                btn = new Button();
                btn.ID = "btnDeletar";
                btn.CssClass = "a-toch-um-terco ativo-vermelho";
                btn.Text = "DELETAR";
                btn.Click += btnDeletar_Click;
                btn.EnableViewState = true;
                divMenuPrincipal.Controls.Add(btn);

                LinkButton a = new LinkButton();
                a.CssClass = "a-toch-um-meio ativo";
                a.Attributes.Add("href", "WFUnidade.aspx");
                a.Text = "HOME";
                divMenuPrincipal.Controls.Add(a);

                a = new LinkButton();
                a.CssClass = "a-toch-um-meio ativo";
                a.Attributes.Add("href", "WFControle.aspx");
                a.Text = "VOLTAR";
                divMenuPrincipal.Controls.Add(a);
            }
            else if (hfMenu.Value == "deletar")
            {
                divMenuPrincipal.Controls.Clear();
                LinkButton btnConfirmar = new LinkButton();
                btnConfirmar.ID = "btnConfirmar";
                btnConfirmar.Text = "CONFIRMAR";
                btnConfirmar.CssClass = "a-toch-um-meio ativo";
                btnConfirmar.EnableViewState = true;
                btnConfirmar.Click += btnConfirmar_Click;
                divMenuPrincipal.Controls.Add(btnConfirmar);

                btnConfirmar = new LinkButton();
                btnConfirmar.ID = "btnCancelar";
                btnConfirmar.Text = "CANCELAR";
                btnConfirmar.CssClass = "a-toch-um-meio";
                btnConfirmar.EnableViewState = true;
                btnConfirmar.Click += btnConfirmar_Click;
                divMenuPrincipal.Controls.Add(btnConfirmar);
            }
        }
        protected void CriarControleDinamico(Evento obj)
        {
                LinkButton btn = new LinkButton();
                btn.ID = "btn" + obj.Id;
                btn.CssClass = "btn-touch-inteiro";
                btn.Click += btnSelecionar_Click;
                btn.EnableViewState = true;

                HtmlGenericControl pHora = new HtmlGenericControl("p");
                pHora.InnerText = Convertt.ToString(obj.ObjAgenda.Hora);
                pHora.Attributes.Add("class", "phora");
                btn.Controls.Add(pHora);
                
                HtmlGenericControl divTempo = new HtmlGenericControl("div");
                divTempo.Attributes.Add("class", "centralizar-tempo");
                btn.Controls.Add(divTempo);
                divVisualizacaoAgendamento.Controls.Add(btn);


                divTempo.Controls.Add(PreencherDiaSemana(obj.ObjAgenda.Domingo, "D"));
                divTempo.Controls.Add(PreencherDiaSemana(obj.ObjAgenda.Segunda, "S"));
                divTempo.Controls.Add(PreencherDiaSemana(obj.ObjAgenda.Terca, "T"));
                divTempo.Controls.Add(PreencherDiaSemana(obj.ObjAgenda.Quarta, "Q"));
                divTempo.Controls.Add(PreencherDiaSemana(obj.ObjAgenda.Quinta, "Q"));
                divTempo.Controls.Add(PreencherDiaSemana(obj.ObjAgenda.Sexta, "S"));
                divTempo.Controls.Add(PreencherDiaSemana(obj.ObjAgenda.Sabado, "S"));  

                HtmlGenericControl pComando = new HtmlGenericControl("p");
                pComando.InnerText = Convertt.ToString(obj.ObjComando.Nome);
                pComando.Attributes.Add("class", "pcomando");
                btn.Controls.Add(pComando);
        }
        protected HtmlGenericControl PreencherDiaSemana(bool valor, string dia)
        {
            HtmlGenericControl pSemana = new HtmlGenericControl("p");
            pSemana.InnerText = dia;
            if (valor)
                pSemana.Attributes.Add("class", "semana-ativa");
            else
                pSemana.Attributes.Add("class", "semana-desativa");
            return pSemana;
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }

    }
}