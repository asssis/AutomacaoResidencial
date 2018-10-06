using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitoramento.webHomeControl;

namespace Monitoramento
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            iniciar();
        }
        public static void iniciar()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmLogin frmMonitorar = new frmLogin();
                frmMonitorar.ShowDialog();
                if (objUnidade != null)
                    Application.Run(new frmMonitorar());
            }
            catch (Exception msn)
            {
                MessageBox.Show("Erro, faça login novamente!");
                iniciar();
            }
        }
        public static Unidade objUnidade;
    }
}
