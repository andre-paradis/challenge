using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public interface ISuggestionService
    {
        IList<CitySuggestion> SuggestCities(string name, double? latitude, double? longitude);
    }
}
