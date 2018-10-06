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
    public partial class WFManterDispositivo : System.Web.UI.Page
    {       
        //DECLARANDO VARIAVEIS
        DispositivoBO boDispositivo;
        DivisaoBO boDivisao;
        ControleBO boControle;

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
        protected void btnPesquisarControle_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisarControle();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }
        protected void btnPesquisarDivisao_Click(object sender, EventArgs e)
        {
            try
            {
               PesquisarDivisao();
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
        protected void txtMatriculaDivisao_TextChanged(object sender, EventArgs e)
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

        //METODOS PRINCIPAIS
        protected void Load()
        {
            boDispositivo = new DispositivoBO();
            boDivisao = new DivisaoBO();
            boControle = new ControleBO();

            Divisao objDivisao = (Divisao)Session["objDivisao"];
            Controle objControle = (Controle)Session["objControle"];
            Dispositivo objDispositivo = (Dispositivo)Session["objDispositivo"];

            if (!IsPostBack)
            {
                PreecherFormulario(objDispositivo);
                if (objDivisao != null)
                    PreecherDivisao(objDivisao);
                if (objControle != null)
                    PreecherControle(objControle);
            }
            else
                Session["objDispositivo"] = RecuperarObjeto();
        }
        protected void Novo()
        {
            PreecherDispositivo(null);
        }
        protected void Gravar()
        {
            //FAZENDO INSTANCIA DAS CLASSES
            DispositivoBO bo = new DispositivoBO();
            Dispositivo obj = RecuperarObjeto();

            //VALIDANDO OS CAMPOS OBRIGATORIO
            if (!bo.ValidarCamposObrigatorio(obj))
                ExibirMensagem("a", "Preencha todos os campos necessarios");
            //VALIDANDO AS SENHAS
            else if (!bo.ValidarControle(obj))
                ExibirMensagem("a", "Controle não encontrado");
            //FAZENDO ALTERAÇÃO
            else if (txtMatricula.Text != "" && !bo.ValidarMatricula(obj))
                ExibirMensagem("a", "Divisão não encontrado");
            //VALIDANDO CPF
            else if (txtMatricula.Text != "" && bo.ValidarMatricula(obj))
                ExibirMensagem("s", bo.Alterar(obj));
            //VALIDANDO LOGIN
            else if (txtMatricula.Text == "")
                ExibirMensagem("s", bo.Gravar(obj));

            Session["objDispositivo"] = obj;
            PreecherFormulario(obj);
        }
        protected void Deletar()
        {
            Dispositivo obj = RecuperarObjeto();
            if (!boDispositivo.ValidarDispositivo(obj))
                ExibirMensagem("e", "Dispositivo não encontrado");
            else if (new LeitorBO().VerificarLeitorDispositivo(obj))
                ExibirMensagem("a","Solicitação negada, esse dispositivo está sendo utilizado por leitor!");
            else if (new EventoBO().VerificarEventoDispositivo(obj))
                ExibirMensagem("a", "Solicitação negada, esse dispositivo está sendo utilizado por evento!");
            else if (new HistoricoBO().VerificarHistoricoDispositivo(obj))
                ExibirMensagem("a", "Solicitação negada, esse dispositivo está sendo utilizado por historico!");
            else
                ExibirMensagem("s", boDispositivo.Deletar(obj));
        }
        protected void Buscar()
        {
            Session["objDispositivo"] = RecuperarObjeto();
            Session["Retorno"] = @"~/Forms/Tecnico/WFManterDispositivo.aspx";
            Response.Redirect(@"~/Forms/Tecnico/WFBuscarDispositivo.aspx");
        }
        protected void Changed()
        {
            Dispositivo obj = RecuperarObjeto();
            if (obj != null)
            {
                if (obj.ObjDivisao.Id != 0)
                    obj = boDispositivo.BuscarDivisao(obj);
                if (obj != null)
                    PreecherFormulario(obj);
                else
                    PreecherFormulario(null);
                if (obj.ObjControle.Id != 0)
                    obj = boDispositivo.BuscarControle(obj);
                if (obj != null)
                    PreecherFormulario(obj);
                else
                    PreecherFormulario(null);
            }
        }
        protected void PesquisarControle()
        {
            Session["objDispositivo"] = RecuperarObjeto();
            Session["Retorno"] = @"~\Forms\Tecnico\WFManterDispositivo.aspx";
            Response.Redirect(@"~\Forms\Tecnico\WFBuscarControle.aspx");
        }
        protected void PesquisarDivisao()
        {
            Session["objDispositivo"] = RecuperarObjeto();
            Session["Retorno"] = @"~\Forms\Tecnico\WFManterDispositivo.aspx";
            Response.Redirect(@"~\Forms\Tecnico\WFBuscarDivisao.aspx");
        }

        //PREECHIMENTO DO FORMULARIO
        private void PreecherFormulario(Dispositivo obj)
        {
            if (obj != null)
            {
                PreecherDispositivo(obj);
                PreecherControle(obj.ObjControle);
                PreecherDivisao(obj.ObjDivisao);                
            }
            else
            {
                PreecherControle(null);
                PreecherDispositivo(null);
                PreecherDivisao(null);
            }
            Session["objDispositivo"] = RecuperarObjeto();
        }
        protected void PreecherControle(Controle obj)
        {
            if (obj != null)
            {
                txtControle.Text = Convertt.ToString(obj.Tipocontrole);
                txtEquipamento.Text = obj.Equipamento;
                txtMarca.Text = obj.Marca;
                if (obj.Id != 0)
                    txtMatriculaControle.Text = Convert.ToString(obj.Id);
                txtModelo.Text = obj.Modelo;
            }
            else
            {

                txtControle.Text = "";
                txtEquipamento.Text = "";
                txtMarca.Text = "";
                txtMatriculaControle.Text = "";
                txtModelo.Text = "";
            }
        }
        protected void PreecherDispositivo(Dispositivo obj)
        {
            if (obj != null)
            {
                if (obj.Id != 0)
                    txtMatricula.Text = obj.Id.ToString();
                txtNome.Text = obj.Nome;
                if (obj.PinoEntrada != 0)
                    ddlPinoEntrada.Text = Convert.ToString(obj.PinoEntrada);
                ddlPorta.Text = obj.Porta;
            }
            else
            {
                txtMatricula.Text = "";
                txtNome.Text = "";
                ddlPinoEntrada.Text = "";
                ddlPorta.Text = "";
            }
        }
        protected void PreecherDivisao(Divisao obj)
        {
            if (obj != null)
            {
                if (obj.Id != 0)
                    txtMatriculaDivisao.Text = Convert.ToString(obj.Id);
                txtDescricao.Text = Convert.ToString(obj.Descricao);
            }
            else
            {
                txtMatriculaDivisao.Text = "";
                txtDescricao.Text = "";
            }
        }

        //PREENCHIMENTO DO OBJETO
        private Dispositivo RecuperarObjeto()
        {
            Dispositivo obj = new Dispositivo();
            if (txtMatricula.Text != "")
                obj.Id = Convert.ToInt32(txtMatricula.Text);
            obj.Nome = txtNome.Text;
            if (ddlPinoEntrada.Text != "")
            obj.PinoEntrada = Convert.ToInt32(ddlPinoEntrada.Text);
            obj.Porta = ddlPorta.Text;

            if (txtMatriculaDivisao.Text != "")
                obj.ObjDivisao = boDivisao.BuscarId( Convert.ToInt32(txtMatriculaDivisao.Text));
            if (txtMatriculaControle.Text != "")
                obj.ObjControle = boControle.BuscarId(Convert.ToInt32(txtMatriculaControle.Text));

            return obj;
        }

        //METODOS EXTRAS
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }      
    }
}