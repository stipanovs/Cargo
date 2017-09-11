using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.DAL.Events
{
    public class PostPriceChangedEventArgs : EventArgs
    {
        public decimal LastPrice { get; private set; }
        public decimal NewPrice { get; private set; }
        public long ID { get; private set; }

        public PostPriceChangedEventArgs(decimal lastPrice, decimal newPrice, long id)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
            ID = id;
        }
    }
}
