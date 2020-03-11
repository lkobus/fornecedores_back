using System;

namespace ListagemFornecedores.Exceptions.Business
{
    public class CasdastroFornecedorJaExisteException : Exception
    {
        public CasdastroFornecedorJaExisteException() {}

        public CasdastroFornecedorJaExisteException(string message) : base (message)
        {
            
        }
    }
}