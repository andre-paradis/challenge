using models;
using System.Collections.Generic;

namespace services
{
    public interface ISuggestionService
    {
        IList<CitySuggestion> SuggestCities(string name, double? latitude, double? longitude);
    }
}
