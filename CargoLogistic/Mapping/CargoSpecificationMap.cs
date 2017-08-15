using CargoLogistic.Domain;
using FluentNHibernate.Mapping;
using Remotion.Linq.Parsing.Structure.ExpressionTreeProcessors;

namespace CargoLogistic.Mapping
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