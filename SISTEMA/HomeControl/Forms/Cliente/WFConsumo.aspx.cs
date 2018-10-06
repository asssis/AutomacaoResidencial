using Negocio;
using Negocio.Bo;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeControl.Forms.Cliente
{
    public partial class WFConsumo : System.Web.UI.Page
    {
        //DECLARANDO VARIAVEIS
        Dispositivo objDispositivo;
        HistoricoBO boHistorico;

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
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar(Convertt.ToDateTime(DateTime.Now));
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }
        protected void btnProximo_Click(object sender, EventArgs e)
        {
            try
            {
                Proximo();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e", msn.Message);
            }
        }
        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                Anterior();
            }
            catch (Exception msn)
            {
                ExibirMensagem("e",msn.Message);
            }
        }

        //METODOS PRINCIPAIS
        protected void Load()
        {
            objDispositivo = (Dispositivo)Session["objDispositivo"];
            boHistorico = new HistoricoBO();
            if (!IsPostBack)
            {
                hfDia.Value = DateTime.Now.ToString("dd/MM/yyyy");
                Buscar(DateTime.Now);
            }
            CriarControleNavegacao();
        }
        protected void Buscar(DateTime data)
        {
            if (btnBuscar.Text == "ÁGUA")
            {
                btnBuscar.Text = "ENERGIA";
            }
            else
            {
                btnBuscar.Text = "ÁGUA";
            }
            PreecherGrafico(data);
        }
        protected void Anterior()
        {
            DateTime data = Convertt.ToDateTime(hfDia.Value).AddDays(-7);
            hfDia.Value = Convertt.ToString(data);
            PreecherGrafico(data);
            MostrarPeriodo();
        }
        protected void Proximo()
        {
            DateTime data = Convertt.ToDateTime(hfDia.Value).AddDays(7);
            hfDia.Value = Convertt.ToString(data);
            PreecherGrafico(data);
            MostrarPeriodo();
        }

        //METODOS EXTRAS
        protected void CriarControleNavegacao()
        {

            lkbHome.Attributes.Add("href", "WFUnidade.aspx");
            lkbHome.Text = "HOME";

            lkbUnidade.Attributes.Add("href", "WFDivisao.aspx");
            try
            {
                lkbUnidade.Text = ((Unidade)Session["objUnidade"]).Descricao.ToUpper();
            }
            catch (Exception)
            {
                lkbUnidade.Text = "UNIDADE";
            }

            lkbDivisao.Attributes.Add("href", "WFDispositivo.aspx");
            try
            {
                lkbDivisao.Text = ((Divisao)Session["objDivisao"]).Descricao.ToUpper();
            }
            catch (Exception)
            {
                lkbDivisao.Text = "DIVISÃO";
            }
            lkbDispositivo.Attributes.Add("href", "WFControle.aspx");

            try
            {
                lkbDispositivo.Text = ((Dispositivo)Session["objDispositivo"]).Nome.ToUpper();
            }
            catch (Exception)
            {
                lkbDispositivo.Text = "DISPOSITIVO";
            }
        }

        protected void PreecherGrafico(DateTime data)
        {
          
            if (btnBuscar.Text == "ÁGUA")
            {
                MostrarPeriodo();
                lblTitulo.Text = "CONSUMO DE ENERGIA";
                DataSource(boHistorico.ConstruirGraficoEnergiaDispositivo(objDispositivo, data));
            }
            else
            {
                MostrarPeriodo();
                lblTitulo.Text = "CONSUMO DE ÁGUA";
                DataSource(boHistorico.ConstruirGraficoAguaDispositivo(objDispositivo, data));

            }
        }
        protected void DataSource(string[,] dados)
        {

            StringBuilder consumo = new StringBuilder();
            try
            {
                grafConsumo.Controls.Clear();
                for (int i = 0; i < 7; i++)
                {
                    //0 nome
                    //1 valor da coluna
                    //2 tamanho da coluna
                    HtmlGenericControl nome = new HtmlGenericControl("p");
                    nome.InnerText = dados[0, i];
                    HtmlGenericControl coluna = new HtmlGenericControl("div");
                    coluna.InnerText = dados[1, i];
                    coluna.Style.Add("width", dados[2, i]);
                    grafConsumo.Controls.Add(nome);
                    grafConsumo.Controls.Add(coluna);
                }
                if (btnBuscar.Text == "ÁGUA")
                {
                    consumo.Append("CONSUMO ENERGIA ");
                    consumo.Append(boHistorico.CalcularTotal(dados));
                    consumo.Append("KWH");
                }
                else
                {
                    consumo.Append("CONSUMO ÁGUA ");
                    consumo.Append(boHistorico.CalcularTotal(dados));
                    consumo.Append("L");
                }


            }
            catch (Exception)
            {
            }
            lblRecurso.Text = consumo.ToString() ;
        }
        private void MostrarPeriodo()
        {
           DateTime Dia = boHistorico.BuscarPrimeiroDia(Convert.ToDateTime(hfDia.Value));
            StringBuilder periodo = new StringBuilder();
            periodo.Append(Dia.ToString("MMMM"));
            periodo.Append(" de ");
            periodo.Append(Dia.ToString("yyyy"));
            lblSubTitulo.Text = periodo.ToString().ToUpper();
           
        }
        protected void ExibirMensagem(string atencao, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "exibir_msn('" + atencao + "','" + mensagem + "');", true);
        }

       
    }
}