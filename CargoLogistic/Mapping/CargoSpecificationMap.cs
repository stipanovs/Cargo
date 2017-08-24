﻿using CargoLogistic.Domain.Entities;
using FluentNHibernate.Mapping;


namespace CargoLogistic.Domain.Mapping
{
    public class CargoSpecificationMap : ClassMap<CargoSpecification>
    {
        public CargoSpecificationMap()
        {
            Table("CargoSpecification");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Description).Column("Description");
            Map(x => x.Weight).Column("Weight");
            Map(x => x.Volume).Column("Volume");
            
        }
    }
}