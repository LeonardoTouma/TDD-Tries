using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViedoStore_BI;
using ViedoStore_BI.Logic;
using ViedoStore_TESTS.TestDataSource;

namespace ViedoStore_TESTS
{
    [TestFixture]
    public class VideoStoreTests
    {
        private VideoStore sut;
        [SetUp]
        public void Setup()
        {
            sut = new VideoStore();
        }
        //public VideoStore SetupMethod_For_VideoStore()
        //{
        //    sut = new VideoStore();
        //    return sut;
        //}
        //[TestCaseSource(typeof(DataSourceTest_Giver_Movie))]
        public void AddMovie(Movie movie)
        {
            sut.AddMovie(movie);

            Assert.IsNotNull(movie);
            Assert.That(sut.GetMovies, Is.Unique);

        }
        [TestCase("Titanic", "123")]
        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
            sut.AddRental(movieTitle, socialSecurityNumber);
            Assert.IsNotNull(movieTitle);
            Assert.IsNotEmpty(movieTitle);
            Assert.IsNotEmpty(socialSecurityNumber);
        }
        [Test]
        public void GetCustomers_Thrue_List()
        {
            sut.GetCustomers_Thrue_List();
            Assert.IsNotNull(sut.GetCustomers_Thrue_List());
            Assert.That(sut.GetCustomers_Thrue_List, Is.Unique);
            //Assert.That(sut.GetCustomers_Thrue_List, Is.All.Not.Empty);
        }
        [Test]
        [TestCase("123")]
        [TestCase("123 ")]
        [TestCase("1-'¨2<23")]
        public void GetRentalsFor([Values("976")]string socialSecurityNumber)
        {
            Assert.IsNotNull(sut.GetRentalsFor(socialSecurityNumber));
            sut.GetRentalsFor(socialSecurityNumber);

        }
        [TestCase("Peter", "456")]
        [TestCase("1", "456")]
        [TestCase("¤!()/=", "123")]
        public void RegisterCustomer([Values("peter")]string name, [Values("4236")] string socialSecurityNumber)
        {
            sut.RegisterCustomer(name, socialSecurityNumber);
            Assert.IsNotEmpty(name);
            Assert.IsNotEmpty(socialSecurityNumber);
            Assert.IsNotNull(name);
            Assert.IsNotNull(socialSecurityNumber);
        }
        //[TestCaseSource(typeof(DataSourceTest_Giver_Rental))]
        public void RemoveRental([Values("sad")]string movieTitle, [Values("123")] string socialSecurityNumber)
        {
            sut.RemoveRental(movieTitle, socialSecurityNumber);
            Assert.IsNotNull(movieTitle);
            Assert.IsNotNull(socialSecurityNumber);
            Assert.IsNotEmpty(movieTitle);
            Assert.IsNotEmpty(socialSecurityNumber);
        }
        [TestCase("Peterpan", "5443")]
        [TestCase("5443", "Peter pan")]
        public void RentMovie([Values("lksad")]string movieTitle, [Values("3241")] string socialSecurityNumber)
        {
            sut.RentMovie(movieTitle, socialSecurityNumber);
            //------------------TEST-----------------
            Assert.IsNotNull(movieTitle);
            Assert.IsNotNull(socialSecurityNumber);
        }
        [TestCase("Tilasa", "9887")]
        [TestCase("Tilasa ", "9887")]
        [TestCase("9887", "asdax ")]
        public void ReturnMovie([Values("bnvcvas")]string movieTitle, [Values("66453")]string socialSecurityNumber)
        {
            sut.ReturnMovie(movieTitle,socialSecurityNumber);
            Assert.IsNotNull(movieTitle);
            Assert.IsNotNull(socialSecurityNumber);
        }
    }
}
