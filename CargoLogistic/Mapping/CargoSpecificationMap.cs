using CargoLogistic.DAL.Entities;
using FluentNHibernate.Mapping;


namespace CargoLogistic.DAL.Mapping
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