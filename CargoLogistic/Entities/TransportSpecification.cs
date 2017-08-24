using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain;
using CargoLogistic.Domain.Entities.SpecificationType;


namespace CargoLogistic.Domain.Entities
{
    
    public class TransportSpecification : EntityBase, ISpecification
    {
        public virtual TransportType TransportType { get; set; }
        public virtual double WeightCapacity { get; set; }
        public virtual double VolumeCapacity { get; set; }

        public TransportSpecification(TransportType type, double weightCapacity, double voluleCapacity)
        {
            TransportType = type;
            WeightCapacity = weightCapacity;
            VolumeCapacity = voluleCapacity;
        }

        protected TransportSpecification()
        {
            
        }

       
    }
}
