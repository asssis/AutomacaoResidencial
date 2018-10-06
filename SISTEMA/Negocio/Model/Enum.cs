using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public enum TipoControle:int
    {
        NULL = 0, SIMPLES = 1, LOGICO =2, GRADUAL = 3, ESPECIFICO = 4
    }
    public enum TipoLeitor:int
    {
       NULL = 0, OPTOACOPLADOR = 5, AMPERIMETRO = 6
    }
    public enum NivelAcesso : int
    {
        NULL = 0, CLIENTE = 1,  TECNICO = 2, ADMINISTRADOR = 3
    }
    public enum Condicao : int
    {
        NULL = 0, MENOR = 1, MAIOR = 2, IGUAL = 3, DIFERENTE = 4
    }
}
