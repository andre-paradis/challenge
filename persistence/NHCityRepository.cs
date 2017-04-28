using models;
using NHibernate.Criterion;
using NHibernate.Linq;
using System.Collections.Generic;

namespace persistence
{
    /// <summary>
    /// NH implementation of the city repo.
    /// </summary>
    /// <seealso cref="persistence.ICityRepository" />
    class NHCityRepository : ICityRepository
    {
        /// <summary>
        /// Gets the matching cities from the database using simple like operator.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public IList<City> GetMatchingCities(string query)
        {
            var q = $"%{query}%";
            using (var session = NHSessionProvider.Instance.OpenSession())
            {
               // return session.QueryOver<City>().WhereRestrictionOn(c => c.Name).IsLike(q).List();

                return session.QueryOver<City>().Where(Restrictions.On<City>(x => x.Name).IsLike(q) || Restrictions.On<City>(x => x.Stateprov).IsLike(q) || Restrictions.On<City>(x => x.Country).IsLike(q)).List();
            }
        }
    }
}
