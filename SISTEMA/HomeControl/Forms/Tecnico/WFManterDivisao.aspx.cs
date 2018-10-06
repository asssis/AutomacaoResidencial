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
    public partial class WFManterDivisao : System.Web.UI.Page
    {
        //VARIAVEIS
        DivisaoBO boDivisao;
        UnidadeBO boUnidade;

        //CHAMADA METODOS
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
        protected void txtMatricula_TextChanged(object sender, EventArgs e)
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
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisarUnidade();
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
            boUnidade = new UnidadeBO();

            Unidade objUnidade = (Unidade)Session["objUnidade"];
            Divisao objDivisao = (Divisao)Session["objDivisao"];

            if (!IsPostBack)
            {
                PreencherFormulario(objDivisao);
                if (objUnidade != null)
                    PreencherUnidade(objUnidade);
            }
            else
            {
                Session["objDivisao"] = RecuperarObjeto();
            }
        }
        protected void Novo()
        {
            PreecherDivisao(null);
        }
        protected void Gravar()
        {
            //FAZENDO INSTANCIA DAS CLASSES
            DivisaoBO bo = new DivisaoBO();
            Divisao obj = RecuperarObjeto();

            //VALIDANDO OS CAMPOS OBRIGATORIOS
            if (!bo.ValidarCamposObrigatorio(obj))
                ExibirMensagem("a", "Preencha todos os campos necessarios");
            //VERIFICANDO SE O USUARIO EXISTE PARA FAZER ALTERAÇÃO
            else if (txtMatricula.Text != "" && !bo.ValidarMatricula(obj))
                ExibirMensagem("e", "Divisao não encontrado para fazer alteração");
            //FAZENDO ALTERAÇÃO
            else if (txtMatricula.Text != "" && bo.ValidarMatricula(obj))
                ExibirMensagem("s", bo.Alterar(obj));
            //FAZENDO GRAVAÇÃO
            else if (txtMatricula.Text == "")
                ExibirMensagem("s", bo.Gravar(obj));

            Session["objDivisao"] = obj;
            PreencherFormulario(obj);
        }
        protected void Deletar()
        {
            //FAZENDO INSTANCIA DAS CLASSES
            DivisaoBO bo = new DivisaoBO();
            Divisao obj = RecuperarObjeto();

            if (!bo.ValidarMatricula(obj))
                ExibirMensagem("e", "Divisão não encontrado");
            else if(new DivisaoBO().VerificarDispositivosDivisao(obj))
                ExibirMensagem("a", "Solicitação negada, essa divisão está sendo utilizada por dispositivos.");
            else
                ExibirMensagem("s", bo.Deletar(RecuperarObjeto()));
        }
        protected void Buscar()
        {
            Session["objDivisao"] = RecuperarObjeto();
            Session["Retorno"] = @"~/Forms/Tecnico/WFManterDivisao.aspx";
            Response.Redirect(@"~/Forms/Tecnico/WFBuscarDivisao.aspx");
        }
        protected void Changed()
        {
            Unidade objUnidade = boUnidade.BuscarId(Convert.ToInt32(txtUnidade.Text));

            Divisao obj = new Divisao();
            obj.ObjUnidade = objUnidade;
            PreencherFormulario(obj); if(obj!= null)
                PreencherFormulario(obj);
            else
                PreencherFormulario(null);
        }
        protected void PesquisarUnidade()
        {
            Session["objDivisao"] = RecuperarObjeto();
            Session["Retorno"] = @"~\Forms\Tecnico\WFManterDivisao.aspx";
            Response.Redirect(@"~\Forms\Tecnico\WFBuscarUnidade.aspx");
        }

        //PREENCHIMENTO DO FORMULARIO
        private void PreencherFormulario(Divisao obj)
        {
            if (obj != null)
            {
                PreecherDivisao(obj);
                PreencherUnidade(obj.ObjUnidade);
            }
            else
            {
                PreecherDivisao(null);
                PreencherUnidade(null);
            }
            Session["objDivissao"] = RecuperarObjeto();
        }
        private void PreencherUnidade(Unidade obj)
        {
            if (obj!= null)
            {
                if (obj.Id != 0)
                    txtUnidade.Text = obj.Id.ToString();
                txtCidade.Text = obj.Cidade;
                txtDescricaoUnidade.Text = obj.Descricao;
                txtEndereco.Text = obj.Endereco;
                txtEstado.Text = obj.Estado;
                txtCep.Text = obj.Cep;
                txtBairro.Text = obj.Bairro;
                txtNumero.Text = obj.Numero;
            }
            else
            {
                txtUnidade.Text = "";
                txtCidade.Text = "";
                txtDescricaoUnidade.Text = "";
                txtEndereco.Text = "";
                txtEstado.Text = "";
                txtCep.Text = "";
                txtBairro.Text = "";
                txtNumero.Text = "";
            }
        }
        private void PreecherDivisao(Divisao obj)
        {
            if (obj != null)
            {
                if (obj.Id != 0)
                    txtMatricula.Text = Convert.ToString(obj.Id);
                txtDescricao.Text = obj.Descricao;
            }
            else
            {
                txtMatricula.Text = "";
                txtDescricao.Text = "";
            }
        }

        //PREECHIMENTO OBJETO
        private Divisao RecuperarObjeto()
        {
            Divisao obj = new Divisao();
            if (txtMatricula.Text != "")
                obj.Id = Convert.ToInt32(txtMatricula.Text);
            obj.Descricao = txtDescricao.Text;

            UnidadeBO bo = new UnidadeBO();
            if (txtUnidade.Text != "")
                obj.ObjUnidade = bo.BuscarId(Convert.ToInt32(txtUnidade.Text));

            return obj;
        }

        private void LimparDivisao()
        {
            txtMatricula.Text = "";
            txtDescricao.Text = "";
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }

      
    }
}