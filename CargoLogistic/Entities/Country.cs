using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.DAL.Entities
{
    public class Country : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual int NumericCode { get;  set; }
        public virtual string Alpha2Code { get; set; }

        private readonly List<Locality> _locations;
        public virtual IEnumerable<Locality> Locations { get { return _locations; } }

        public Country(string name, int digitalCode = 0, string isoCode = "")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name) + " is null or whitespace");
            }
            Name = name;
            NumericCode = digitalCode;
            Alpha2Code = isoCode;
        }

        public Country()
        {
            _locations = new List<Locality>();
            
        }
        
        public override string ToString()
        {
            return $"Name: {Name}, IsoCode: {Alpha2Code}";
        }
    }
}
