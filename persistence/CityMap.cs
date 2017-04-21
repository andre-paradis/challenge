using FluentNHibernate.Mapping;
using models;

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
            Table("Cities");
        }
    }
}
