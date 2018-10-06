using Negocio.Dao;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Bo
{
    public class LeitorBO
    {
        //VARIAVEIS
        LeitorDAO daoLeitor;
        UnidadeBO boUnidade;

        //METODO CONSTRUTOR
        public LeitorBO()
        {
            daoLeitor = new LeitorDAO();
            boUnidade = new UnidadeBO();
        }
        
        //METODOS PRINCIPAIS
        public string Gravar(Leitor obj)
        {
            return daoLeitor.Gravar(obj);
        }
        public string Alterar(Leitor obj)
        {
            return daoLeitor.Alterar(obj);
        }
        public List<Leitor> BuscarTodos()
        {
            return daoLeitor.BuscarTodos();
        }
        public List<Leitor> BuscarGeral(string valor)
        {
            return daoLeitor.BuscarTodos();
        }
        public bool ValidarCamposObrigatorio(Leitor obj)
        {
            if (obj.Nome != "" && obj.ObjComando.Id != 0 && obj.ObjDispositivo.Id != 0 && obj.Sensibilidade != 0 && obj.TipoLeitor != TipoLeitor.NULL && obj.Valor != 0)
                return true;
            else
                return false;
        }
        public bool ValidarMatricula(Leitor obj)
        {
            if (daoLeitor.BuscarId(obj) != null)
                return true;
            else return false;
        }
        public string Deletar(Leitor obj)
        {
            return daoLeitor.Deletar(obj);
        }
        public Leitor BuscarId(int valor)
        {
            return daoLeitor.BuscarId(valor);
        }
        public Leitor BuscarId(Leitor obj)
        {
            return daoLeitor.BuscarId(obj);
        }
        public bool ValidarLeitor(Leitor obj)
        {
            if (daoLeitor.BuscarId(obj) != null)
                return true;
            else
                return false;
        }
        public bool ValidarDivisao(Leitor obj)
        {
            return new DivisaoBO().ValidarMatricula(obj.ObjDispositivo.ObjDivisao);
        }
        public List<Leitor> BuscarLeitoresDispositivo(Dispositivo objDispositivo)
        {
            return daoLeitor.BuscarLeitoresDispositivo(objDispositivo);
        }
        public bool VerificarLeitorDispositivo(Dispositivo obj)
        {
            return daoLeitor.VerificarLeitorDispositivo(obj);
        }
    }
}
