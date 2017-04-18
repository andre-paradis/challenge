using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using models;

namespace challenge.Areas.Api.Models
{
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class CitySuggestionsResponse
    {
        public IEnumerable<CitySuggestion> Suggestions { get; set; }
    }

}