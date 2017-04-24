using challenge.Areas.Api.Models;
using common;
using services;
using System.Web.Http;

namespace challenge.Areas.Api.Controllers
{
    /// <summary>
    /// API controller related to the cities
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
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

        /// <summary>
        /// Suggests the cities. parameteres are passed using query params:
        /// /suggestions/?q=query&lat=...&long=...
        /// </summary>
        /// <param name="q">The q.</param>
        /// <param name="lat">The lat.</param>
        /// <param name="long">The long.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("suggestions")]
        public CitySuggestionsResponse SuggestCities([FromUri] string q, [FromUri] double? lat = null, [FromUri] double? @long = null)
        {
            // delegate operation to suggestion service..
            var cities = _suggestionService.SuggestCities(q, lat, @long);

            // wrap response that will be serialized to json or xml dependending on request content-type.
            return new CitySuggestionsResponse()
            {
                Suggestions = cities
            };

        }
    }
}
