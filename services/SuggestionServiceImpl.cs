using common;
using models;
using persistence;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Device.Location;

namespace services
{
    /// <summary>
    /// Uses a repository to get matching cities, then calculate a relevancy score based on the length of
    /// the match and the distance of the match and the optional lat and long
    /// </summary>
    /// <seealso cref="services.ISuggestionService" />
    class SuggestionServiceImpl : ISuggestionService
    {
        private static ILogger _logger;

        private ICityRepository _cityRepository;

        public SuggestionServiceImpl(ILogProvider logProvider, ICityRepository cityRepository)
        {
            if(_logger == null)
            {
                _logger = logProvider.GetLogger(typeof(SuggestionServiceImpl).FullName);
            }

            _cityRepository = cityRepository;
        }

        /// <summary>
        /// Suggests the cities and apply a score
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        public IList<CitySuggestion> SuggestCities(string query, double? latitude, double? longitude)
        {
            _logger.Info($"SuggestCities invoked with {query}");

            GeoCoordinate source = (latitude.HasValue && longitude.HasValue) ? new GeoCoordinate(latitude.Value, longitude.Value) : null;

            var suggestions = _cityRepository.GetMatchingCities(query).Select(c => new CitySuggestion()
            {
                Name = c.Name,
                Score = 0,
                Latitude = c.Lat,
                Longitude = c.Long,
                DistanceFromReference = (source != null) ? source.GetDistanceTo(new GeoCoordinate(c.Lat, c.Long)) : Double.MaxValue
            });

            suggestions = ApplyScore(suggestions, query);

            return suggestions.ToList();
        }

        /// <summary>
        /// Applies the score. Score is simply assigned by sorting the matches from the shortest city name to the longuest, 
        /// and then by the distance from the city to the reference point passed as argument. Distance is calculated using proper
        /// distance algorithm.
        /// </summary>
        /// <param name="suggestions">The suggestions.</param>
        /// <param name="query">The query.</param>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        private IEnumerable<CitySuggestion> ApplyScore(IEnumerable<CitySuggestion> suggestions, string query, GeoCoordinate source = null)
        {
            int score = suggestions.Count() - 1;
            double maxScore = suggestions.Count() - 1;
            suggestions = suggestions.OrderBy(s => s.Name.Length).ThenBy(s => s.DistanceFromReference).Select(s => { s.Score = score-- / maxScore; return s; }).ToList();
            return suggestions;
        }
    }
}
