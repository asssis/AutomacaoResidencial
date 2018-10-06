using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Dispositivo
    {
        public Dispositivo()
        {
            ObjDivisao = new Divisao();
            ObjControle = new Controle();
        }
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        Divisao objDivisao;
        public Divisao ObjDivisao
        {
            get { return objDivisao; }
            set { objDivisao = value; }
        }

        Controle objControle;
        public Controle ObjControle
        {
            get { return objControle; }
            set { objControle = value; }
        }

        List<Leitor> objsLeitores;
        public List<Leitor> ObjsLeitores
        {
            get { return objsLeitores; }
            set { objsLeitores = value; }
        }

        List<Evento> objsEventos;
        public List<Evento> ObjsEventos
        {
            get { return objsEventos; }
            set { objsEventos = value; }
        }

        string porta;
        public string Porta
        {
            get { return porta; }
            set { porta = value; }
        }

        int pinoEntrada;
        public int PinoEntrada
        {
            get { return pinoEntrada; }
            set { pinoEntrada = value; }
        }
    }
}
