using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Entities;
using ListagemFornecedores.Builders;

namespace ListagemFornecedores.Entities
{
    public class Fornecedor : IFornecedor
    {
        public static FornecedorBuilder Builder => new FornecedorBuilder();

        public virtual string EmpresaId {get; protected set;}

        public virtual string Nome {get; protected set;}

        public virtual string Cadastro {get; protected set;}

        public virtual DateTime CreatedAt {get; protected set;}

        public virtual IEnumerable<string> Telefones { get {
            return Telefone.Split(',').ToList();
        } protected set{}}

        public virtual string RG {get; protected set;}

        public virtual DateTime DataNascimento {get; protected set;}

        public virtual string BusinessId {get; protected set;}

        public virtual int SequentialId { get; protected set; }

        public virtual bool Juridica { get; protected set; }

        public virtual string Telefone { get;  protected set; }

        protected Fornecedor(){ }

        public class FornecedorBuilder : BaseBuilder<Fornecedor>
        {
            public FornecedorBuilder NewPessoaFisica()
            {
                Instance = new Fornecedor();
                Instance.BusinessId = Guid.NewGuid().ToString("N");
                Instance.CreatedAt = DateTime.Now;
                Instance.Juridica = false;
                Instance.Telefones = new List<string>();
                return this;
            }

            public FornecedorBuilder NewPessoaJuridica()
            {
                Instance = new Fornecedor();
                Instance.BusinessId = Guid.NewGuid().ToString("N");
                Instance.CreatedAt = DateTime.Now;
                Instance.Juridica = true;
                Instance.Telefones = new List<string>();
                return this;
            }

            public FornecedorBuilder SetNome(string nome)
            {
                Instance.Nome = nome;
                return this;
            }


            public FornecedorBuilder FromEmpresa(string empresaId)
            {
                Instance.EmpresaId = empresaId;
                return this;
            }
            public FornecedorBuilder SetCNPJ(string cnpj)
            {
                Instance.Cadastro = cnpj;
                return this;
            }

            public FornecedorBuilder SetCPF(string cpf)
            {
                Instance.Cadastro = cpf;
                return this;
            }

            public FornecedorBuilder SetRG(string rg)
            {
                Instance.RG = rg;
                return this;
            }

            public FornecedorBuilder SetTelefones(IEnumerable<string> telefones)
            {
                Instance.Telefones = telefones;
                Instance.Telefone = string.Join(",", telefones);
                return this;
            }

            public FornecedorBuilder SetDataNascimento(DateTime dataNascimento)
            {
                Instance.DataNascimento = dataNascimento;
                return this;
            }
        }
    }
}