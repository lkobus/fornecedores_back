using System;
using System.Collections.Generic;

namespace Interfaces.Entities
{
    public interface IFornecedor : IEntity
    {
         string EmpresaId {get;}
         string Nome {get;}
         bool Juridica {get;}
         string Cadastro {get;}
         DateTime CreatedAt {get;}
         IEnumerable<string> Telefones {get;}
         string Telefone {get;}
         string  RG {get;}
         DateTime DataNascimento {get;}

    }
}