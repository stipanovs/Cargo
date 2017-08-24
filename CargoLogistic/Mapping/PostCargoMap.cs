using CargoLogistic.Domain.Entities;
using FluentNHibernate.Mapping;

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
            References(x => x.LocationFrom).Column("LocalityFromId");
            References(x => x.LocationTo).Column("LocalityToId");
            Map(x => x.Price).Column("Price");
            References(x => x.Specification).Column("CargoSpecificationId");
            Map(x => x.AdditionalInformation).Column("AdditionalInformation");
          
        }
    }
}