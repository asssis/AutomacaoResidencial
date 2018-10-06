using System;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Security;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
namespace Monitoramento.Negocio
{
    public class Conexao
    {

        public static List<SerialPort> portas;
        public static string PortName;
        public Conexao(string portName)
        {
            if (portas == null)
                portas = new List<SerialPort>();
            PortName = portName;
        }
        public static SerialPort Conectar()
        {
            for (int i = 0; i < portas.Count; i++)
                if (portas[i].PortName == PortName)
                {
                    if (portas[i].IsOpen)
                        return portas[i];
                    else
                    {
                        portas[i] = ResetarPorta();
                    }
                }

            if (!VerificarPorta(PortName))
                throw new Exception("Porta, " + PortName + " não encontrado");
            SerialPort porta = new SerialPort(PortName);
            porta.ReadTimeout = 400;
            try
            {
                porta.Open();
            }
            catch
            {
                return null;
            }
            portas.Add(porta);
            return porta;
        }

        public static string TestarPorta()
        {
            bool condicao = false;
            if (portas != null)
                for (int i = 0; i < portas.Count; i++)
                {
                   
                    Conexao con = new Conexao(portas[i].PortName);
                    if ("00t" != con.Leitura("000t"))
                    {
                        for (int ii = 0; ii < 3;)
                        {
                            string msn = con.Leitura("000t");
                            if ("00t" != msn)
                                ii++;
                            else if(msn == "00t")
                                ii = 4;
                            if (ii == 3)
                                portas[i].Close();
                        }
                    }
                }
            if (condicao)
                return "FECHANDO PORTA";
            else
                return "";
        }

        public static bool VerificarPorta(string porta)
        {
            string[] portas = SerialPort.GetPortNames();
            for (int i = 0; i < portas.Count(); i++)
            {
                if (portas[i] == porta) return true;
            }
            return false;
        }
        public string Leitura(string leitura)
        {
            SerialPort porta = Conectar();
            try
            {
                string cmd = "";
                porta.Write(leitura);
                cmd = porta.ReadLine();
                cmd = Convertt.ToValorS(cmd);
                return cmd;
            }
            catch
            {
                return "";
            }
        }
        public void Enviar(string cmd)
        {
            SerialPort porta = Conectar();
            porta.Write(cmd);
        }
        public static SerialPort ResetarPorta()
        {
            SerialPort porta = new SerialPort();
            for (int i = 0; i < portas.Count; i++)
                if (portas[i].PortName == PortName)
                {
                    PortName = portas[i].PortName;
                    portas[i].Close();
                    portas[i].Dispose();
                    portas.Remove(portas[i]);
                }

            for (int i = 0; i < 5; i++)
            {
                if (VerificarPorta(PortName))
                    throw new Exception("Porta não encontrada " + PortName);
                try
                {
                    Thread.Sleep(100);
                    porta = new SerialPort(PortName);
                    porta.ReadTimeout = 400;
                    porta.Open();
                    portas.Add(porta);
                    return porta;
                }
                catch
                {
                    porta.Close();
                    porta.Dispose();
                    porta = null;
                    PortHelper.TryResetPortByInstanceId(PortName);
                    if (PortName == "COM5")
                        PortHelper.TryResetPortByInstanceId(@"USB\VID_1A86&PID_7523\6&25E52265&0&3");
                }
            }
            throw new Exception("O sistema não conseguiu comunicar com a porta " + PortName + ", tente reiniciar o computador!");
        }


    }
}
