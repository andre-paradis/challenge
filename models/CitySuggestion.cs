using Newtonsoft.Json;

namespace models
{
    /// <summary>
    /// Model that represents a suggestion returned from the suggestion service
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class CitySuggestion
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonIgnore]
        public double DistanceFromReference { get; set; }

    }
}