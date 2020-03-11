using System;
using System.Collections.Generic;
using Interfaces.Entities;

namespace Interfaces.Repositories
{
    public interface IFornecedorRepository : IBaseRepository<IFornecedor>
    {
        bool ExistCadastro(string cadastro);
        IEnumerable<IFornecedor> FindByNome(string nome);
        IEnumerable<IFornecedor> FindByDate(DateTime date);
        IEnumerable<IFornecedor> FindByDateAndNome(string nome, DateTime date);
    }
}