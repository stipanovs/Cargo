using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL;
using CargoLogistic.DAL.Repository;
using static System.Console;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Cfg;
using NHibernate.Driver;
using NHibernate.Dialect;
using System.Reflection;
using CargoLogistic.DAL.Entities;
using CargoLogistic.NHibernateInitialize;
using NHibernate.SqlCommand;
using NHibernate.Criterion;
using NHibernate.Transform;
using NHibernate;

namespace CargoLogistic
{
    class Program
    {
        static void Main(string[] args)
        {

            //App_Start.NHibernateProfilerBootstrapper.PreStart();


            #region countries

            //var moldova = new Country("Moldova", 648, "MD");
            //var italia = new Country("Italia", 040, "IT");
            //var ucraina = new Country("Ucraina", 854, "UA");
            //var russia = new Country("Russia", 643, "RU");
            //var countries = new List<Country>() { moldova, italia, ucraina, russia };

            #endregion

            #region Location

            //Location locChisinau = new Location(new City("Chisinau", moldova), new AddressDetail("2048", "str. Stefan cel mare 34"));
            //Location locBardar = new Location(new Village("Bardar", moldova), new AddressDetail("2048", "no street"));
            //Location locMoscow = new Location(new City("Moscow", russia));
            //Location locRome = new Location(new Village("Padovana", italia));
            //Location locKiev = new Location( locality: new City("Kiev", ucraina));

            #endregion

            #region PostData

            //// posting new information about Transport Freight 
            //var post1 = new PostCargo(new DateTime(2017, 7, 07), new DateTime(2017, 7, 09), locMoscow, locRome, 2450.00, "call 379166741");
            //var post2 = new PostCargo(new DateTime(2017, 7, 07), new DateTime(2017, 7, 09), locMoscow, locRome, 3875.00, "call 379166741");
            //var post3 = new PostTransport(new DateTime(2017, 7, 10), new DateTime(2017, 7, 12), locKiev, locChisinau, 4100.00, "call 379166741");
            //var post4 = new PostCargo(new DateTime(2017, 7, 14), new DateTime(2017, 7, 12), locKiev, locBardar, 3800.00, "call 379166741");
            //// named arg
            //var post5 = new PostCargo(locationFrom: locChisinau, locationTo: locKiev,
            //    dataFrom: new DateTime(2017, 07, 20), dateTo: new DateTime(2017, 08, 02), price: 3500.00, additionalInformation: "call 379166741");
            #endregion

            #region Comparer

            //// ex. IEqualityComparer
            //var dict = new Dictionary<Country, string>(new CountryEqalityComparer());
            //// ex. Icomparer
            //countries.Sort(new CountryComparer());

            #endregion

            #region EVENTS

            //// new users 

            //User user1 = new User("Stipanov", "Sergiu", 35);
            //User user2 = new User("Maracuta", "Andrei", 27);

            //// subscribe to event price rice
            //user1.RegisterToEvent(post1);
            //user2.RegisterToEvent(post1);

            //// Register weak events by WeakEventManager
            //user1.RegisterToEventWeakMethod(post2);
            //user1.RegisterToEventWeakMethod(post3);

            //// simulate change price
            //post1.Price = 3750;
            //post2.Price = 2550;
            //Console.WriteLine();

            //// UnregisterToEvent
            //user2.UnregisterToEvent(post1);
            //user1.UnregisterToEventWeakMethod(post3);

            //// simulate change price
            //post1.Price = 3800;

            #endregion

            #region Stream

            //string fileName = @"C:\Users\sergiu.stipanov\OneDrive\Materiale\files\Repository.txt";
            //FileInfo f = new FileInfo(fileName);
            //StreamWriter sr = f.AppendText();
            //sr.WriteLine("hello");
            //sr.Close();
            //Console.WriteLine(sr);


            //Console.WriteLine();

            ////save countries to file

            //Repository<Country> countryRepository = new Repository<Country>();

            //foreach (var c in countries)
            //{
            //    countryRepository.SaveToFile(c, fileName);
            //}
            #endregion

            #region FACTORY
            //PostFactory postFactory = new PostFactory();

            //var beerCargoSpecification = new CargoSpecification("Karlsberg Beer", 7.5, 3.7);
            //var woodCargoSpecification = new CargoSpecification("Wood", 15.45, 27.00);
            //var truckSpecification = new TransportSpecification(PostTransportType.Truck, 20.00, 35.00);
            //var minibusSpecification = new TransportSpecification(PostTransportType.Minibus, 6.00, 7.8);

            //var newPostCargo = postFactory.CreateNewPost(
            //    new DateTime(2017, 07, 25), new DateTime(2017, 08, 05), locRome,
            //    locChisinau, 4750.00, "Call 373 6544518", beerCargoSpecification);

            //Console.WriteLine(newPostCargo.ToString());
            //WriteLine(newPostCargo is PostCargo);

            //var newPostTransport = postFactory.CreateNewPost(new DateTime(2017, 07, 08), new DateTime(2017, 08, 31), locMoscow,
            //    locChisinau, 1875.00, "For more information Call +3739547821", truckSpecification);

            //Console.WriteLine(newPostTransport);
            //Console.WriteLine(newPostTransport is PostCargo);

            #endregion

            #region NHIBERNATE

            NHibernateProfiler.Initialize();

            #region CRUD

            //var countries = GetAllCountries();
            //var nedederlada = GetCountryByAlpha2Code("NL");
            //CreateNewCountry(new Country ( "Spain", 724, "ES"));
            //CreateNewCountry(new Country("ESTONIA", 233, "EE"));
            //CreateNewCountry(new Country("LUXEMBOURG", 442, "LU"));
            //CreateNewCountry(new Country("NETHERLANDS", 528, "NL"));
            //CreateNewCity(new City("Barcelona", GetCountryByAlpha2Code("ES")));
            //CreateNewCity(new City("Madrid", GetCountryByAlpha2Code("ES")));
            //DeleteCountryByAlphaCode("ES");
            //var amsterdam = new City("Amsterdam");


            #endregion

            #region QueryOver
            //using (var session = NHibernateProvider.GetSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {

            //        //var countries = session.QueryOver<Country>()
            //        //    .Where(c => c.Alpha2Code == "RO")
            //        //    .Select(c => c.Name)
            //        //    .SingleOrDefault<string>();


            //        //var countries = session.QueryOver<Country>()
            //        //    .Where(c => c.Alpha2Code == "RO")
            //        //    .Select(c => c.NumericCode)
            //        //    .SingleOrDefault<int>();


            //        //var countries = session.QueryOver<Country>()
            //        //    .Where(c => c.Alpha2Code == "IT")
            //        //    .SelectList(list => list
            //        //    .Select(c => c.Name)
            //        //    .Select(c => c.Alpha2Code)
            //        //    .Select(x => x.NumericCode))
            //        //    .List<object[]>();


            //        //Country country = null;
            //        //var country_projection =  session.QueryOver(() => country)
            //        //    .Select(Projections.ProjectionList()
            //        //    .Add(Projections.Property(() => country.Name))
            //        //    .Add(Projections.Property(() => country.NumericCode)))
            //        //    .List<object[]>();

            //        //City city = null;
            //        //var city_projection = session.QueryOver(() => city)
            //        //    .Select(Projections.ProjectionList()
            //        //    .Add(Projections.Property(() => city.Name))
            //        //    .Add(Projections.Property(() => city.Country.Id)))
            //        //    .List<object[]>();


            //        //Country country = null;
            //        //City city = null;
            //        //var query = session.QueryOver(() => country)
            //        //    .JoinAlias(c => c.Locations, () => city)
            //        //    .List<Country>();

            //        //Country country = null;
            //        //City city = null;
            //        //var query = session.QueryOver(() => country)
            //        //    .JoinAlias(c => c.Locations, () => city)
            //        //    .TransformUsing(Transformers.DistinctRootEntity)
            //        //    .List<Country>();


            //        //Country country = null;
            //        //City city = null;
            //        //Location location = null;
            //        //var query = session.QueryOver(() => location)
            //        //    .JoinQueryOver(l => l.Locality, () => city)
            //        //    .JoinQueryOver(c => c.Country, () => country)
            //        //    .List();

            //        //Country country = null;
            //        //City city = null;
            //        //Location location = null;
            //        //var query = session.QueryOver(() => location)
            //        //    .JoinAlias(l => l.Locality, () => city)
            //        //    .JoinAlias(() => city.Country, () => country)
            //        //    .List();


            //        //Country country = null;
            //        //City city = null;
            //        //Location location = null;

            //        //var LocalityFromMoldova = session.QueryOver(() => location)
            //        //   .JoinAlias(l => l.Locality, () => city)
            //        //   .JoinAlias(() => city.Country, () => country)
            //        //   .Where(() => country.Alpha2Code == "MD" )
            //        //   .SelectList(list => list
            //        //   .Select(() => country.Name)
            //        //   .Select(() => city.Name)
            //        //   .Select(x => x.Line1))
            //        //   .List<object[]>();

            //        // group

            //        //City city = null;
            //        //Location location = null;
            //        //// Cite adresse concerete am in fiecare City
            //        //var group = session.QueryOver(() => location)
            //        //    .JoinAlias(() => location.Locality, () => city)
            //        //    .SelectList(list => list
            //        //    .SelectGroup(() => city.Name)
            //        //    .SelectCount(() => city.Id))
            //        //    .List<object[]>();

            //        //// Having
            //        //City city = null;
            //        //Location location = null;
            //        //// mai mult de 2 adresse concerete in fiecare City
            //        //var group = session.QueryOver(() => location)
            //        //    .JoinAlias(() => location.Locality, () => city)
            //        //    .SelectList(list => list
            //        //    .SelectGroup(() => city.Name)
            //        //    .SelectCount(() => city.Id))
            //        //    .Where(Restrictions.Gt(Projections.Count(Projections.Property(() => city.Id)), 2))
            //        //    .List<object[]>();



            //        //  AliasToBean
            //        // Returnam detaile la PostCargo
            //        //PostCargo post = null;
            //        //Locality cityFrom = null;
            //        //Locality cityTo = null;
            //        //Location locationFrom = null;
            //        //Location locationTo = null;
            //        //Country countryFrom = null;
            //        //Country countryTo = null;
            //        //PostDetailRow postDetailRow = null;


            //        //IList<PostDetailRow> query = session.QueryOver(() => post)
            //        //    .JoinAlias(p => p.LocationFrom, () => locationFrom)
            //        //    .JoinAlias(() => post.LocationTo, () => locationTo)
            //        //    .JoinAlias(() => locationFrom.Locality, () => cityFrom)
            //        //    .JoinAlias(() => locationTo.Locality, () => cityTo)
            //        //    .JoinAlias(() => cityFrom.Country, () => countryFrom)
            //        //    .JoinAlias(() => cityTo.Country, () => countryTo)
            //        //    .SelectList(list => list
            //        //    .Select(() => post.DateFrom).WithAlias(() => postDetailRow.DateFrom)
            //        //    .Select(() => post.DateTo).WithAlias(() => postDetailRow.DateTo)
            //        //    .Select(() => countryFrom.Name).WithAlias(() => postDetailRow.CountryFrom)
            //        //    .Select(() => cityFrom.Name).WithAlias(() => postDetailRow.CityFrom)
            //        //    .Select(() => countryTo.Name).WithAlias(() => postDetailRow.CountryTo)
            //        //    .Select(() => cityTo.Name).WithAlias(() => postDetailRow.CityTo)
            //        //    .Select(x => x.Price).WithAlias(() => postDetailRow.Price))
            //        //    .TransformUsing(Transformers.AliasToBean<PostDetailRow>())
            //        //    .List<PostDetailRow>();

            //        // DistinctRootEntity (fara distinct aveam 12, cu am 5, In SQL Distinc nu apare)
            //        //Country country = null;
            //        //City city = null;

            //        //var query = session.QueryOver(() => country)
            //        //    .JoinAlias(c => c.Locations, () => city)
            //        //    .Where(() => country.NumericCode < 650)
            //        //    .TransformUsing(Transformers.DistinctRootEntity)
            //        //    .List<Country>();

            //        //// Future , FutureValue

                        ////IEnumerable<Country> countries = session.QueryOver<Country>()
                        ////                           .Future<Country>();

                        ////IFutureValue<int> numberOffCitys = session.QueryOver<City>()
                        ////    .SelectList(list => list
                        ////    .SelectCount(x => x.Id))
                        ////    .FutureValue<int>();

                        ////int numCity = numberOffCitys.Value;


            //    }

            //    Console.WriteLine("Ok");

            //}

            #endregion

            #region QueryOver Advanced

            using (var session = NHibernateProvider.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    // 1 
                    //var countrySubquery = QueryOver.Of<Country>()
                    //    .Where(x => x.NumericCode > 458)
                    //    .Select(x => x.Id);

                    //var query2 = session.QueryOver<City>()
                    //    .WithSubquery.WhereProperty(x => x.Country)
                    //    .In(countrySubquery)
                    //    .Select(x=> x.Name)
                    //    .List<string>();

                    // FindMostPopularCityInCountry , cel mai preferat loc de pornire
                    Country country = null;
                    Country innerCountry = null;
                    City city = null;
                    Locality place = null;
                    Village village = null;
                    PostCargo post = null;
                    Location locationFrom = null;

                    //// orasul cel mai des intilnit la plecare
                    //var query1 = QueryOver.Of(() => post)
                    //    .JoinAlias(() => post.LocationFrom, () => locationFrom)
                    //    .JoinAlias(() => locationFrom.Locality, () => place)
                    //    .SelectList(list => list
                    //    .SelectGroup(() => place.Id)
                    //    .SelectCount(() => place.Id))
                    //    .OrderBy(Projections.Count(() => place.Id)).Desc
                    //    .Take(1);

                    /*
                     QueryOver.Of(() => post)
                           .JoinAlias(() => post.LocationFrom, () => locationFrom)
                           .JoinAlias(() => locationFrom.Locality, () => place)
                           .SelectList(list1 => list1
                           .SelectCount(() => place.Country))
                           .Where(Restrictions.EqProperty(Projections.Property(()=>place.Country.Id),
                            Projections.Property(()=>country.Id)))).WithAlias(() => obj)
                     */
                    //// cite ori apare Country in postari
                    //var subquery = QueryOver.Of(() => post)
                    //       .JoinAlias(() => post.LocationFrom, () => locationFrom)
                    //       .JoinAlias(() => locationFrom.Locality, () => place)
                    //       .SelectList(list1 => list1
                    //       .SelectCount(() => place.Country))
                    //       .Where(Restrictions.EqProperty(Projections.Property(() => place.Country.Id),
                    //        Projections.Property(() => country.Id)));

                                 
                    //var query3 = session.QueryOver(() => country)
                    //    .SelectList(list => list
                    //    .Select(() => country.Name)
                    //    .Select(() => country.NumericCode)
                    //    .SelectSubQuery(subquery))
                    //    .OrderBy(Projections.SubQuery(subquery)).Desc
                    //   .List<object>();
                      
                      
                    //Console.WriteLine("ok");
                    
                }

                Console.WriteLine("Ok hokey");
            }


