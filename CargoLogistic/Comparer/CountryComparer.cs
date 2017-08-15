using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain;

namespace CargoLogistic
{
    class CountryComparer : IComparer<Country>
    {
        public int Compare(Country x, Country y)
        {
            if (Equals(x, y)) return 0;
            return x.NumericCode.CompareTo(y.NumericCode);
        }
        
    }
}
