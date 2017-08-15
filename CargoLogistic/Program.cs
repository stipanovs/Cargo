using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain;
using CargoLogistic.Repository;
using CargoLogistic.Events;
using CargoLogistic.Domain.SpecificationType;
using static System.Console;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Cfg;
using NHibernate.Driver;
using NHibernate.Dialect;
using System.Reflection;
using CargoLogistic.Domain.Users;
using CargoLogistic.NHibernateInitialize;
using NHibernate.SqlCommand;

namespace CargoLogistic
{
   class Program
    {
        static void Main(string[] args)
        {

            #region countries

            //var moldova = new Country("Moldova", 648, "MD");
            //var italia = new Country("Italia", 040, "IT");
            //var ucraina = new Country("Ucraina", 854, "UA");
            //var russia = new Country("Russia", 643, "RU");
            //var countries = new List<Country>() { moldova, italia, ucraina, russia };

            #endregion

            #region Location

            //Locality locChisinau = new Locality(new City("Chisinau", moldova), new AddressDetail("2048", "str. Stefan cel mare 34"));
            //Locality locBardar = new Locality(new Village("Bardar", moldova), new AddressDetail("2048", "no street"));
            //Locality locMoscow = new Locality(new City("Moscow", russia));
            //Locality locRome = new Locality(new Village("Padovana", italia));
            //Locality locKiev = new Locality( localityPlace: new City("Kiev", ucraina));

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
            //var truckSpecification = new TransportSpecification(TransportType.Truck, 20.00, 35.00);
            //var minibusSpecification = new TransportSpecification(TransportType.Minibus, 6.00, 7.8);

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


            // Save - Create
            using (var session = NHibernateProvider.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var turcia = new Country("Turcia", 845, "TR");
                    session.SaveOrUpdate(turcia);
                    transaction.Commit();
                    Console.WriteLine("Am facut commit");

                }
            }

            //https://www.codeproject.com/Articles/1178251/NHibernate-Introduction-configuration-CRUD-with-MV

            // Get all

            // Get details

            // Delete





            #endregion

            Console.ReadKey();
        }
   }
    
    
}