            #endregion

            var repository = new Repository<Country>();
            repository.Dispose();
            //var rominia = repository.GetById(2);
            //rominia.NumericCode = 777;
            //repository.Save(rominia);
            #endregion

            Console.ReadKey();
        }




        #region repositories 

        private static void CreateNewCity(City city)
        {
            using (var session = NHibernateProvider.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    session.SaveOrUpdate(city);
                    transaction.Commit();
                }
            }
        }
        public static IList<Country> GetAllCountries()
        {
            using (var session = NHibernateProvider.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                     var countries = session.QueryOver<Country>()
                        .List<Country>();

                    return countries;
                }
            }
        }

        private static Country GetCountryByAlpha2Code(string alphaCode)
        {
            using (var session = NHibernateProvider.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var country = session.QueryOver<Country>()
                        .Where(x => x.Alpha2Code == alphaCode)
                        .SingleOrDefault();

                                        
                    return country;
                    
                }
            }
        }

        private static void DeleteCountryByAlphaCode(string alphaCode)
        {
            using (var session = NHibernateProvider.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    var country = session.QueryOver<Country>()
                        .Where(x => x.Alpha2Code == alphaCode)
                        .SingleOrDefault<Country>();

                    try
                    {
                        session.Delete(country);
                        transaction.Commit();
                    }
                    catch(ArgumentNullException e)
                    {
                       Console.WriteLine(e.Message);
                    }
                    

                }
            }
        }

        
        private static void CreateNewCountry(Country country)
        {
            using (var session = NHibernateProvider.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    session.SaveOrUpdate(country);
                    transaction.Commit();
                }
            }
        }
        #endregion

    }
    
    
}


