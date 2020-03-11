using System;

namespace ListagemFornecedores.Exceptions.Business
{
    public class CPFCNPJInvalidoException : Exception
    {
        public CPFCNPJInvalidoException() { }

        public CPFCNPJInvalidoException(string message) : base(message) { }
    }
}