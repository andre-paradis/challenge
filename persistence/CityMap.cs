using FluentNHibernate.Mapping;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence
{
    class CityMap :  ClassMap<City>
    {
        public CityMap()
        {
            Id(c => c.Id);
            Map(c => c.Name);
            Map(c => c.Lat);
            Map(c => c.Long);
            Map(c => c.Country);
            Map(c => c.Stateprov);
        }
    }
}
