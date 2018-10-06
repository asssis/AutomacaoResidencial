using Negocio.Dao;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Bo
{
    public class DivisaoBO
    {
        //VARIAVEIS
        DivisaoDAO daoDivisao;
        UnidadeBO boUnidade;

        //METODO CONSTRUTOR
        public DivisaoBO()
        {
            daoDivisao = new DivisaoDAO();
            boUnidade = new UnidadeBO();
        }
        //METODOS PRINCIPAIS
        public string Gravar(Divisao objDivisao)
        {
            return daoDivisao.Gravar(objDivisao);
        }
        public string Alterar(Divisao objDivisao)
        {
            return daoDivisao.Alterar(objDivisao);
        }
        public List<Divisao> BuscarTodos()
        {
            return daoDivisao.BuscarTodos();
        }

        public List<Divisao> BuscarGeral(string valor)
        {
            return daoDivisao.BuscarTodos();
        }

        public bool ValidarCamposObrigatorio(Divisao obj)
        {
            if (obj.Descricao != "" && obj.ObjUnidade.Id != 0)
                return true;
            else
                return false;
        }

        public bool ValidarMatricula(Divisao obj)
        {
            if (daoDivisao.BuscarId(obj) != null)
                return true;
            else return false;
        }

        public string Deletar(Divisao objDivisao)
        {
            DivisaoDAO dao = new DivisaoDAO();
            return dao.Deletar(objDivisao);
        }
        public Divisao BuscarId(int valor)
        {
            return daoDivisao.BuscarId(valor);
        }
        public Divisao BuscarId(Divisao objDivisao)
        {
            return daoDivisao.BuscarId(objDivisao);
        }

        public Unidade BuscarDivisoesUnidade(Unidade obj)
        {
            return boUnidade.BuscarDivisoesUnidade(obj);
        }
        public Divisao BuscarDispositivosDivisao(Divisao obj)
        {
            DivisaoDAO daoDivisao = new DivisaoDAO();
            return daoDivisao.BuscarDispositivosDivisao(obj);
        }
        public Divisao BuscarDivisaoIdBotao(string valor)
        {
            string id = "";
            for (int i = 3; i < valor.Count(); i++)
            {
                id = id + valor[i].ToString();
            }
            return daoDivisao.BuscarId(Convert.ToInt32(id));
        }

        public bool VerificarDispositivosDivisao(Divisao obj)
        {
            return daoDivisao.VerificarDispositivosDivisao(obj);
        }
    }
}
