using challenge.Areas.Api.Models;
using common;
using services;
using System.Web.Http;

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
        [Route("suggestions")]
        public CitySuggestionsResponse SuggestCities([FromUri] string q, [FromUri] double? lat = null, [FromUri] double? @long = null)
        {
            var cities = _suggestionService.SuggestCities(q, lat, @long);

            return new CitySuggestionsResponse()
            {
                Suggestions = cities
            };

        }
    }
}
