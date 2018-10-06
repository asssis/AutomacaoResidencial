using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Dao;
using System.Text.RegularExpressions;

namespace Negocio.Bo
{
    public class UsuarioBO
    {
        //DECLARANDO VARIAVEIS
        UsuarioDAO daoUsuario;

        //METODOS CONSTRUTORES
        public  UsuarioBO()
        {
            daoUsuario = new UsuarioDAO();
        }

        //METODOS PRINCIPAIS
        public string Gravar(Usuario obj)
        {
            return daoUsuario.Gravar(obj);
        }
        public string Alterar(Usuario obj)
        {
            return daoUsuario.Alterar(obj);
        }
        public string Deletar(Usuario obj)
        {
            return daoUsuario.Deletar(obj);
        }

        //METODOS BUSCAS
        public Usuario BuscarId(int id)
        {
            return daoUsuario.BuscarId(id);
        }
        public Usuario BuscarId(Usuario obj)
        {
            return daoUsuario.BuscarId(obj);
        }
        public Usuario BuscarUsuario(Usuario obj)
        {
            return daoUsuario.BuscarId(obj);
        }
        public List<Usuario> BuscarGeral(string valor)
        {
            return daoUsuario.BuscarGeral(valor);
        }
        public List<Usuario> BuscarLogin(string valor)
        {
            return daoUsuario.BuscarGeral(valor);
        }
        public Usuario BuscarUnidadesUsuario(Usuario obj)
        {
            return daoUsuario.BuscarUnidadeUsuario(obj);
        }
        public List<Usuario> BuscarGeralClientes(string valor)
        {
            return daoUsuario.BuscarGeralClientes(valor);
        }

        //METODOS VALIDAÇÕES
        public bool ValidarSenha(string senha1, string senha2)
        {
            if (senha1 == senha2) 
                return true;
            else 
                return false;
        }
        public bool ValidarCamposObrigatorio(Usuario obj)
        {
           if (obj.Nome != "" && obj.Email != "" && obj.Login != "" && obj.CpfCnpj.Count() == 14 &&  obj.Telefone != "" && obj.Nivel != NivelAcesso.NULL)
                return true;
            else
                return false;
        }
        public bool ValidarCpf(Usuario obj)
        {
            if (daoUsuario.BuscarCpf(obj) == null)
                return true;
            else return false;
        }
        public bool ValidarUsuario(Usuario obj)
        {
            if (daoUsuario.BuscarLogin(obj) == null)
                return true;
            else return false;
        }
        public bool ValidarMatricula(Usuario obj)
        {
            if (daoUsuario.BuscarId(obj) != null)
                return true;
            else return false;
        }
        public bool ValidarEmail(string email)
        {
            bool emailValido = false;
            string emailRegex = string.Format("{0}{1}",
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            try
                {emailValido = Regex.IsMatch(email, emailRegex);}
            catch (RegexMatchTimeoutException)
                { emailValido = false; }
            return emailValido;
        }

        //METODOS EXTRAS
        public Usuario Logar(Usuario obj)
        {
            Usuario objUsuario = daoUsuario.BuscarLogin(obj);
            if (obj == null)
                return null;
            if (!objUsuario.Ativacao)
                throw new Exception("Esse usuario está desativado, informe o administrador");
            if (obj.Senha == objUsuario.Senha)
                return objUsuario;
            else
                return null;
        }

        public Unidade LogarUnidade(Usuario objUsuario, Unidade objUnidade)
        {
            Usuario obj = daoUsuario.BuscarLogin(objUsuario);
            UnidadeBO boUnidade = new UnidadeBO();
            if (objUsuario.Senha == obj.Senha)
                for (int i = 0; i < obj.ObjsUnidades.Count; i++)
			    {
                    if (obj.ObjsUnidades[i].Id == objUnidade.Id)
                    {
                        return obj.ObjsUnidades[i];
                    }
			    }

            return null;
        }
    }
}
