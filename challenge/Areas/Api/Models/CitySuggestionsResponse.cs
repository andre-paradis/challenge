using models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace challenge.Areas.Api.Models
{
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class CitySuggestionsResponse
    {
        public IEnumerable<CitySuggestion> Suggestions { get; set; }
    }

}