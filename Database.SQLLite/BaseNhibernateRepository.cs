using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace Database.SQLLite
{
    public class BaseNhibernateRepository
    {

        private static ISessionFactory _session;
        public BaseNhibernateRepository()
        {
            _session = Fluently.Configure()
                                      .Database(SQLiteConfiguration.Standard
                                      .UsingFile("database.db"))
                                      .CurrentSessionContext("call")
                                      .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                                      .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                                      .BuildSessionFactory();
        }


        protected class Session : IDisposable
        {
            public ISession CurrentSession  {
                get
                {
                    if(!CurrentSessionContext.HasBind(_session))
                        CurrentSessionContext.Bind(_session.OpenSession());

                    return _session.GetCurrentSession();
                }
            }

            public void Dispose()
            {
                ISession currentSession = CurrentSessionContext.Unbind(_session);
                currentSession.Close();
                currentSession.Dispose();
            }
        }


    }
}