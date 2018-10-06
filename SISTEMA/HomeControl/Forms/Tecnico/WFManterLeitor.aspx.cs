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
    public partial class WFManterLeitor : System.Web.UI.Page
    {  
        //DECLARANDO VARIAVEIS
        LeitorBO boLeitor;
        ComandoBO boComando;
        DispositivoBO boDispositivo;

        //CHAMADA EVENTOS
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
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar();
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
        protected void btnPesquisarDispositivo_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisarDispositivo();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }
        protected void btnPesquisarComando_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisarComando();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", "Erro " + msn.Message);
            }
        }
        protected void txtMatricula_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Changed();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e",msn.Message);
            }
        }
        //METODOS PRINCIPAIS
        protected void Load()
        {
            boComando = new ComandoBO();
            boDispositivo = new DispositivoBO();
            boLeitor = new LeitorBO();


            Leitor objLeitor = (Leitor)Session["objLeitor"];
            Dispositivo objDispositivo = (Dispositivo)Session["objDispositivo"];
            Comando objComando = (Comando)Session["objComando"];
            
            if (!IsPostBack)
            {
                PreecherFormulario(objLeitor);
                if (objDispositivo != null)
                    PreecherDispositivo(objDispositivo);

                if (objComando != null)
                    PreecherComando(objComando);
            }
            else
                Session["objLeitor"] = RecuperarObjeto();
        }
        protected void Novo()
        {
            PreecherLeitor(null);
        }
        protected void Gravar()
        {
            //FAZENDO INSTANCIA DAS CLASSES
            LeitorBO bo = new LeitorBO();
            Leitor obj = RecuperarObjeto();

            //VALIDANDO OS CAMPOS OBRIGATORIO
            if (!bo.ValidarCamposObrigatorio(obj))
                ExibirMensagem("a", "Preencha todos os campos necessarios");
            //VALIDANDO AS SENHAS
            else if (!boDispositivo.ValidarDispositivo(obj.ObjDispositivo))
                ExibirMensagem("a", "Dispositivo não encontrado");
            //FAZENDO ALTERAÇÃO
            else if (txtMatricula.Text != "" && !bo.ValidarDivisao(obj))
                ExibirMensagem("a", "Divisão não encontrado");
            //VALIDANDO LEITOR
            else if (txtMatricula.Text != "" && !bo.ValidarMatricula(obj))
                ExibirMensagem("a", "Leitor não encontrado");
            //VALIDANDO CPF
            else if (txtMatricula.Text != "" && bo.ValidarMatricula(obj))
                ExibirMensagem("s", bo.Alterar(obj));
            //VALIDANDO LOGIN
            else if (txtMatricula.Text == "")
                ExibirMensagem("s", bo.Gravar(obj));

            Session["objLeitor"] = obj;
            PreecherFormulario(obj);
        }
        protected void Deletar()
        {
            Leitor obj = RecuperarObjeto();
            if (!boLeitor.ValidarLeitor(obj))
                ExibirMensagem("e", "Dispositivo não encontrado");
            else
                ExibirMensagem("s", boLeitor.Deletar(obj));
        }
        protected void Buscar()
        {
            Session["objLeitor"] = RecuperarObjeto();
            Session["Retorno"] = @"~/Forms/Tecnico/WFManterLeitor.aspx";
            Response.Redirect(@"~/Forms/Tecnico/WFBuscarLeitor.aspx");
        }
        protected void Changed()
        {
            Leitor obj = RecuperarObjeto();
            if (obj != null)
            {
                if (obj.ObjDispositivo.Id != 0)
                    obj.ObjDispositivo = boDispositivo.BuscarId(obj.ObjDispositivo);
                if (obj != null)
                    PreecherFormulario(obj);
                else
                    PreecherFormulario(null);
            }
        }
        protected void PesquisarComando()
        {
            ControleBO boControle = new ControleBO();
            Leitor obj = RecuperarObjeto();
            if (obj.ObjDispositivo.Id != 0)
            {
                Session["objControle"] = boDispositivo.BuscarControle(obj.ObjDispositivo).ObjControle;
                Session["objLeitor"] = obj;
                Session["Retorno"] = @"~\Forms\Tecnico\WFManterLeitor.aspx";
                Response.Redirect(@"~\Forms\Tecnico\WFBuscarComando.aspx");
            }
            else
            {
                ExibirMensagem("a", "O dispositivo não foi preenchido");
            }
        }
        protected void PesquisarDispositivo()
        {
            Session["objLeitor"] = RecuperarObjeto();
            Session["Retorno"] = @"~\Forms\Tecnico\WFManterLeitor.aspx";
            Response.Redirect(@"~\Forms\Tecnico\WFBuscarDispositivo.aspx");
        }

        //PREECHIMENTO DO FORMULARIO
        private void PreecherFormulario(Leitor obj)
        {
            if (obj != null)
            {
                PreecherDispositivo(obj.ObjDispositivo);
                PreecherLeitor(obj);
                PreecherComando(obj.ObjComando);
            }
            else
            {
                PreecherLeitor(null);
                PreecherDispositivo(null);
                PreecherComando(null);
            }
            Session["objLeitor"] = RecuperarObjeto();
        }
        protected void PreecherLeitor(Leitor obj)
        {
            if (obj != null)
            {
                if (obj.Id != 0)
                    txtMatricula.Text = obj.Id.ToString();
                txtNome.Text = obj.Nome;
                if(obj.Valor != 0)
                    txtValor.Text = Convert.ToString(obj.Valor);
                ddlCondicao.Text = Convertt.ToString(obj.Condicao);
                ddlTipoLeitor.Text = Convertt.ToString(obj.TipoLeitor);
                ddlPinoSaida.Text = Convertt.ToString(obj.PinoSaida);
                ddlPorta.Text = Convertt.ToString(obj.Porta);
                if(obj.Sensibilidade != 0)
                    txtSensibilidade.Text = Convertt.ToString(obj.Sensibilidade);
            }
            else
            {

                txtMatricula.Text = "";
                txtNome.Text = "";
                txtValor.Text = "";
                ddlCondicao.Text = "";
                txtSensibilidade.Text = "";
                ddlPorta.Text = "";
                ddlPinoSaida.Text = "";
                ddlTipoLeitor.Text = "";
            }
        }
        protected void PreecherDispositivo(Dispositivo obj)
        {
            if (obj != null)
            {
                if (obj.Id != 0)
                    txtMatriculaDispositivo.Text = Convert.ToString(obj.Id);
                txtNomeDispositivo.Text = obj.Nome;
            }
            else
            {
                txtNomeComando.Text = "";
                txtNomeDispositivo.Text = "";
            }
        }
        protected void PreecherComando(Comando obj)
        {
            if (obj != null)
            {
                if (obj.Id != 0)
                    txtMatriculaComando.Text = Convert.ToString(obj.Id);
                txtNomeComando.Text = Convertt.ToString(obj.Nome);
            }
            else
            {
                txtMatriculaComando.Text = "";
                txtNomeDispositivo.Text = "";
            }
        }

        //PREENCHIMENTO DO OBJETO
        private Leitor RecuperarObjeto()
        {
            Leitor obj = new Leitor();
            if (txtMatricula.Text != "")
                obj.Id = Convert.ToInt32(txtMatricula.Text);
            obj.Nome = txtNome.Text;
            if(txtSensibilidade.Text != "")
            obj.Sensibilidade = Convert.ToDecimal(txtSensibilidade.Text);
            obj.TipoLeitor = Convertt.ToTipoLeitor(ddlTipoLeitor.Text);
            obj.Condicao = Convertt.ToCondicao(ddlCondicao.Text);
        
            obj.PinoSaida = Convertt.ToInt32 (ddlPinoSaida.Text);
            obj.Porta = Convert.ToString(ddlPorta.Text);
            if(txtValor.Text != "")
            obj.Valor = Convert.ToDecimal(txtValor.Text);

            if (txtMatriculaDispositivo.Text != "")
                obj.ObjDispositivo = boDispositivo.BuscarId(Convert.ToInt32(txtMatriculaDispositivo.Text));
            if (txtMatriculaComando.Text != "")
                obj.ObjComando = boComando.BuscarId(Convert.ToInt32(txtMatriculaComando.Text));

            return obj;
        }

        //METODOS EXTRAS
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }
    }
}