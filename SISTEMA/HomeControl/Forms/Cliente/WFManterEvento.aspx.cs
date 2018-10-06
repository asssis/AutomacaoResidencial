using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Negocio.Model;
using Negocio.Bo;
using Negocio;

namespace HomeControl.Forms.Cliente
{
    public partial class WFManterEvento : System.Web.UI.Page
    {
        //DECLARANDO  VARIAVEIS
        ControleBO boControle;
        EventoBO boEvento;
        List<RadioButton> objsRadioButton;
        TextBox txtRange;
        Label lblValorRange;

        //CHAMADO DE EVENTOS
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
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Gravar();
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
            boEvento = new EventoBO();
            Evento objEvento = (Evento)Session["objEvento"];

            if (objEvento != null)
                CarregarControles(objEvento);
            else
                Response.Redirect(@"~\Forms\Cliente\WFDivisao.aspx");
        }
        protected void Gravar()
        {
            EventoBO bo = new EventoBO();
            Evento obj = PreencherObjeto();
            if (!bo.ValidarAgendamento(obj))
                ExibirMensagem("e", "Preencha todos os campos corretamente");
            else if (hfIdEvento.Value == "")
                ExibirMensagem("s", bo.GravarEventoBanco(obj));
            else if (!boEvento.ValidarEvento(obj))
                Response.Redirect(@"~Forms\Cliente\WFBuscarEvento.aspx");
            else
                ExibirMensagem("s", bo.AlterarEventoBanco(obj));
        }

        private void Deletar()
        {
            //FAZENDO INSTANCIA DAS CLASSES
            EventoBO bo = new EventoBO();
            Evento obj = new Evento();
            obj.Id = Convert.ToInt32(hfIdEvento.Value);

            if (!bo.ValidarMatricula(obj))
                ExibirMensagem("e", "Usuario não encontrado");
            else
                ExibirMensagem("s", bo.Deletar(obj));

        }
        protected void CarregarControles(Evento objEvento)
        {
            divVisualizacaoAgendamento.Controls.Clear();
            if (objEvento.ObjDispositvo.ObjControle != null)
            {
                CriarControlesDinamicos(objEvento);
            }
            if (objEvento != null && !IsPostBack)
                CarregarInformacoesAgendada(objEvento);
            if (txtHora.Text != "")
                txtHora.Focus();

        }
        protected void Sair()
        {
            Session.Remove("objAutenticacao");
            Response.Redirect(@"~\Forms\WFLogin.aspx");
        }

        //METODOS EXTRAS
        protected void CarregarInformacoesAgendada(Evento obj)
        {
            if (obj.ObjAgenda.Hora != TimeSpan.Parse("0"))
                txtHora.Text = Convertt.ToString(obj.ObjAgenda.Hora);
            chDom.Checked = obj.ObjAgenda.Domingo;
            chSeg.Checked = obj.ObjAgenda.Sexta;
            chTer.Checked = obj.ObjAgenda.Terca;
            chQua.Checked = obj.ObjAgenda.Quarta;
            chQui.Checked = obj.ObjAgenda.Quinta;
            chSex.Checked = obj.ObjAgenda.Sexta;
            chSab.Checked = obj.ObjAgenda.Sabado;
            if (obj.Id != 0)
                hfIdEvento.Value = obj.Id.ToString();
            if (obj.ObjAgenda.Id != 0)
                hfIdAgenda.Value = obj.ObjAgenda.Id.ToString();
            if (obj.ObjDispositvo.Id != 0)
                hfIdDispositivo.Value = obj.ObjDispositvo.Id.ToString();
        }
        protected void CriarControlesDinamicos(Evento objEvento)
        {
            ControleBO boControle = new ControleBO();
            txtRange = new TextBox();
            objsRadioButton = new List<RadioButton>();
            Controle objControle = boControle.BuscarComandosControle(objEvento.ObjDispositvo.ObjControle);
            for (int i = 0; i < objControle.ObjsComandos.Count; i++)
            {

                if (objControle.ObjsComandos[i].Estilo == "btn-touch-nulo")
                {
                    btnGravar.Enabled = false;
                    ExibirMensagem("a", "Esse dispositivo não pode ter agendamento");
                }
                else if (objControle.ObjsComandos[i].Estilo != "range-touch-inteiro")
                {
                    HtmlGenericControl divComando = new HtmlGenericControl("div");
                    divComando.Attributes.Add("class", "divchcomando");
                    divVisualizacaoAgendamento.Controls.Add(divComando);

                    HtmlGenericControl pComando = new HtmlGenericControl("p");
                    pComando.InnerText = objControle.ObjsComandos[i].Nome;
                    divComando.Controls.Add(pComando);

                    RadioButton rb = new RadioButton();
                    rb.ID = "rdb" + objControle.ObjsComandos[i].Id;
                    rb.GroupName = "rbComando";
                    divComando.Controls.Add(rb);
                    objsRadioButton.Add(rb);
                    if (objEvento != null)
                        if (objControle.ObjsComandos[i].Id == objEvento.ObjComando.Id)
                            rb.Checked = true;
                        else
                            rb.Checked = false;
                }
                else if (objControle.ObjsComandos[i].Estilo == "range-touch-inteiro")
                {
                    TextBox range = new TextBox();
                    range.ID = "txt" + objControle.ObjsComandos[i].Id.ToString();
                    range.CssClass = objControle.ObjsComandos[i].Estilo;
                    range.Text = objControle.ObjsComandos[i].Cmd;
                    range.TextMode = TextBoxMode.Range;
                    range.TextChanged += range_TextChanged;
                    range.AutoPostBack = true;
                    txtRange = range;
                    divVisualizacaoAgendamento.Controls.Add(range);
                    lblValorRange = new Label();
                    lblValorRange.Text = txtRange.Text + "%";
                    lblValorRange.Attributes.Add("class", "lblrange");
                    divVisualizacaoAgendamento.Controls.Add(lblValorRange);
                }
            }
        }
        void range_TextChanged(object sender, EventArgs e)
        {
            lblValorRange.Text = txtRange.Text + "%";
        }

        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }
        protected Evento PreencherObjeto()
        {
            Evento objEvento = new Evento();
            ComandoBO boComando = new ComandoBO();
            objEvento.ObjAgenda.Hora = Convertt.ToTimeSpan(txtHora.Text);
            objEvento.ObjAgenda.Domingo = chDom.Checked;
            objEvento.ObjAgenda.Segunda = chSeg.Checked;
            objEvento.ObjAgenda.Terca = chTer.Checked;
            objEvento.ObjAgenda.Quarta = chQua.Checked;
            objEvento.ObjAgenda.Quinta = chQui.Checked;
            objEvento.ObjAgenda.Sexta = chSex.Checked;
            objEvento.ObjAgenda.Sabado = chSab.Checked;
            if (txtRange.Text != "")
                objEvento.Potencia = Convertt.ToString(txtRange.Text);
            if (hfIdEvento.Value != "")
                objEvento.Id = Convert.ToInt32(hfIdEvento.Value);
            if (hfIdAgenda.Value != "")
                objEvento.ObjAgenda.Id = Convert.ToInt32(hfIdAgenda.Value);
            if (hfIdDispositivo.Value != "")
                objEvento.ObjDispositvo.Id = Convert.ToInt32(hfIdDispositivo.Value);
            for (int i = 0; i < objsRadioButton.Count; i++)
                if (objsRadioButton[i].Checked == true)
                    objEvento.ObjComando = boComando.BuscarComandoIdBotao(objsRadioButton[i].ID);

            return objEvento;
        }


    }
}