using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Usuario
    {
        //CONSTRUTORES
        public Usuario()
        {
        }
        public Usuario(List<Unidade> objsUnidades)
        {
            ObjsUnidades = objsUnidades;
        }

        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        List<Unidade> objsUnidades;
        public List<Unidade> ObjsUnidades
        {
            get { return objsUnidades; }
            set { objsUnidades = value; }
        }

        string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        string senha;
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        string cpfCnpj;
        public string CpfCnpj
        {
            get { return cpfCnpj; }
            set { cpfCnpj = value; }
        }

        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        string telefone;
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        NivelAcesso nivel;
        public NivelAcesso Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        Boolean ativacao;
        public Boolean Ativacao
        {
            get { return ativacao; }
            set { ativacao = value; }
        }
    }
}
