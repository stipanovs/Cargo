using CargoLogistic.Domain;
using CargoLogistic.Domain.Users;
using FluentNHibernate.Mapping;

namespace CargoLogistic.Mapping
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("Person");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName).Column("FirstName");
            Map(x => x.LastName).Column("LastName");
            Map(x => x.PhoneNumber).Column("PhoneNumber");
            Map(x => x.Email).Column("Email");
            Map(x => x.Address).Column("Address");

        }
    }
}