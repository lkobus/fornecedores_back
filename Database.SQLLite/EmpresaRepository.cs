using System.Collections.Generic;
using System.Linq;
using Interfaces.Entities;
using Interfaces.Repositories;
using ListagemFonecedores.Entities;

namespace Database.SQLLite
{
    public class EmpresaRepository : BaseNhibernateRepository, IEmpresaRepository
    {
        public EmpresaRepository() : base() { }

        public bool Exist(string cnpj)
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Empresa>()
                    .Where(p => p.CNPJ == cnpj)
                    .FirstOrDefault() != null;
            }
        }

        public IEmpresa FindById(string id)
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Empresa>()
                    .Where(p => p.BusinessId == id)
                    .FirstOrDefault();
            }
        }

        public IEmpresa FindBySequentialId(int id)
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Empresa>()
                    .Where(p => p.SequentialId == id)
                    .FirstOrDefault();
            }
        }

        public IEnumerable<IEmpresa> GetAll()
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Empresa>().ToList();
            }
        }

        public IEmpresa Insert(IEmpresa empresa)
        {
            using(var session = new Session())
            {
                session.CurrentSession.Save(empresa as Empresa);
            }
            return null;
        }
    }
}