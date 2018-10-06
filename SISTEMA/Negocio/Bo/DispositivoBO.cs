using Negocio.Dao;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Negocio.Bo
{
    public class DispositivoBO
    {
        //DECLARANDO VARIAVEIS
        DispositivoDAO daoDispositivo;
        DivisaoBO boDivisao;
        ControleBO boControle;

        //METODO CONSTRUTOR
        public DispositivoBO()
        {
            daoDispositivo = new DispositivoDAO();
            boDivisao = new DivisaoBO();
            boControle = new ControleBO();
        }

        //METODOS PRINCIPAIS
        public string Gravar(Dispositivo obj)
        {
            return daoDispositivo.Gravar(obj);
        }
        public string Alterar(Dispositivo obj)
        {
            return daoDispositivo.Alterar(obj);
        }
        public string Deletar(Dispositivo obj)
        {
            return daoDispositivo.Deletar(obj);
        }

        //METODOS DE BUSCAS
        public Dispositivo BuscarId(Dispositivo objDispositivo)
        {
            return daoDispositivo.BuscarId(objDispositivo);
        }
        public Dispositivo BuscarId(int valor)
        {
            return daoDispositivo.BuscarId(valor);
        }
        public List<Dispositivo> BuscarTodos()
        {
            return daoDispositivo.BuscarTodos();
        }
        public Dispositivo BuscarDivisao(Dispositivo obj)
        {
            obj.ObjDivisao =  boDivisao.BuscarId(obj.ObjDivisao.Id);
            return obj;
        }
        public Dispositivo BuscarControle(Dispositivo obj)
        {
            obj.ObjControle = boControle.BuscarId(obj.ObjControle.Id);
            return obj;
        }

        //FAZENDO VALIDAÇÕES
        public bool ValidarCamposObrigatorio(Dispositivo obj)
        {
            if (obj.Nome != "" && obj.Porta != "" && obj.ObjControle.Id != 0 && obj.ObjDivisao.Id != 0 && obj.PinoEntrada != 0)
                return true;
            else
                return false;
        }
        public bool ValidarControle(Dispositivo obj)
        {
            ControleBO bo = new ControleBO();
            if (bo.BuscarId(obj.ObjControle) != null)
                return true;
            else
                return false;
        }
        public bool ValidarMatricula(Dispositivo obj)
        {
            if (daoDispositivo.BuscarId(obj) != null)
                return true;
            else
                return false;
        }  
        public bool ValidarDispositivo(Dispositivo obj)
        {
            DispositivoBO bo = new DispositivoBO();
            if (bo.BuscarId(obj) != null)
                return true;
            else
                return false;
        }
        public List<Dispositivo> BuscarGeral(string valor)
        {
           return daoDispositivo.BuscarTodos();
        }
        public Divisao BuscarDispositivosDivisao(Divisao obj)
        {
            DivisaoBO boDivisao = new DivisaoBO();
            return boDivisao.BuscarDispositivosDivisao(obj);
        }

        public Dispositivo BuscarDispositivoIdBotao(string valor)
        {
            string id = "";
            for (int i = 3; i < valor.Count(); i++)
            {
                id = id + valor[i].ToString();
            }
            return daoDispositivo.BuscarId(Convert.ToInt32(id));
        }
    }
}
