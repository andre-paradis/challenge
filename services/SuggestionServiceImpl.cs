using common;
using models;
using persistence;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Device.Location;

namespace services
{
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

        private IEnumerable<CitySuggestion> ApplyScore(IEnumerable<CitySuggestion> suggestions, string query, GeoCoordinate source = null)
        {
            int score = suggestions.Count();
            suggestions = suggestions.OrderBy(s => s.Name.Length).ThenBy(s => s.DistanceFromReference).Select(s => { s.Score = score-- ; return s; }).ToList();
            return suggestions;
        }
    }
}
