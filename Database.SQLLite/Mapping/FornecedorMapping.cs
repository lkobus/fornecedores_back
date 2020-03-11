using FluentNHibernate.Mapping;
using ListagemFornecedores.Entities;

namespace Database.SQLLite.Mapping
{
    public class FornecedorMapping : ClassMap<Fornecedor>
    {
        private const string TABLE_NAME = "fornecedor";

        public FornecedorMapping()
        {
            Id(p => p.SequentialId);
            Map(p => p.BusinessId);
            Map(p => p.Cadastro);
            Map(p => p.DataNascimento);
            Map(p => p.Juridica);
            Map(p => p.Nome);
            Map(p => p.RG);
            Map(p => p.Telefone);
            Map(p => p.EmpresaId);
            Map(p => p.CreatedAt);
            Table(TABLE_NAME);
        }
    }
}