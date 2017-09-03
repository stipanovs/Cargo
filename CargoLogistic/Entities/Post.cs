using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.Entities.Users;
using CargoLogistic.Domain.Events;


namespace CargoLogistic.Domain.Entities
{
    public abstract class Post : EntityBase
    {
        public virtual ApplicationUser User { get; set; }
        public virtual DateTime PublicationDate { get; set; } 
        public virtual DateTime DateFrom { get;  set; }
        public virtual DateTime DateTo { get;  set; }
        public virtual Location LocationFrom { get; } 
        public virtual Location LocationTo { get; }
        public virtual PostTransportType PostTransportType { get; set; }
        public virtual bool Status { get; set; }

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
           
       
        protected Post(ApplicationUser user, DateTime dateFrom, DateTime dateTo, 
            Location locationFrom, Location locationTo, PostTransportType postTransportType, double price,
            bool status, string additionalInformation)
        {
            User = user;
            PublicationDate = DateTime.Now;
            DateFrom = dateFrom;
            DateTo = dateTo;
            LocationFrom = locationFrom;
            LocationTo = locationTo;
            PostTransportType = postTransportType;
            Status = status;
            Price = price;
            AdditionalInformation = additionalInformation;
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
