using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Monitoramento.webHomeControl;
using Monitoramento.Negocio;

namespace Monitoramento
{
    public partial class frmMonitorar : Form
    {
        //VARIAVEIS
        public static int tensao = 110;
        // tempo padrão 500
        int tempo = 200;
        //METODO CONSTRUTOR
        public frmMonitorar()
        {
            InitializeComponent();
            CarregarConfiguracoesIniciar();
        }

        //VARIAVEIS
        bool monitorar = false;
        private Unidade objUnidade;
        public static List<Dispositivo> objsDispositivo;
        public static List<Evento> objsEventos;
        public static List<string> objPorts;
        //EVENTOS PRINCIPAIS
        private void btnMonitorar_Click(object sender, EventArgs e)
        {
            if (monitorar == false)
            {
                monitorar = true;
                btnMonitorar.Text = "Parar";
            }
            else
            {
                monitorar = false;
                btnMonitorar.Text = "Iniciar";
            }
            try
            {
                Thread processoMonitoramento = new Thread(IniciarMonitoria);
                processoMonitoramento.Start();

                Thread processoEvento = new Thread(IniciarVerificarEvento);
                processoEvento.Start();

            }
            catch (Exception)
            {
                MessageBox.Show("Erro, inicia novamente");
            }
        }
        public static int erro = 0;
        //METODOS DE MONITORIA
        public void PreencherPortas()
        {
            if (ckbPortas.InvokeRequired)
            {
                ckbPortas.Invoke(
                  new ThreadStart(delegate
                  {
                      string[] portas = SerialPort.GetPortNames();
                      for (int i = 0; i < portas.Count(); i++)
                      {
                          if (!PesquisarCheckBoxPorta(portas[i].ToString()))
                              ckbPortas.Items.Add(portas[i]);
                      }
                      for (int i = 0; i < ckbPortas.Items.Count; i++)
                      {
                          if (!Conexao.VerificarPorta(ckbPortas.Items[i].ToString()))
                              ckbPortas.Items.RemoveAt(i);
                      }
                  }));
            }
            else
            {
                string[] portas = SerialPort.GetPortNames();
                for (int i = 0; i < portas.Count(); i++)
                {
                    if (!PesquisarCheckBoxPorta(portas[i].ToString()))
                        ckbPortas.Items.Add(portas[i]);
                }
                for (int i = 0; i < ckbPortas.Items.Count; i++)
                {
                    if (!Conexao.VerificarPorta(ckbPortas.Items[i].ToString()))
                        ckbPortas.Items.RemoveAt(i);
                }
            }
            for (int i = 0; i < ckbPortas.Items.Count; i++)
            {
                if (ckbPortas.GetItemChecked(i))
                {
                    Conexao con = new Conexao(ckbPortas.Items[i].ToString());
                    string msn = con.Leitura("9");
                    if (msn != "")
                    {
                        Mensagem(msn);
                        SendKeys.SendWait(msn);
                        SendKeys.SendWait("{ENTER}");
                    }
                }

            }
        }
        public bool PesquisarCheckBoxPorta(string valor)
        {
            for (int i = 0; i < ckbPortas.Items.Count; i++)
            {
                if (ckbPortas.Items[i].ToString() == valor)
                    return true;
            }
            return false;
        }
        System.TimeSpan hora;
        public void BuscarEvento()
        {
            System.TimeSpan hora_atual = System.TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            Double segundos_corrido = hora_atual.Subtract(hora).TotalSeconds;
            if (segundos_corrido >= objUnidade.Tempo)
            {
                hora = hora_atual;
                Mensagem(VerificarEvento());
            }
        }
        public void IniciarVerificarEvento()
        {

            if (monitorar)
                Mensagem("Iniciando");
            while (monitorar)
            {
                try
                {
                    Sinal();
                    Mensagem(VerificarEvento());
                    if (!monitorar)
                        Mensagem("Parando");
                }
                catch (Exception msn)
                {
                    Mensagem(msn.Message);
                }
            }
        }

        public void IniciarMonitoria()
        {
            
            while (monitorar)
            {
                try
                {
                    int tem = objUnidade.Tempo * (tempo + tempo);
                    Thread.Sleep(tem);
                    Mensagem(Conexao.TestarPorta());
                    PreencherPortas();
                    IniciarRelogio();
                    Mensagem(FazerLeitura());
                }
                catch (Exception msn)
                {
                    Mensagem(msn.Message);
                }
            }
        }

