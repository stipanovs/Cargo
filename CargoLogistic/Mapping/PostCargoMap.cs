using CargoLogistic.Domain.Entities;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace CargoLogistic.Domain.Mapping
{
    public class PostCargoMap : ClassMap<PostCargo>
    {
        public PostCargoMap()
        {
            Table("PostCargo");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.PublicationDate).Column("PublicationDate");
            Map(x => x.DateFrom).Column("DateFrom");
            Map(x => x.DateTo).Column("DateTo");
            Map(x => x.Price).Column("Price");
            Map(x => x.AdditionalInformation).Column("AdditionalInformation");
            Map(x => x.Status).Column("Status");
            References(x => x.Specification).Column("CargoSpecificationId");
            References(x => x.LocationFrom).Column("LocationFromId");
            References(x => x.LocationTo).Column("LocationToId");
            References(x => x.User).Column("UserId");
            Map(x => x.PostTransportType).CustomType<EnumStringType<PostTransportType>>().Column("TransportType");

        }
    }
}