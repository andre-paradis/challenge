using models;
using NHibernate.Linq;
using System.Collections.Generic;

namespace persistence
{
    class NHCityRepository : ICityRepository
    {
        public IList<City> GetMatchingCities(string query, double? latitude, double? longitude)
        {
            using(var session = NHSessionProvider.Instance.OpenSession())
            {
                return session.QueryOver<City>().Where(c => c.Name.Like($"%{query}%")).List();
            }
        }
    }
}
