using System.Collections.Generic;
using Interfaces.Entities;
using Interfaces.ServicesArguments;

namespace Interfaces.Services
{
    public interface IEmpresaService
    {
         void CreateEmpresa(IEmpresaCreateModel empresa);
         IEnumerable<IEmpresa> FetchAll();
         
    }
}