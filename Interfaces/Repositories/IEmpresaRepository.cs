using Interfaces.Entities;

namespace Interfaces.Repositories
{
    public interface IEmpresaRepository : IBaseRepository<IEmpresa>
    {
         bool Exist(string cnpj);
    }
}