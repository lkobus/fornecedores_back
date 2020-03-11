using System;
using System.Collections.Generic;
using Faisalman.AgeCalc;
using Interfaces.Entities;
using Interfaces.Repositories;
using Interfaces.Services;
using Interfaces.ServicesArguments;
using ListagemFornecedores.Entities;
using ListagemFornecedores.Enums;
using ListagemFornecedores.Exceptions.Business;

namespace ListagemFornecedores.Services
{
    public class FornecedorService : IFornecedorService
    {
        private const int _idadeMaioriedade = 18;

        private readonly IEmpresaRepository _empresaRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IEmpresaRepository empresaRepository, IFornecedorRepository fornecedorRepository)
        {
            _empresaRepository = empresaRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public void CreatePessoaFisica(IFornecedorFisicaCreateModel fornecedor)
        {
            ValidateCPF(fornecedor.Cadastro);
            ValidateEmpresa(fornecedor.EmpresaId);
            ValidateCadastroDuplicado(fornecedor.Cadastro);
            ValidateFornecedorPessoaFisicaParana(fornecedor);
            var fornecedorEntity = Fornecedor.Builder
                .NewPessoaFisica()
                .FromEmpresa(fornecedor.EmpresaId)
                .SetCPF(fornecedor.Cadastro)
                .SetNome(fornecedor.Nome)
                .SetDataNascimento(fornecedor.DataNascimento)
                .SetRG(fornecedor.RG)
                .SetTelefones(fornecedor.Telefones)
                .Instance;
            _fornecedorRepository.Insert(fornecedorEntity);
        }



        public void CreatePessoaJuridica(IFornecedorJuridicaCreateModel fornecedor)
        {
            ValidateCNPJ(fornecedor.Cadastro);
            ValidateEmpresa(fornecedor.EmpresaId);
            ValidateCadastroDuplicado(fornecedor.Cadastro);
            var fornecedorEntity = Fornecedor.Builder
                .NewPessoaJuridica()
                .FromEmpresa(fornecedor.EmpresaId)
                .SetCNPJ(fornecedor.Cadastro)
                .SetNome(fornecedor.Nome)
                .SetTelefones(fornecedor.Telefones)
                .Instance;
            _fornecedorRepository.Insert(fornecedorEntity);
        }

        public IEnumerable<IFornecedor> FetchAll()
        {
            return _fornecedorRepository.GetAll();
        }

         public IEnumerable<IFornecedor> FetchByNome(string nome)
        {
            return _fornecedorRepository.FindByNome(nome);
        }

        public IEnumerable<IFornecedor> FetchByDate(DateTime date)
        {
            return _fornecedorRepository.FindByDate(date);
        }

        public IEnumerable<IFornecedor> FetchByDateAndNome(string nome, DateTime date)
        {
            return _fornecedorRepository.FindByDateAndNome(nome, date);
        }

        private void ValidateCPF(string cadastro)
        {
            if(!EmpresaService.IsCpf(cadastro))
            {
                throw new CPFCNPJInvalidoException($"CPF {cadastro} invalido");
            }
        }

        private void ValidateCNPJ(string cadastro)
        {
            if(!EmpresaService.IsCnpj(cadastro))
            {
                throw new CPFCNPJInvalidoException($"CNPJ {cadastro} invalido");
            }

        }

        private void ValidateEmpresa(string empresaId)
        {
            if(_empresaRepository.FindById(empresaId) == null)
            {
                throw new EmpresaNaoExisteException("Não foi possível identificar a empresa do fornecedor");
            }
        }

        private void ValidateFornecedorPessoaFisicaParana(IFornecedorFisicaCreateModel fornecedor)
        {
            if(isDeMenor(fornecedor) && isFromParana(fornecedor))
            {
                throw new MenorDeIdadeException("Não é permitido cadastro de menor de idade para o estado do paraná");
            }
        }
        private void ValidateCadastroDuplicado(string cadastro)
        {
            if(_fornecedorRepository.ExistCadastro(cadastro))
            {
                throw new CasdastroFornecedorJaExisteException($"Cadastro fornecedor {cadastro} já existe");
            }
        }
        private bool isFromParana(IFornecedorFisicaCreateModel fornecedor)
        {
            return _empresaRepository.FindById(fornecedor.EmpresaId).UF == UFEnum.PR;
        }
        private bool isDeMenor(IFornecedorFisicaCreateModel fornecedor)
        {
            return new Age(fornecedor.DataNascimento, DateTime.Today).Years < _idadeMaioriedade;
        }


    }
}