using Negocio;
using Negocio.Bo;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeControl.Forms.Tecnico
{
    public partial class WFManterComando : System.Web.UI.Page
    {
        //DECLARANDO VARIAVEIS
        ComandoBO boComando;
        ControleBO boControle;

        //CHAMADAS EVENTOS
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
        protected void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                Novo();
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
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                Pesquisar();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }
        protected void txtMatriculaControle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Changed();
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

        //METODOS PRINCIPAIS
        protected void Load()
        {
            boComando = new ComandoBO();
            boControle = new ControleBO();

            Controle objControle = (Controle)Session["objControle"];
            if(objControle != null)
                if(objControle.Id != 0)
                CarregarControle(objControle);
            if (!IsPostBack)
            {
                PreencherFormulario(objControle);
            }
            else
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ScrollPage", "window.scroll(0,1200);", true);
        }
        protected void Novo()
        {
            PreencherFormulario((Comando)null);
            divCadastrarComando.Attributes.Add("class", "inicio bloco-inteiro");
        }
        protected void Gravar()
        {
            Comando obj = PreecherObjeto();
            if (!boComando.ValidarCamposObrigatorio(obj))
                ExibirMensagem("a","Preencha todos os campos necessario");
            else if(txtMatriculaComando.Text != "")
                ExibirMensagem("s",boComando.Alterar(obj));
            else if(txtMatriculaComando.Text == "")
                ExibirMensagem("s", boComando.Gravar(obj));

            Session["objComando"] = obj;
            PreencherFormulario(obj);
            CarregarControle(obj.ObjControle);
            divCadastrarComando.Attributes.Add("class", "invisible");
        }
        protected void Deletar()
        {
            Comando obj = PreecherObjeto();
            if (!boComando.ValidarComando(obj))
                ExibirMensagem("e", "Comando não encontrado");
            else if (new ComandoBO().VerificarHistoricoComando(obj))
                ExibirMensagem("a", "Solicitação negada, esse comando está sendo utilizada por historicos.");
            else if (new ComandoBO().VerificarEventoComando(obj))
                ExibirMensagem("a", "Solicitação negada, esse comando está sendo utilizada por eventos.");
            else if (new ComandoBO().VerificarLeitorComando(obj))
                ExibirMensagem("a", "Solicitação negada, esse comando está sendo utilizada por leitores.");
            else
            {
                ExibirMensagem("s", boComando.Deletar(obj));
                CarregarControle(null);
                PreencherFormulario((Comando)null);
                divCadastrarComando.Attributes.Add("class", "invisible");
                Load();
            }
        }
        protected void Pesquisar()
        {
            Session["objComando"] = PreecherObjeto();
            Session["Retorno"] = @"~\Forms\Tecnico\WFManterComando.aspx";
            Response.Redirect(@"~\Forms\Tecnico\WFBuscarControle.aspx");
        }
        protected void Changed()
        {
            Controle obj = boControle.BuscarId(Convert.ToInt32(txtMatriculaControle.Text));
                    
            CarregarControle(obj);
            Session["objControle"] = obj;            
            PreencherFormulario(obj);
         }
        protected void Selecionar(object sender)
        {
            Comando obj = new Comando();
            obj = boComando.BuscarComandoIdBotao(((Button)sender).ID);
            if (obj != null)
            {
                divCadastrarComando.Attributes.Add("class", "inicio bloco-inteiro");
                PreencherFormulario(obj);
            }
        }

        //METODOS EXTRAS
        protected void PreencherFormulario(Comando obj)
        {
            if (obj != null)
            {
                txtMatriculaComando.Text = obj.Id.ToString();
                txtComando.Text = obj.Cmd;
                txtNome.Text = obj.Nome;
                ddlBotao.SelectedValue = obj.Estilo;
                ddlCor.SelectedValue = obj.Cor;
            }
            else
            {
                txtMatriculaComando.Text = "";
                txtComando.Text = "";
                txtNome.Text = "";
                ddlBotao.SelectedValue = "";
                ddlCor.SelectedValue = "";
            }
        }
        protected void PreencherFormulario(Controle obj)
        {
            if (obj != null)
            {
                txtMatriculaControle.Text = obj.Id.ToString();
                txtControle.Text = Convertt.ToString(obj.Tipocontrole);
                txtMarca.Text = obj.Marca;
                txtModelo.Text = obj.Modelo;
                txtControle.Text = Convertt.ToString(obj.Tipocontrole);
               
            }
            else
            {
                txtMatriculaControle.Text = "";
                txtControle.Text = "";
                txtMarca.Text = "";
                txtModelo.Text = "";
                txtControle.Text = "";
            }
        }
        protected Comando PreecherObjeto()
        {
            Comando obj = new Comando();
            if (txtMatriculaComando.Text != "")
               obj.Id = Convert.ToInt32(txtMatriculaComando.Text);
            obj.Cmd = txtComando.Text;
            if(txtControle.Text != "")
                obj.ObjControle.Id = Convert.ToInt32(txtMatriculaControle.Text);
            obj.Nome = txtNome.Text;
            obj.Estilo = ddlBotao.SelectedValue;
            if(txtAgua.Text != "")
                obj.ConsumoAgua = Convert.ToInt32(txtAgua.Text);
            if(txtEnergia.Text != "")
                obj.ConsumoEnergia = Convert.ToInt32(txtEnergia.Text);
            obj.Cor = Convert.ToString(ddlCor.SelectedValue);
            return obj;
        }
        protected void CarregarControle(Controle obj)
        {
            if (obj != null)
            {
                obj.ObjsComandos = boComando.BuscarComandoControle(obj);
                divVisualizacaoControle.Controls.Clear();

                Label lblTituloControle= new Label();
                lblTituloControle.CssClass = "titulo";
                lblTituloControle.Text = obj.Modelo;
                divVisualizacaoControle.Controls.Add(lblTituloControle);

                if (obj != null)
                    if(obj.ObjsComandos != null)
                    for (int i = 0; i < obj.ObjsComandos.Count; i++)
                    {
                        if (obj.ObjsComandos[i].Estilo != "range-touch-inteiro")
                        {
                            Button btn = new Button();
                            btn.ID = "btn" + obj.ObjsComandos[i].Id.ToString();
                            btn.CssClass = obj.ObjsComandos[i].Cor + " " + obj.ObjsComandos[i].Estilo;
                            btn.Text = obj.ObjsComandos[i].Nome;
                            btn.Click += btnSelecionar_Click;
                            btn.EnableViewState = true;
                            divVisualizacaoControle.Controls.Add(btn);
                        }
                        else if (obj.ObjsComandos[i].Estilo == "range-touch-inteiro")
                        {
                            TextBox range = new TextBox();
                            range.ID = "txt" + obj.ObjsComandos[i].Id.ToString();
                            range.CssClass = obj.ObjsComandos[i].Estilo + " btn-range-margin";
                            range.TextMode = TextBoxMode.Range;
                            range.Enabled = false;
                            Button btn = new Button();
                            btn.ID = "btn" + obj.ObjsComandos[i].Id.ToString();

                            btn.CssClass = "btn-selecionar-range";
                            btn.Text = obj.ObjsComandos[i].Nome;
                            btn.Click += btnSelecionar_Click;
                            btn.Text = "SELECIONAR";
                            btn.EnableViewState = true;
                            divVisualizacaoControle.Controls.Add(range);
                            divVisualizacaoControle.Controls.Add(btn);
                        }
                    }
                if (obj != null)
                {
                    divPreVisualizacao.Attributes.Add("class", " inicio bloco-inteiro tela-preta");
                }
                else
                    divPreVisualizacao.Attributes.Add("class", "invisible");
            }
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }

    }
}