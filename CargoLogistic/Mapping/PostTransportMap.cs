using CargoLogistic.Domain;
using FluentNHibernate.Mapping;

namespace CargoLogistic.Mapping
{
    public class PostTransportMap : ClassMap<PostTransport>
    {
        public PostTransportMap()
        {
            Table("PostTransport");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.PublicationDate).Column("PublicationDate");
            Map(x => x.DateFrom).Column("DateFrom");
            Map(x => x.DateTo).Column("DateTo");
            References(x => x.LocationFrom).Column("LocalityFromId");
            References(x => x.LocationTo).Column("LocalityToId");
            Map(x => x.Price).Column("Price");
            References(x => x.Specification).Column("TransportSpecificationId");
            Map(x => x.AdditionalInformation).Column("AdditionalInformation");
        }
    }
}