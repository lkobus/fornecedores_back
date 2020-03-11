using System.Collections.Generic;
using Interfaces.Entities;

namespace Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : IEntity
    {
        T FindById(string id);
        T Insert (T fornecedor);
        T FindBySequentialId(int id);
        IEnumerable<T> GetAll();
    }
}