using System;
using System.Collections.Generic;
using Interfaces.Entities;
using Interfaces.ServicesArguments;

namespace NancyAPI.DTO
{
    public class FornecedorFisicaDTO : IFornecedorFisicaCreateModel
    {
        public string EmpresaId { get; set; }

        public string Nome { get; set; }

        public string Cadastro { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<string> Telefones { get; set; }

        public string RG { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool Juridica { get; set; }

        public FornecedorFisicaDTO() { }
        public FornecedorFisicaDTO(IFornecedor fornecedor)
        {
            EmpresaId = fornecedor.EmpresaId;
            Nome = fornecedor.Nome;
            Cadastro = fornecedor.Cadastro;
            Telefones = fornecedor.Telefones;
            RG = fornecedor.RG;
            Juridica = fornecedor.Juridica;
            DataNascimento = fornecedor.DataNascimento;
            CreatedAt = fornecedor.CreatedAt;
        }
    }
}