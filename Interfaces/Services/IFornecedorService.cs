using System;
using System.Collections.Generic;
using Interfaces.Entities;
using Interfaces.ServicesArguments;

namespace Interfaces.Services
{
    public interface IFornecedorService
    {
         void CreatePessoaFisica(IFornecedorFisicaCreateModel fornecedor);
         void CreatePessoaJuridica(IFornecedorJuridicaCreateModel fornecedor);

        IEnumerable<IFornecedor> FetchAll();
        IEnumerable<IFornecedor> FetchByNome(string nome);
        IEnumerable<IFornecedor> FetchByDate(DateTime date);
        IEnumerable<IFornecedor> FetchByDateAndNome(string nome, DateTime date);
    }
}