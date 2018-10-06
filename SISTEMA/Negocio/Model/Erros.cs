using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Erros
    {
        int id;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        string texto;
        public string Texto
        {
            get
            {
                return texto;
            }

            set
            {
                texto = value;
            }
        }

        string momento;
        public string Momento
        {
            get
            {
                return momento;
            }

            set
            {
                momento = value;
            }
        }

    }
}
