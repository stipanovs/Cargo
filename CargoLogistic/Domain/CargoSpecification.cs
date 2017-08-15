﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.SpecificationType;


namespace CargoLogistic.Domain
{
    
    public class CargoSpecification : EntityBase , ISpecification
    {
        public virtual string Description { get; set; }
        public virtual double Weight { get; set; }
        public virtual double Volume { get; set; }

        public CargoSpecification(string description, double weight = 0.00, double volume = 0.00)
        {
            Description = description;
            Weight = weight;
            Volume = volume;
        }

        protected CargoSpecification()
        {
            
        }
    }
}
