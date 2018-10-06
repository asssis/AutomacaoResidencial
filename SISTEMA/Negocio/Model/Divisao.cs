using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Divisao
    {
        public Divisao()
        {
            ObjUnidade = new Unidade();
        }
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        Unidade objUnidade;
        public Unidade ObjUnidade
        {
            get { return objUnidade; }
            set { objUnidade = value; }
        }
        List<Dispositivo> objsDispositivos;
        public List<Dispositivo> ObjsDispositivos
        {
            get { return objsDispositivos; }
            set { objsDispositivos = value; }
        }

        string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
