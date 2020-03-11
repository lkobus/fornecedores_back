using System;

namespace ListagemFornecedores.Exceptions.Business
{
    public class MenorDeIdadeException : Exception
    {
        public MenorDeIdadeException()
        {

        }

        public MenorDeIdadeException(string message): base(message)
        {

        }
    }
}