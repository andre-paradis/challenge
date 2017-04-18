using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using persistence;

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

        public IList<CitySuggestion> SuggestCities(string name, double? latitude, double? longitude)
        {
            _logger.Info($"SuggestCities invoked with {name}, {latitude}, {longitude}");

            return new List<CitySuggestion>() {
                new CitySuggestion()
                {
                    Name = "test",
                    Score = 1,
                    Latitude = 12.0,
                    Longitude = 13.0
                },
                new CitySuggestion()
                {
                    Name = "test2",
                    Score = 1,
                    Latitude = 12.0,
                    Longitude = 13.0
                }
            };


        }
    }
}
