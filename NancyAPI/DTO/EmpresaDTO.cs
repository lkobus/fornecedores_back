using System.Linq;
using Interfaces.Entities;
using Interfaces.ServicesArguments;
using ListagemFornecedores.Enums;

namespace NancyAPI.DTO
{
    public class EmpresaDTO : IEmpresaCreateModel
    {
        public int UF  { get; set; }
        public string VerboseUF {get; set;}

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public string BusinessId {get; set;}

        public EmpresaDTO() {}

        public EmpresaDTO(IEmpresa empresa)
        {
            UF = empresa.UF;
            VerboseUF = UFEnum.ToList().FirstOrDefault(p => p.Codigo == empresa.UF).Valor;
            NomeFantasia = empresa.NomeFantasia;
            CNPJ = empresa.CNPJ;
            BusinessId = empresa.BusinessId;
        }
    }
}