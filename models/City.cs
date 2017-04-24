using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{

    /// <summary>
    /// City model mapped to the cities database table
    /// </summary>
    public class City
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual double Lat { get; set; }

        public virtual double Long { get; set; }

        public virtual string Country { get; set; }

        public virtual string Stateprov { get; set; }

    }
}
