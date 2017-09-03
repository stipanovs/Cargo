
using CargoLogistic.Domain.Entities;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace CargoLogistic.Domain.Mapping
{
    public class TransportSpecificationMap : ClassMap<TransportSpecification>
    {
        public TransportSpecificationMap()
        {
            Table("TranportSpecification");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.WeightCapacity).Column("WeightCapacity");
            Map(x => x.VolumeCapacity).Column("VolumeCapacity");
            Map(x => x.Description).Column("Description");

        }
    }
}