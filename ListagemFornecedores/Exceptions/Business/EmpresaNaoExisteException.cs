using System;

namespace ListagemFornecedores.Exceptions.Business
{
    public class EmpresaNaoExisteException : Exception
    {
        
        public EmpresaNaoExisteException () { }

        public EmpresaNaoExisteException(string message) : base (message) {}
    }
}