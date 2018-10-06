using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Dao;
using Negocio.Model;
namespace Negocio.Bo
{
    public class UnidadeBO
    {
        //VARIAVEIS
         UnidadeDAO daoUnidade;
        UsuarioBO boUsuario;

        //CONSTRUTORES
        public UnidadeBO()
        {
            daoUnidade = new UnidadeDAO();
            boUsuario = new UsuarioBO();
        }
       
        //METODOS PRINCIPAIS
        public string Gravar(Unidade objUnidade)
        {
            return daoUnidade.Gravar(objUnidade);
        }
        public string Alterar(Unidade objUnidade)
        {
             return daoUnidade.Alterar(objUnidade);
        }
        public string Deletar(Unidade objUnidade)
        {
             UnidadeDAO dao = new UnidadeDAO();
             return dao.Deletar(objUnidade);
        }

        //METODOS BUSCAS
        public Unidade BuscarId(int id)
        {
            return daoUnidade.BuscarId(id);
        }
        public Unidade BuscarId(Unidade objUnidade)
        {
            return daoUnidade.BuscarId(objUnidade);
        }
        public List<Unidade> BuscarGeral(string valor)
        {
            return daoUnidade.BuscarTodos(valor);
        }
        public List<Dispositivo> BuscarLeitoresUnidade(Unidade objUnidade)
        {
            objUnidade = BuscarDivisoesUnidade(objUnidade);
            List<Divisao> objsDivisao = objUnidade.ObjsDivisoes;

            List<Dispositivo> objsDispositivo = new List<Dispositivo>();
            DispositivoBO boDispositivo = new DispositivoBO();
            for (int i = 0; i < objsDivisao.Count; i++)
            {
                objsDivisao[i] = boDispositivo.BuscarDispositivosDivisao(objsDivisao[i]);
                if(objsDivisao[i].ObjsDispositivos != null)
                objsDispositivo.AddRange(objsDivisao[i].ObjsDispositivos);
            }

            for (int i = 0; i < objsDispositivo.Count; i++)
            {
                if (objsDispositivo[i].ObjsLeitores == null)
                {
                    objsDispositivo.Remove(objsDispositivo[i]);
                    i--;
                }
            }
            return objsDispositivo;

        }
        public List<Evento> BuscarEventosUnidade(Unidade obj)
        {
           Unidade objUnidade = BuscarDivisoesUnidade(obj);
            List<Divisao> objsDivisao = objUnidade.ObjsDivisoes;

            List<Dispositivo> objsDispositivo = new List<Dispositivo>();
            DispositivoBO boDispositivo = new DispositivoBO();
            for (int i = 0; i < objsDivisao.Count; i++)
            {
                objsDivisao[i] = boDispositivo.BuscarDispositivosDivisao(objsDivisao[i]);
                objsDispositivo.AddRange(objsDivisao[i].ObjsDispositivos);
            }
            List<Evento> objsEventos = new List<Evento>();
            EventoBO boEvento = new EventoBO();
            for (int i = 0; i < objsDispositivo.Count; i++)
            {
                List<Evento> objs = boEvento.BuscaEventoBanco(objsDispositivo[i]);
                if(objs != null)
                    objsEventos.AddRange(objs); 
            }
            return objsEventos;
 
        }
        public Usuario BuscarUnidadesUsuario(Usuario obj)
        {
            return boUsuario.BuscarUnidadesUsuario(obj);
        }
        public Unidade BuscarUnidadeIdBotao(string valor)
        {
            string id = "";
            for (int i = 3; i < valor.Count(); i++)
            {
                id = id + valor[i].ToString();
            }
            return BuscarId(Convert.ToInt32(id));
        }
        public Unidade BuscarDivisoesUnidade(Unidade obj)
        {
            return daoUnidade.BuscarDivisoesUnidade(obj);
        }


        //METODOS VALIDAÇÕES
        public bool ValidarCamposObrigatorio(Unidade obj)
        {
            if (obj.Bairro != "" && obj.Cep != "" && obj.Cidade != "" && obj.Descricao != "" &&  obj.Endereco != "" 
                && obj.Estado != "" &&  obj.Numero != "" &&  obj.Pais != "" && obj.Tempo != 0 &&  obj.ObjUsuario.Id != 0)
                return true;
            else
                return false;
        }
        public bool ValidarMatricula(Unidade obj)
        {
            if (daoUnidade.BuscarId(obj) != null)
                return true;
            else return false;
        }

        public bool VerificarDivisaoUnidade(Unidade obj)
        {
            return daoUnidade.VerificarDivisaoUnidade(obj);
        }

        public bool VerificarUnidadeUsuario(Usuario obj)
        {
            return daoUnidade.VerificarUnidadeUsuario(obj);
        }

    }
}
