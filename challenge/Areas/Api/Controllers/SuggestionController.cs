using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using challenge.Areas.Api.Models;
using models;
using common;
using services;

namespace challenge.Areas.Api.Controllers
{
    public class SuggestionController : ApiController
    {
        private static ILogger _logger;

        private ISuggestionService _suggestionService;
        
        public SuggestionController(ILogProvider logProvider, ISuggestionService srv)
        {
            if (_logger == null)
            {
                _logger = logProvider.GetLogger(typeof(SuggestionController).FullName);
            }

            _suggestionService = srv;
        }

        [HttpGet]
        [Route("suggestions/{q}/{lat:double?}/{long:double?}")]
        public CitySuggestionsResponse SuggestCities(string q, double? lat, double? @long)
        {
            var cities = _suggestionService.SuggestCities(q, lat, @long);

            return new CitySuggestionsResponse()
            {
                Suggestions = cities
            };

        }
    }
}
