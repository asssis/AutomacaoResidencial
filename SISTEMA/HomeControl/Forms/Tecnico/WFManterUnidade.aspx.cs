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
    public partial class WFManterUnidade : System.Web.UI.Page
    {
        UnidadeBO boUnidade;
        UsuarioBO boUsuario;
        //TESTE
        //EVENTOS PRINCIPAIS
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Load();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", "Erro :" + msn.Message);
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
                ExibirMensagem("e", "Erro :" + msn.Message);
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
                ExibirMensagem("e", "Erro :" + msn.Message);
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
                ExibirMensagem("e", "Erro :" + msn.Message);
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
                ExibirMensagem("e", "Erro :" + msn.Message);
            }
        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisarUsuario();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", "Erro :" + msn.Message);
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
                ExibirMensagem("e", "Erro " + msn.Message);
            }
        }

        //METODOS PRINCIPAIS
        protected void Load()
        {
            boUnidade = new UnidadeBO();
            boUsuario = new UsuarioBO();

            Usuario objUsuario = (Usuario)Session["objUsuario"];
            Unidade objUnidade = (Unidade)Session["objUnidade"];

            if (!IsPostBack)
            {
                PreencherFormulario(objUnidade);
                if (objUsuario != null)
                    PreencherUsuario(objUsuario);
            }
            Session["objUnidade"] = RecuperarObjeto();
           
        }
        protected void Novo()
        {
            PreencherUnidade(null);
        }
        protected void Gravar()
        {
            //FAZENDO INSTANCIA DAS CLASSES
            UnidadeBO bo = new UnidadeBO();
            Unidade obj = RecuperarObjeto();

            //VALIDANDO OS CAMPOS OBRIGATORIOS
            if (!bo.ValidarCamposObrigatorio(obj))
                 ExibirMensagem("a", "Preencha todos os campos necessarios");
            //VERIFICANDO SE O USUARIO EXISTE PARA FAZER ALTERAÇÃO
            else if (txtMatricula.Text != "" && !bo.ValidarMatricula(obj))
                ExibirMensagem("e", "Usuario não encontrado para fazer alteração");
            //FAZENDO ALTERAÇÃO
            else if (txtMatricula.Text != "" && bo.ValidarMatricula(obj))
                 ExibirMensagem("s", bo.Alterar(obj));
            //FAZENDO GRAVAÇÃO
            else if (txtMatricula.Text == "")
                ExibirMensagem("s", bo.Gravar(obj));

            Session["objUnidade"] = obj;
            PreencherFormulario(obj);
        }
        protected void Deletar()
        {
            //FAZENDO INSTANCIA DAS CLASSES
            UnidadeBO bo = new UnidadeBO();
            Unidade obj = RecuperarObjeto();

            if (!bo.ValidarMatricula(obj))
                ExibirMensagem("e", "Usuario não encontrado");
            else if (new UnidadeBO().VerificarDivisaoUnidade(obj))
                ExibirMensagem("a","Solicitação negada, essa unidade está sendo utilizada pela divisão.");
            else
                ExibirMensagem("s", bo.Deletar(RecuperarObjeto()));
        }
        protected void Buscar()
        {
            Session["objUnidade"] = RecuperarObjeto();
            Session["Retorno"] = @"~/Forms/Tecnico/WFManterUnidade.aspx";
            Response.Redirect(@"~/Forms/Tecnico/WFBuscarUnidade.aspx");
        }
        protected void Changed()
        {
            Unidade obj = RecuperarObjeto();

            if(txtMatriculaUsuario.Text != "")
                obj.ObjUsuario = boUsuario.BuscarId(Convertt.ToInt32(txtMatriculaUsuario.Text));
             PreencherFormulario(obj);
        }
        protected void PesquisarUsuario()
        {
            Session["objUnidade"] = RecuperarObjeto();
            Session["Retorno"] = @"~\Forms\Tecnico\WFManterUnidade.aspx";
            Response.Redirect(@"~\Forms\Tecnico\WFBuscarUsuario.aspx");
        }

        //PREECHIMENTO DO FORMULARIO
        protected void PreencherFormulario(Unidade obj)
        {
            if (obj != null)
            {
                PreencherUnidade(obj);
                PreencherUsuario(obj.ObjUsuario);
            }
            else
            {
                PreencherUnidade(null);
                PreencherUsuario(null);
            }
           Session["objUnidade"] =  RecuperarObjeto();
        }
        protected void PreencherUnidade(Unidade obj)
        {
            if (obj != null)
            {
                if (obj.Id != 0)
                    txtMatricula.Text = Convert.ToString(obj.Id);
                txtDescricao.Text = obj.Descricao;
                txtEstado.Text = obj.Estado;
                txtEndereco.Text = obj.Endereco;
                txtPais.Text = obj.Pais;
                txtCidade.Text = obj.Cidade;
                ddlTempo.Text = obj.Tempo.ToString();
                txtNumero.Text = obj.Numero;
                txtBairro.Text = obj.Bairro;
                txtCep.Text = obj.Cep;
            }
            else
            {
                txtMatricula.Text = "";
                txtDescricao.Text = "";
                txtEstado.Text = "";
                txtEndereco.Text = "";
                txtPais.Text = "";
                txtCidade.Text = "";
                ddlTempo.Text = "";
                txtNumero.Text = "";
                txtBairro.Text = "";
                txtCep.Text = "";
            }
        }
        protected void PreencherUsuario(Usuario obj)
        {
            if (obj != null)
            {
                if (obj.Id != 0)
                    txtMatriculaUsuario.Text = Convert.ToString(obj.Id);
                txtNome.Text = obj.Nome;
                txtCpfCnpj.Text = obj.CpfCnpj;
                txtEmail.Text = obj.Email;
                txtTelefone.Text = obj.Telefone;
            }
            else
            {
                txtMatriculaUsuario.Text = "";
                txtNome.Text = "";
                txtCpfCnpj.Text = "";
                txtEmail.Text = "";
                txtTelefone.Text = "";
            }
        }

        //PREECHIMENTO DO OBJETO
        protected Unidade RecuperarObjeto()
        {
            Unidade obj = new Unidade();
            
            if(txtMatricula.Text != "")
                obj.Id = Convert.ToInt32(txtMatricula.Text);
            obj.Descricao = txtDescricao.Text;
            if (ddlTempo.Text != "")
                obj.Tempo = Convert.ToInt32(ddlTempo.Text);
            obj.Bairro = txtBairro.Text;
            obj.Endereco = txtEndereco.Text;
            obj.Cidade = txtCidade.Text;
            obj.Estado = txtEstado.Text;
            obj.Numero = txtNumero.Text;
            obj.Pais = txtPais.Text;
            obj.Cep = txtCep.Text;

            if(txtMatriculaUsuario.Text != "")
                obj.ObjUsuario = boUsuario.BuscarId(Convert.ToInt32(txtMatriculaUsuario.Text));
            return obj;
        }

        //METODOS EXTRAS
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }
    }
}