using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace persistence
{
    /// <summary>
    /// Singleton that construct instances of NH sessions
    /// </summary>
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

        /// <summary>
        /// Gets the instance of the session provider
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static NHSessionProvider Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Opens the session.
        /// </summary>
        /// <returns></returns>
        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
