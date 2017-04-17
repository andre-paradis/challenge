using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence
{
    class NHSessionProvider
    {
        private static NHSessionProvider _instance;

        private ISessionFactory _sessionFactory;

        static NHSessionProvider()
        {
            _instance = new NHSessionProvider();
        }

        private NHSessionProvider()
        {
            _sessionFactory = 
                Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c.FromConnectionStringWithKey("challenge"))
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHSessionProvider>())
                .BuildSessionFactory();
        }

        static NHSessionProvider Instance
        {
            get
            {
                return _instance;
            }
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
