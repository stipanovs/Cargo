using CargoLogistic.DAL.Entities;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace CargoLogistic.DAL.Mapping
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
            Map(x => x.NumberOfViews).Column("NumberOfViews");
            References(x => x.Specification).Column("CargoSpecificationId").Cascade.Delete();
            References(x => x.LocationFrom).Column("LocationFromId").Cascade.Delete();
            References(x => x.LocationTo).Column("LocationToId").Cascade.Delete();
            References(x => x.User).Column("UserId");
            Map(x => x.PostTransportType).CustomType<EnumStringType<PostTransportType>>().Column("TransportType");

        }
    }
}