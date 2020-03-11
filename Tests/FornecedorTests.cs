using System;
using System.Linq;
using Interfaces.Entities;
using Interfaces.Repositories;
using Interfaces.Services;
using Interfaces.ServicesArguments;
using ListagemFornecedores.Enums;
using ListagemFornecedores.Exceptions.Business;
using ListagemFornecedores.Services;
using Moq;
using Xunit;

namespace Tests
{
    public class FornecedorTests
    {



        [Fact]
        public void CadastroMenorDeIdadeParanaExceptionTest()
        {
            var fornecedorService = new FornecedorService(GetMockEmpresaEstado(UFEnum.PR), GetFornecedorCadastroExistente(false));
            var model = new Mock<IFornecedorFisicaCreateModel>();
            model.Setup(p => p.DataNascimento).Returns(new DateTime(2005, 05, 08));
            Assert.Throws<MenorDeIdadeException>(() => fornecedorService.CreatePessoaFisica(model.Object));
        }

        [Fact]
        public void CadastroMenorDeIdadeSemParanaExceptionTest()
        {
            UFEnum.ToList().Where(p => p.Codigo != UFEnum.PR).ToList()
                .ForEach(estado => {
                    var fornecedorService = new FornecedorService(GetMockEmpresaEstado(estado), GetFornecedorCadastroExistente(false));
                    var model = new Mock<IFornecedorFisicaCreateModel>();
                    model.Setup(p => p.DataNascimento).Returns(new DateTime(2000, 05, 08));
                    fornecedorService.CreatePessoaFisica(model.Object);
                });
        }

        [Fact]
        public void CadastroFornecedorRepetidoTest()
        {
            var fornecedorService = new FornecedorService(GetMockEmpresaEstado(UFEnum.PR), GetFornecedorCadastroExistente(true));
            var model = new Mock<IFornecedorFisicaCreateModel>();
            model.Setup(p => p.DataNascimento).Returns(new DateTime(2005, 05, 08));
            Assert.Throws<CasdastroFornecedorJaExisteException>(() => fornecedorService.CreatePessoaFisica(model.Object));
        }

        [Fact]
        public void CadastroFornecedorSemEmpresaTest()
        {
            var fornecedorService = new FornecedorService(GetEmpresaNaoExistente(), GetFornecedorCadastroExistente(true));
            var model = new Mock<IFornecedorFisicaCreateModel>();
            model.Setup(p => p.DataNascimento).Returns(new DateTime(2005, 05, 08));
            Assert.Throws<EmpresaNaoExisteException>(() => fornecedorService.CreatePessoaFisica(model.Object));
        }


        private IEmpresaRepository GetEmpresaNaoExistente()
        {
            var repository = new Mock<IEmpresaRepository>();
            repository.Setup(p => p.FindById(It.IsAny<string>())).Returns<IEmpresa>(null);
            return repository.Object;
        }

        private IFornecedorRepository GetFornecedorCadastroExistente(bool value)
        {
            var repository = new Mock<IFornecedorRepository>();
            repository.Setup(p => p.ExistCadastro(It.IsAny<string>())).Returns(value);
            return repository.Object;
        }

        private IEmpresaRepository GetMockEmpresaEstado(int codigo)
        {
            var empresaParana = new Mock<IEmpresa>();
            empresaParana.Setup(p => p.UF).Returns(UFEnum.PR);

            var repository = new Mock<IEmpresaRepository>();
            repository.Setup(p => p.FindById(It.IsAny<string>())).Returns(empresaParana.Object);
            return repository.Object;
        }
    }
}
