using System;
using Interfaces.Entities;
using ListagemFornecedores.Builders;
using ListagemFornecedores.Enums;

namespace ListagemFonecedores.Entities
{
    public class Empresa : IEmpresa
    {

        public static EmpresaBuilder Builder => new EmpresaBuilder();

        public virtual  int UF  {get; protected  set;}

        public virtual  string NomeFantasia {get; protected set;}

        public virtual  string CNPJ  {get; protected set;}

        public virtual  string BusinessId { get; protected set;}

        public virtual  int SequentialId {get; protected set;}

        protected Empresa() { }

        public class EmpresaBuilder : BaseBuilder<Empresa>
        {
            public EmpresaBuilder New()
            {
                Instance = new Empresa();
                Instance.BusinessId = Guid.NewGuid().ToString("N");
                return this;
            }

            public EmpresaBuilder SetCNPJ(string cnpj)
            {
                Instance.CNPJ = cnpj;
                return this;
            }
            public EmpresaBuilder SetUF(UFEnum uf)
            {
                Instance.UF = uf.Codigo;
                return this;
            }

            public EmpresaBuilder SetUF(int uf)
            {
                Instance.UF = uf;
                return this;
            }
            public EmpresaBuilder SetNomeFantasia(string nomeFantasia)
            {                
                Instance.NomeFantasia = nomeFantasia;
                return this;
            }
        }
    }
}