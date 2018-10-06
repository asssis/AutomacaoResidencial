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
    public partial class WFManterControle : System.Web.UI.Page
    {
        //DECLARANDO VARIAVEIS
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
        
        //METODOS PRICIPAIS
        protected void Load()
        {
            boControle = new ControleBO();
            Controle objControle = (Controle)Session["objControle"];

            if (!IsPostBack)
            {
                PreencherFormulario(objControle);
            }
            else
                Session["objControle"] = RecuperarObjeto();
        }
        protected void Novo()
        {
            PreecherControle(null);
        }
        protected void Gravar()
        {
            Controle obj = RecuperarObjeto();
            if (!boControle.ValidarCamposObrigatorio(obj))
                ExibirMensagem("a", "Preencha todos os campos obrigatorio!");
            else if (txtMatricula.Text == "")
                ExibirMensagem("s", boControle.Gravar(obj));
            else if (!boControle.ValidarControle(obj))
                ExibirMensagem("e", "Controle não foi encontrado");
            else if (txtMatricula.Text != "")
                ExibirMensagem("s", boControle.Alterar(obj));

            Session["objControle"] = obj;
            PreencherFormulario(obj);
        }
        protected void Deletar()
        {
            Controle obj = RecuperarObjeto();
            if (!boControle.ValidarControle(obj))
                ExibirMensagem("e","Controle não encontrado");
            else if (new ControleBO().VerificarDispositivoControle(obj))
                ExibirMensagem("a", "Solicitação negada, esse controle está sendo utilizada por dispositivo.");
            else if (new ControleBO().VerificarComandoControle(obj))
                ExibirMensagem("a", "Solicitação negada, esse controle está sendo utilizada por comando.");
            else
                ExibirMensagem("s", boControle.Deletar(RecuperarObjeto()));
        }
        protected void Buscar()
        {
            Session["Retorno"] = @"~\Forms\Tecnico\WFManterControle.aspx";
            Response.Redirect(@"~\Forms\Tecnico\WFBuscarControle.aspx");
        }

        //PREECHER OBJETO
        protected void PreencherFormulario(Controle obj)
        {
            if (obj != null)
            {
                PreecherControle(obj);
            }
            else
            {
                PreecherControle(null);
            }
            Session["objControle"] = RecuperarObjeto();
        }
        protected void PreecherControle(Controle obj)
        {
            if (obj != null)
            {
                if (obj.Id != 0)
                    txtMatricula.Text = Convert.ToString(obj.Id);
                ddlEquipamento.Text = obj.Equipamento;
                txtMarca.Text = obj.Marca;
                txtModelo.Text = obj.Modelo;
                ddlControle.Text = Convertt.ToString(obj.Tipocontrole);
            }
            else
            {
                txtMatricula.Text = "";
                ddlEquipamento.Text = "";
                txtMarca.Text = "";
                txtModelo.Text = "";
                ddlControle.Text = "";
            }
        }

        //PREECHER FORMULARIO
        protected Controle RecuperarObjeto()
        {
            Controle objControle = new Controle();
            if (txtMatricula.Text != "" && txtMatricula.Text != "0")
                objControle.Id = Convert.ToInt32(txtMatricula.Text);
            objControle.Equipamento = ddlEquipamento.Text;
            objControle.Marca = txtMarca.Text;
            objControle.Modelo = txtModelo.Text;
            objControle.Tipocontrole = Convertt.ToTipoControle(ddlControle.Text);
            return objControle;
        }

        //METODOS EXTRAS
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }
    }
}