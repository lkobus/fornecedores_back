using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Entities;
using Interfaces.Repositories;
using ListagemFornecedores.Entities;
using NHibernate.Criterion;

namespace Database.SQLLite
{
    public class FornecedorRepository : BaseNhibernateRepository, IFornecedorRepository
    {
        public FornecedorRepository() : base() { }
        public bool ExistCadastro(string cadastro)
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Fornecedor>()
                    .Where(p => p.Cadastro == cadastro)
                    .FirstOrDefault() != null;
            }
        }

        public IEnumerable<IFornecedor> FindByDate(DateTime date)
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Fornecedor>()
                    .Where(p => p.CreatedAt > date.Date && p.CreatedAt < date.AddDays(1).Date )
                    .ToList();
            }
        }

        public IEnumerable<IFornecedor> FindByDateAndNome(string nome, DateTime date)
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Fornecedor>()
                    .Where(p => p.Nome.StartsWith(nome) &&  p.CreatedAt > date.Date && p.CreatedAt < date.AddDays(1).Date)
                    .ToList();
            }
        }

        public IEnumerable<IFornecedor> FindByNome(string nome)
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Fornecedor>()
                    .Where(p => p.Nome.StartsWith(nome))
                    .ToList();
            }
        }

        public IFornecedor FindById(string id)
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Fornecedor>()
                    .Where(p => p.BusinessId == id)
                    .FirstOrDefault();
            }
        }



        public IFornecedor FindBySequentialId(int id)
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Fornecedor>()
                    .Where(p => p.SequentialId == id)
                    .FirstOrDefault();
            }
        }

        public IEnumerable<IFornecedor> GetAll()
        {
            using(var session = new Session())
            {
                return session.CurrentSession.Query<Fornecedor>().ToList();
            }
        }

        public IFornecedor Insert(IFornecedor fornecedor)
        {
            using(var session = new Session())
            {
                session.CurrentSession.Save(fornecedor as Fornecedor);
            }
            return null;
        }
    }
}