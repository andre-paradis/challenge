using Newtonsoft.Json;

namespace models
{
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class CitySuggestion
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonIgnore]
        public double DistanceFromReference { get; set; }

    }
}