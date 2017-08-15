using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Events;

using CargoLogistic.Repository;
using CargoLogistic.Domain.Users;

namespace CargoLogistic.Domain
{
    public abstract class Post : EntityBase
    {
        public virtual User User { get; set; }
        public virtual DateTime PublicationDate { get; set; } 
        public virtual DateTime DateFrom { get;  set; }
        public virtual DateTime DateTo { get;  set; }
        public virtual Locality LocationFrom { get; } 
        public virtual Locality LocationTo { get; }

        private double _price;
        public virtual double Price
        {
            get { return _price; }
            set
            {
                if (_price == value)
                {
                    return;
                }

                if (_price < value)
                    OnPostPriceChanged(new PostPriceChangedEventArgs(Price, value, Id));
                _price = value;
            }
        }
        public virtual string AdditionalInformation { get; set; } 
           
        public Post(DateTime dataFrom, DateTime dateTo, 
            Locality localityFrom, Locality localityTo, double price, string additionalInformation, User user)
        {
            DateFrom = dataFrom;
            DateTo = dateTo;
            LocationFrom = localityFrom;
            LocationTo = localityTo;
            Price = price;
            AdditionalInformation = additionalInformation;
            User = user;
            PublicationDate = DateTime.Now;
                 
        }

        protected Post()
        {
            
        }

        #region Event
        public virtual event EventHandler<PostPriceChangedEventArgs> PostPriceChanged; // The event
        public virtual void OnPostPriceChanged(PostPriceChangedEventArgs e) // Notify register objects
        {
            if (PostPriceChanged != null)
            {
                PostPriceChanged(this, e); // delagate invoke()
            }
        }
        #endregion
        
        public override string ToString()
        {
            return $"{LocationFrom} - {LocationTo}, {DateFrom.ToShortDateString()}-{DateTo.ToShortDateString()}, {Price}";
        }
    }
}
