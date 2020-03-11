using System;
using System.Collections.Generic;

namespace Interfaces.ServicesArguments
{
    public interface IFornecedorFisicaCreateModel
    {
        string EmpresaId {get;}
        string Nome {get;}
        string Cadastro {get;}
        bool Juridica {get;}
        DateTime CreatedAt {get;}
        IEnumerable<string> Telefones {get;}
        string  RG {get;}
        DateTime DataNascimento {get;}
    }
}