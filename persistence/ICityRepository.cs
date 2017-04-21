using models;
using System.Collections.Generic;

namespace persistence
{
    public interface ICityRepository
    {
        IList<City> GetMatchingCities(string query);
    }
}
