using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitoramento.webHomeControl;

namespace Monitoramento
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public bool logarSistema()
        {
            this.ShowDialog();
            return true;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Entrar();
        }
        private void Entrar()
        {
            try
            {
                webHomeControlSoapClient webService = new webHomeControlSoapClient();
                Usuario objUsuario = new Usuario();
                objUsuario.Login = txtLogin.Text;
                objUsuario.Senha = txtSenha.Text;

                Unidade objUnidade = new Unidade();
                objUnidade.Id = Convert.ToInt32(txtUnidade.Text);
                Program.objUnidade = webService.LogarUnidade(objUsuario, objUnidade);
                if (Program.objUnidade != null)
                    Close();
                else
                    MessageBox.Show("Falha na autetnicação tente novamente");
            }
            catch (Exception)
            {
                MessageBox.Show("Falha na autetnicação tente novamente");
            }
          
        }
    }
}
