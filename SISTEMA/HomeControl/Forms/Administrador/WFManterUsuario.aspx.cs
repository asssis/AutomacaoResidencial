using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Model;
using Negocio.Bo;
using Negocio;


namespace HomeControl.Forms.Administrador
{
    public partial class WFManterUsuario : System.Web.UI.Page
    {

        //DECLARANDO VARIAVEIS
        UsuarioBO boUsuario;

        //CHAMADA EVENTOS
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

        //METODOS PRINCIPAIS
        protected void Load()
        {
            boUsuario = new UsuarioBO();
            if(!IsPostBack)
                PreencherFormulario((Usuario)Session["objUsuario"]);
            else
                Session["objUsuario"] = PreecherObjeto();
        }
        protected void Novo()
        {
            PreencherFormulario(null);
        }
        protected void Gravar()
        {
            //PREENCHENDO VALORES DO OBJETO
            Usuario obj = PreecherObjeto();

            //VALIDANDO OS CAMPOS OBRIGATORIO
            if (!boUsuario.ValidarCamposObrigatorio(obj))
                ExibirMensagem("a", "Preencha todos os campos necessarios");
            //VALIDANDO AS SENHAS
            else if (!boUsuario.ValidarSenha(txtSenha.Text, txtRepitaSenha.Text))
                ExibirMensagem("a", "As senhas não coencidem");
            else if (!boUsuario.ValidarEmail(txtEmail.Text))
                ExibirMensagem("a", "Email inválido");
            //FAZENDO ALTERAÇÃO
            else if (txtUsuario.Text != "")
                ExibirMensagem("s", boUsuario.Alterar(obj));
            //VALIDANDO CPF
            else if (!boUsuario.ValidarCpf(obj))
                ExibirMensagem("a", "Esse cpf já existe no sistema");
            //VALIDANDO LOGIN
            else if (!boUsuario.ValidarUsuario(obj))
                ExibirMensagem("a", "Esse login já existe no sistema");
            //FAZENDO GRAVAÇÃO
            else if (txtUsuario.Text == "")
                ExibirMensagem("s", boUsuario.Gravar(obj));


            Session["objUsuario"] = obj;
            PreencherFormulario(obj);
        }
        protected void Deletar()
        {
            //PREENCHEDO VALORES DO OBJETO
            Usuario obj = PreecherObjeto();

            //VALIDANDO USUARIO
            if (!boUsuario.ValidarMatricula(obj))
                ExibirMensagem("e", "Usuario não encontrado");
            else if (new UnidadeBO().VerificarUnidadeUsuario(obj))
                ExibirMensagem("a", "Solicitação negada, esse usuario está sendo utilizado por dispositivo.");
            else
                ExibirMensagem("s", boUsuario.Deletar(PreecherObjeto()));
        }
        protected void Buscar()
        {
            Session["Retorno"] = @"~\Forms\Administrador\WFManterUsuario.aspx";
            Response.Redirect(@"~\Forms\Administrador\WFBuscarUsuario.aspx");
        }

        //METODOS EXTRAS
        protected void PreencherFormulario(Usuario objUsuario)
        {
            if (objUsuario != null)
            {
                txtNome.Text = objUsuario.Nome;
                txtEmail.Text = objUsuario.Email;
                txtLogin.Text = objUsuario.Login;
                ddlEstado.Text = Convertt.ToStringAtivacao(objUsuario.Ativacao);
                txtSenha.Text = objUsuario.Senha;
                txtCpfCnpj.Text = objUsuario.CpfCnpj;
                txtTelefone.Text = objUsuario.Telefone;
                if (objUsuario.Id != 0)
                    txtUsuario.Text = objUsuario.Id.ToString();
                ddlNivel.Text = Convertt.ToString(objUsuario.Nivel);
                ddlEstado.Text = Convertt.ToString(objUsuario.Ativacao);
            }
            else
            {
                txtNome.Text = "";
                txtEmail.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtCpfCnpj.Text = "";
                txtTelefone.Text = "";
                txtUsuario.Text = "";
                ddlEstado.Text = "";
                ddlNivel.Text = "";
            }
        }
        protected Usuario PreecherObjeto()
        {
            Usuario obj = new Usuario();
            obj.Nome = txtNome.Text;
            obj.Login = txtLogin.Text;
            obj.Senha = txtSenha.Text;
            obj.Telefone = txtTelefone.Text;
            obj.Email = txtEmail.Text;
            obj.CpfCnpj = txtCpfCnpj.Text;
            obj.Nivel = Convertt.ToNivelAcesso(ddlNivel.Text);
            obj.Ativacao = Convertt.ToAtivacao(ddlEstado.Text);
            if (txtUsuario.Text != "")
                obj.Id = Convert.ToInt32(txtUsuario.Text);
            return obj;
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }
    }
}