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
    public partial class WFControle : System.Web.UI.Page
    {
        //DECLARANDO VARIAVEIS
        ControleBO boControle;
        HistoricoBO boHistorico;
        TextBox txtRange;
        Label lblValorRange;

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
            SelecionarBotao(sender);
        }
        protected void Selecionar_TextChanged(object sender, EventArgs e)
        {
            SelecionarTextBox(sender);
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
            boControle = new ControleBO();
            boHistorico = new HistoricoBO();
            Dispositivo obj = (Dispositivo)Session["objDispositivo"];
            if (obj != null)
                CarregarControles(obj);
            else
                Response.Redirect(@"~\Forms\Cliente\WFDispositivo.aspx");
        }
        protected void SelecionarBotao(object Botao)
        {
            Evento objEvento = new Evento();

            objEvento.ObjComando = boControle.BuscarComandoIdBotao(((Button)Botao).ID);
            objEvento.ObjAgenda = null;
            objEvento.ObjDispositvo = (Dispositivo)Session["objDispositivo"];
            if (boControle.GravarEvento(objEvento))
                ExibirMensagem("s", "Comando enviado com sucesso!");
            else
                ExibirMensagem("e", "Erro ao enviar comando!");
            System.Threading.Thread.Sleep(1500);
            Load();
        }
        protected void SelecionarTextBox(object TextBox)
        {
            Evento objEvento = new Evento();
            lblValorRange.Text = txtRange.Text + "%";

            objEvento.ObjComando = boControle.BuscarComandoIdBotao(((TextBox)TextBox).ID);
            objEvento.ObjAgenda = null;
            objEvento.ObjDispositvo = (Dispositivo)Session["objDispositivo"];
            objEvento.Potencia = txtRange.Text;

            if (boControle.GravarEvento(objEvento))
                ExibirMensagem("s", "Comando enviado com sucesso!");
            else
                ExibirMensagem("e", "Erro ao enviar comando!");

            System.Threading.Thread.Sleep(1500);
            Load();
        }
        protected void CarregarControles(Dispositivo obj)
        {
            String index = "";

            //LIMPANDO CONTROLES
            divVisualizacaoControle.Controls.Clear();
            if (obj != null)
            {
                obj.ObjControle = boControle.BuscarComandosControle(obj.ObjControle);
                List<Historico> objsHistorico = boHistorico.BuscarHistoricoDispositivo(obj);

                //CRIANDO OS CONTROLES PRINCIPAIS
                CriarControlePrincipais(obj.Nome);
                CriarControleNavegacao();
                //CARREGANDO OS HISTORICOS
                if (objsHistorico != null)
                {
                    CarregarEstadoDispositivo(objsHistorico);
                    index = objsHistorico[0].Descricao;
                }

                //CRIANDO CONTROLES DINAMICO
                if (obj != null)
                    if (obj.ObjControle.ObjsComandos != null)
                    {
                        for (int i = 0; i < obj.ObjControle.ObjsComandos.Count; i++)
                            CriarControleDinamico(obj.ObjControle.ObjsComandos[i], index, obj);

                    }
                    else
                    {
                        throw new Exception("Nenhum comando cadastrado!");
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
            divVisualizacaoControle.Controls.Add(btnLink);

            HtmlGenericControl p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            divVisualizacaoControle.Controls.Add(p);

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
            divVisualizacaoControle.Controls.Add(btnLink);

            p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            divVisualizacaoControle.Controls.Add(p);

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
            btnLink.Attributes.Add("href", "WFDispositivo.aspx");
            divVisualizacaoControle.Controls.Add(btnLink);

            p = new HtmlGenericControl("p");
            p.InnerText = @"\";
            p.Attributes.Add("class", "subtitulo");
            divVisualizacaoControle.Controls.Add(p);

            btnLink = new LinkButton();
            try
            {
                btnLink.Text = ((Dispositivo)Session["objDispositivo"]).Nome.ToUpper();
            }
            catch (Exception)
            {
                btnLink.Text = "Dispositivo";
            }
            btnLink.CssClass = "subtitulo";
            btnLink.Enabled = false;
            divVisualizacaoControle.Controls.Add(btnLink);
        }
        protected void CriarControlePrincipais(String titulo)
        {
            //ADICIONADO O TITULO DO CONTROLE
            Label lblTituloUnidade = new Label();
            lblTituloUnidade.CssClass = "titulo";
            lblTituloUnidade.Text = titulo;
            divVisualizacaoControle.Controls.Add(lblTituloUnidade);

            //ADICIONANDO O BOTÃO SAIR
            Button btn = new Button();
            btn.ID = "btnSair";
            btn.CssClass = "btn-touch-sair";
            btn.Text = "X";
            btn.Click += btnSair_Click;
            btn.EnableViewState = true;
            divVisualizacaoControle.Controls.Add(btn);
        }
        protected void CriarControleDinamico(Comando objComano, String porcentagem, Dispositivo objDispositivo)
        {

            if (objComano.Estilo == "btn-touch-nulo")
            {
                Button btn = new Button();
                btn.ID = "btn" + objComano.Id.ToString();
                btn.CssClass = "btn-touch-nulo-disnable";
                btn.Text = objComano.Nome;
                btn.Click += btnSelecionar_Click;
                btn.EnableViewState = true;
                btn.Enabled = false;
                divVisualizacaoControle.Controls.Add(btn);
                Historico objHistorico = new HistoricoBO().BuscarUltimoHistoricoDispositivo(objDispositivo);

                btn.Text = Convertt.ToString(objHistorico.ConsumoEnergia) + " KWH";
            }
            else if ((objComano.Estilo != "range-touch-inteiro"))
            {
                Button btn = new Button();
                btn.ID = "btn" + objComano.Id.ToString();
                btn.CssClass = objComano.Estilo + " " + objComano.Cor;
                btn.Text = objComano.Nome;
                btn.Click += btnSelecionar_Click;
                btn.EnableViewState = true;
                divVisualizacaoControle.Controls.Add(btn);
            }
            else if (objComano.Estilo == "range-touch-inteiro")
            {
                txtRange = new TextBox();
                txtRange.ID = "txt" + objComano.Id.ToString();
                txtRange.CssClass = objComano.Estilo;
                txtRange.Text = objComano.Nome;
                txtRange.TextMode = TextBoxMode.Range;
                txtRange.Text = boControle.ToComandoHistorico(porcentagem);
                txtRange.AutoPostBack = true;
                txtRange.TextChanged += Selecionar_TextChanged;
                divVisualizacaoControle.Controls.Add(txtRange);

                lblValorRange = new Label();
                lblValorRange.Text = txtRange.Text + "%";
                lblValorRange.Attributes.Add("class", "lblrange");
                divVisualizacaoControle.Controls.Add(lblValorRange);
            }
        }
        protected void CarregarEstadoDispositivo(IList<Historico> objs)
        {
            //ADICIONANDO TELA ESTADO
            HyperLink blocoTelaEstado = new HyperLink();
            blocoTelaEstado.Attributes.Add("class", "tela-estado");
            blocoTelaEstado.NavigateUrl = @"WFHistorico.aspx";
            divVisualizacaoControle.Controls.Add(blocoTelaEstado);
            for (int i = 0; i < 3 && objs.Count > i; i++)
            {
                HtmlGenericControl divEstado = new HtmlGenericControl("div");
                if (i == 0)
                    divEstado.Attributes.Add("class", "estado ativo");
                else
                    divEstado.Attributes.Add("class", "estado ativo-vermelho");
                if (objs[i].ObjComando.Estilo == "btn-touch-nulo")
                    divEstado.InnerText = Convertt.ToString(objs[i].ConsumoEnergia) + "KVH";
                else if (objs[i].ObjComando.Estilo == "range-touch-inteiro")
                    divEstado.InnerText = objs[i].Descricao + "%";
                else
                    divEstado.InnerText = objs[i].Descricao;
                blocoTelaEstado.Controls.Add(divEstado);
                HtmlGenericControl pHoraEstado = new HtmlGenericControl("p");
                pHoraEstado.InnerText = Convertt.ToRestanteDias(objs[i].Momento);
                divEstado.Controls.Add(pHoraEstado);
            }

        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }
    }
}