        public void IniciarTestePorta()
        {

            if (monitorar)
            while (monitorar)
            {
                try
                {
                    Mensagem(Conexao.TestarPorta());
                }
                catch (Exception msn)
                {
                    Mensagem(msn.Message);
                }
            }
        }
        public void CarregarConfiguracoesIniciar()
        {
            objUnidade = Program.objUnidade;
            Program.objUnidade = null;
            Monitorar boMonitor = new Monitorar();
            PreencherFormulario();
            BuscarInformacoesAdicionais();
        }
        public void BuscarInformacoesAdicionais()
        {
            webHomeControlSoapClient webService = new webHomeControlSoapClient();

            Dispositivo[] objsDisp = null;
            try
            {
                objsDisp = webService.BuscarLeitoresUnidade(objUnidade);
            }
            catch (Exception)
            {

            }
            Evento[] objsEve = webService.BuscarEventoBanco(objUnidade);
            objsDispositivo = new List<Dispositivo>();
            objsEventos = new List<Evento>();
            if (objsDisp != null)
                for (int i = 0; i < objsDisp.Count(); i++)
                    objsDispositivo.Add(objsDisp[i]);
            if (objsEve != null)
                for (int i = 0; i < objsEve.Count(); i++)
                    objsEventos.Add(objsEve[i]);

        }
        private List<string> FazerLeitura()
        {
            Monitorar boMonitorar = new Monitorar();
            List<string> objsResultado = new List<string>();

            for (int i = 0; i < objsDispositivo.Count(); i++)
            {
                List<string> msns = boMonitorar.LeituraDispositivo(objsDispositivo[i]);
                if (msns != null)
                    objsResultado.AddRange(msns);
            }
            return objsResultado;
        }
        private string VerificarEvento()
        {
            Sinal();
            Unidade obj = objUnidade;
            Monitorar boMonitorar = new Monitorar();
            return boMonitorar.VerificarEvento(objUnidade);
        }
        private void IniciarRelogio()
        {
            try
            {
                for (int i = 0; i < objsEventos.Count(); i++)
                {
                    bool resultado = ConferirAgenda(objsEventos[i].ObjAgenda);
                    if (resultado == true)
                        Mensagem("AGEND. " + Monitorar.EfetuarEvento(objsEventos[i]));
                }
            }
            catch (Exception msn)
            {
                Mensagem(msn.Message);
            }

        }
        static string _Hora;
        public bool ConferirAgenda(Agenda objAgenda)
        {
            string hora = objAgenda.HoraToString;
            string Hora = DateTime.Now.ToString("HH:mm");
            if (hora == Hora && objsEventos != null && Hora != _Hora)
            {
                _Hora = Hora;
                int sem = (int)DateTime.Now.DayOfWeek;
                switch (sem)
                {
                    case 0:
                        if (objAgenda.Domingo == true)
                            return true;
                        else
                            return false;
                    case 1:
                        if (objAgenda.Segunda == true)
                            return true;
                        else
                            return false;
                    case 2:
                        if (objAgenda.Terca == true)
                            return true;
                        else
                            return false;
                    case 3:
                        if (objAgenda.Quarta == true)
                            return true;
                        else
                            return false;
                    case 4:
                        if (objAgenda.Quinta == true)
                            return true;
                        else
                            return false;
                    case 5:
                        if (objAgenda.Sexta == true)
                            return true;
                        else
                            return false;
                    case 6:
                        if (objAgenda.Sabado == true)
                            return true;
                        else
                            return false;
                    default:
                        return false;
                }
            }
            return false;
        }
        //METODOS EXTRAS
        public void Sinal()
        {
            Thread.Sleep(objUnidade.Tempo * tempo);
            if (picMonitora.InvokeRequired)
            {
                picMonitora.Invoke(
                  new ThreadStart(delegate
                  {
                      picMonitora.Image = global::Monitoramento.Properties.Resources.Monitorando_ligado;
                  }));
            }
            else
            {
                this.picMonitora.Image = global::Monitoramento.Properties.Resources.Monitorando_ligado;
            }
            Thread.Sleep(objUnidade.Tempo * tempo);
            if (picMonitora.InvokeRequired)
            {
                picMonitora.Invoke(
                  new ThreadStart(delegate
                  {
                      picMonitora.Image = global::Monitoramento.Properties.Resources.Monitorando_desligado;
                  }));
            }
            else
            {
                this.picMonitora.Image = global::Monitoramento.Properties.Resources.Monitorando_desligado;
            }
            if (lblHora.InvokeRequired)
            {
                lblHora.Invoke(
                  new ThreadStart(delegate
                  {
                      lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
                  }));
            }
            else
            {
                lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            }
        }
        public void Mensagem(string msn)
        {
            if (msn != "")
                if (lbxComando.InvokeRequired)
                {
                    lbxComando.Invoke(
                      new ThreadStart(delegate
                      {
                          lbxComando.Items.Add(msn);
                          lbxComando.SelectedIndex = lbxComando.Items.Count - 1;
                      }));
                }
                else
                {
                    lbxComando.Items.Add(msn);
                    lbxComando.SelectedIndex = lbxComando.Items.Count - 1;
                }
        }
        public void Mensagem(List<string> valor)
        {
            if (valor != null)
                for (int i = 0; i < valor.Count; i++)
                    Mensagem(valor[i]);
        }
        public void PreencherFormulario()
        {
            txtBairro.Text = objUnidade.Bairro;
            txtEndereco.Text = objUnidade.Endereco;
            txtUsuario.Text = objUnidade.ObjUsuario.Nome;
            txtNumero.Text = objUnidade.Numero;
        }

        private void frmMonitorar_FormClosing(object sender, FormClosingEventArgs e)
        {
            monitorar = false;
        }

        private void cbTensao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTensao.Text == "110 V")
            {
                tensao = 110;
            }
            else if (cbTensao.Text == "220 V")
            {
                tensao = 220;
            }
        }
    }

}
