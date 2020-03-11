using System;
using System.Collections.Generic;
using Interfaces.Entities;
using Interfaces.Repositories;
using Interfaces.Services;
using Interfaces.ServicesArguments;
using ListagemFonecedores.Entities;
using ListagemFornecedores.Exceptions.Business;

namespace ListagemFornecedores.Services
{
    public class EmpresaService : IEmpresaService
    {


        public IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public void CreateEmpresa(IEmpresaCreateModel empresa)
        {
            ValidateCNPJ(empresa.CNPJ);
            ValidateCNPJDuplicado(empresa.CNPJ);

            _empresaRepository.Insert(
                Empresa.Builder.New()
                    .SetCNPJ(empresa.CNPJ)
                    .SetNomeFantasia(empresa.NomeFantasia)
                    .SetUF(empresa.UF)
                    .Instance
            );
        }



        public IEnumerable<IEmpresa> FetchAll()
        {
            return _empresaRepository.GetAll();
        }

        private void ValidateCNPJDuplicado(string cNPJ)
        {
            if(_empresaRepository.Exist(cNPJ))
            {
                throw new EmpresaCNPJJaExisteException($"CNPJ duplicado : {cNPJ} - já existe na base de dados");
            }
        }

        private void ValidateCNPJ(string cadastro)
        {
            if(!EmpresaService.IsCnpj(cadastro))
            {
                throw new CPFCNPJInvalidoException($"CNPJ {cadastro} invalido");
            }

        }

        public static bool IsCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
			int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
			   return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for(int i=0; i<12; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if ( resto < 2)
			   resto = 0;
			else
			   resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
			    resto = 0;
			else
			   resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}
	    public static bool IsCpf(string cpf)
	    {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for(int i=0; i<9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if ( resto < 2 )
                resto = 0;
            else
            resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for(int i=0; i<10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
            resto = 0;
            else
            resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
	    }

    }
}