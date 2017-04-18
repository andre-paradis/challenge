using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence
{
    public interface ICityRepository
    {
        IList<City> GetMatchingCities(string query, double? latitude, double? longitude);
    }
}
