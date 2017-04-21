using models;
using NHibernate.Linq;
using System.Collections.Generic;

namespace persistence
{
    class NHCityRepository : ICityRepository
    {
        public IList<City> GetMatchingCities(string query)
        {
            var q = $"%{query}%";
            using(var session = NHSessionProvider.Instance.OpenSession())
            {
                return session.QueryOver<City>().WhereRestrictionOn(c => c.Name).IsLike(q).List();
            }
        }
    }
}
