using models;
using System.Collections.Generic;

namespace services
{
    /// <summary>
    /// Service that provides cities search feature. 
    /// </summary>
    public interface ISuggestionService
    {
        /// <summary>
        /// Suggests the cities based on the query, and possibly latitude and longitude.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        IList<CitySuggestion> SuggestCities(string name, double? latitude, double? longitude);
    }
}
