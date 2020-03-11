using System;

namespace ListagemFornecedores.Exceptions.Business
{
    public class EmpresaCNPJJaExisteException : Exception
    {
        public EmpresaCNPJJaExisteException() { }

        public EmpresaCNPJJaExisteException(string message) : base(message) { }
    }
}