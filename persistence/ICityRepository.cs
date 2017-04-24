using models;
using System.Collections.Generic;

namespace persistence
{
    /// <summary>
    /// Provides operation related to cities table
    /// </summary>
    public interface ICityRepository
    {
        /// <summary>
        /// Gets the matching cities from the database
        /// </summary>
        /// <param name="query">The query. </param>
        /// <returns></returns>
        IList<City> GetMatchingCities(string query);
    }
}
