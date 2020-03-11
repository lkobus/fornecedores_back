using System;
using System.Collections.Generic;
using Interfaces.ServicesArguments;

namespace NancyAPI.DTO
{
    public class FornecedorJuridicaDTO : IFornecedorJuridicaCreateModel
    {
        public string EmpresaId { get; set; }

        public string Nome { get; set; }

        public string Cadastro { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<string> Telefones {get ; set;}
    }
}