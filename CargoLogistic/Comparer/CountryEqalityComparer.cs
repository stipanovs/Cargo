using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain;

namespace CargoLogistic
{
    class CountryEqalityComparer : IEqualityComparer<Country>
    {
        public bool Equals(Country x, Country y)
        {
            return x.Name == y.Name && x.NumericCode == y.NumericCode;
        }

        public int GetHashCode(Country obj)
        {
            return (obj.Name + ";" + obj.NumericCode).GetHashCode();
        }
    }
}
