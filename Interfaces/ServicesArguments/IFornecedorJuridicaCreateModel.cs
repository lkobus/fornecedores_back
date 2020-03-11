using System;
using System.Collections.Generic;

namespace Interfaces.ServicesArguments
{
    public interface IFornecedorJuridicaCreateModel
    {
        string EmpresaId { get; }
        string Nome { get; }
        string Cadastro { get; }         
        DateTime CreatedAt { get; }
        IEnumerable<string> Telefones { get; }         
    }
}