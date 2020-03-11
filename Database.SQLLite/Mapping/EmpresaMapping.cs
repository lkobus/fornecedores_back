using FluentNHibernate.Mapping;
using Interfaces.Entities;
using ListagemFonecedores.Entities;

namespace Database.SQLLite.Mapping
{
    public class EmpresaMapping : ClassMap<Empresa>
    {
        private const string TABLE_NAME = "empresa";

        public EmpresaMapping()
        {
            Id(p => p.SequentialId);
            Map(p => p.BusinessId);
            Map(p => p.CNPJ);
            Map(p => p.NomeFantasia);
            Map(p => p.UF);
            Table(TABLE_NAME);
        }
    }
}