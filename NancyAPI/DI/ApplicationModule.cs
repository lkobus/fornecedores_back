using Interfaces.Repositories;
using Interfaces.Services;
using ListagemFornecedores.Services;
using Ninject.Modules;

namespace NancyAPI.DI
{
    public class ApplicationModule : NinjectModule
    {

        public override void Load()
        {
            this.Bind<IEmpresaRepository>().To<Database.SQLLite.EmpresaRepository>().InThreadScope();
            this.Bind<IFornecedorRepository>().To<Database.SQLLite.FornecedorRepository>().InThreadScope();
            this.Bind<IEmpresaService>().To<EmpresaService>().InSingletonScope();
            this.Bind<IFornecedorService>().To<FornecedorService>().InSingletonScope();

        }
    }
}