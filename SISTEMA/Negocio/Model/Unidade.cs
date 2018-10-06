using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Unidade
    {
        public Unidade()
        {
            ObjUsuario = new Usuario();
        }

        public Unidade(List<Divisao> objsDivisoes)
        {
            ObjUsuario = new Usuario();
            ObjsDivisoes = objsDivisoes;
        }

        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        Usuario objUsuario;
        public Usuario ObjUsuario
        {
            get { return objUsuario; }
            set { objUsuario = value; }
        }

        List<Divisao> objsDivisoes;
        public List<Divisao> ObjsDivisoes
        {
            get { return objsDivisoes; }
            set { objsDivisoes = value; }
        }
        
        string cep;
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        string numero;
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        string endereco;
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        string bairro;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        string cidade;
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        string pais;
        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        int tempo;
        public int Tempo
        {
            get { return tempo; }
            set { tempo = value; }
        }

        string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
