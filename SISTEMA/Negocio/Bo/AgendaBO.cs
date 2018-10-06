using Negocio.Dao;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Bo
{
    public class AgendaBO
    {
        AgendaDAO daoAgenda;
        public AgendaBO()
        {
            daoAgenda = new AgendaDAO();
        }

        public int Gravar(Agenda obj)
        {
            return daoAgenda.Gravar(obj);
        }
        public string Alterar(Agenda obj)
        {
            return daoAgenda.Alterar(obj);
        }
        public void Deletar(Agenda obj)
        {
             daoAgenda.Deletar(obj);
        }

        public Agenda BuscarId(int valor)
        {
           return daoAgenda.BuscarId(valor);
        }
        public Agenda BuscarId(Agenda obj)
        {
            return daoAgenda.BuscarId(obj);
        }
    }
}
