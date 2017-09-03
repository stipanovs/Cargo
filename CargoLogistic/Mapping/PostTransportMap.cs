using CargoLogistic.Domain.Entities;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace CargoLogistic.Domain.Mapping
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
            Map(x => x.Price).Column("Price");
            Map(x => x.Status).Column("Status");
            Map(x => x.AdditionalInformation).Column("AdditionalInformation");
            References(x => x.Specification).Column("TransportSpecificationId");
            References(x => x.LocationFrom).Column("LocationFromId");
            References(x => x.LocationTo).Column("LocationToId");
            References(x => x.User).Column("UserId");
            Map(x => x.PostTransportType).CustomType<EnumStringType<PostTransportType>>();
        }
    }
}