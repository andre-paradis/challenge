using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

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
