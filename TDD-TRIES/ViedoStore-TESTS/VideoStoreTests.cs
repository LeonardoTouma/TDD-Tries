using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViedoStore_BI;
using ViedoStore_BI.Logic;

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
        public VideoStore SetupMethod_For_VideoStore()
        {
            sut = new VideoStore();
            return sut;
        }
        [TestCaseSource(typeof(Movie))]
        public void AddMovie(Movie movie)
        {
            var sut = SetupMethod_For_VideoStore();
            sut.AddMovie(movie);

            Assert.IsNotNull(movie);

        }
        [TestCase("Titanic", "123")]
        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
            var sut = SetupMethod_For_VideoStore();
            sut.AddRental(movieTitle, socialSecurityNumber);
            Assert.IsNotNull(movieTitle);
            Assert.IsNotEmpty(movieTitle);
            Assert.IsNotEmpty(socialSecurityNumber);

        }
        [Test]
        public void GetCustomers_Thrue_List()
        {
            var sut = SetupMethod_For_VideoStore();
            sut.GetCustomers_Thrue_List();
            Assert.IsNotNull(sut.GetCustomers_Thrue_List());
        }
        [Test]
        [TestCase("123")]
        [TestCase("123 ")]
        [TestCase("1-'¨2<23")]
        public void GetRentalsFor(string socialSecurityNumber)
        {
            var sut = SetupMethod_For_VideoStore();
            Assert.IsNotNull(sut.GetRentalsFor(socialSecurityNumber));
            sut.GetRentalsFor(socialSecurityNumber);

        }
        [TestCase("Peter", "456")]
        [TestCase("1", "456")]
        [TestCase("¤!()/=", "123")]

        public void RegisterCustomer(string name, string socialSecurityNumber)
        {
            var sut = SetupMethod_For_VideoStore();
            sut.RegisterCustomer(name, socialSecurityNumber);
            Assert.IsNotEmpty(name);
            Assert.IsNotEmpty(socialSecurityNumber);
            Assert.IsNotNull(name);
            Assert.IsNotNull(socialSecurityNumber);
        }
        [TestCaseSource(typeof(Rental))]
        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            var sut = SetupMethod_For_VideoStore();
            sut.RemoveRental(movieTitle, socialSecurityNumber);
            Assert.IsNotNull(movieTitle);
            Assert.IsNotNull(socialSecurityNumber);
            Assert.IsNotEmpty(movieTitle);
            Assert.IsNotEmpty(socialSecurityNumber);
        }
        [TestCase("Peterpan", "5443")]
        [TestCase("5443", "Peter pan")]
        public void RentMovie(string movieTitle, string socialSecurityNumber)
        {
            var sut = SetupMethod_For_VideoStore();
            sut.RentMovie(movieTitle, socialSecurityNumber);
            //------------------TEST-----------------
            Assert.IsNotNull(movieTitle);
            Assert.IsNotNull(socialSecurityNumber);
        }
        [TestCase("Tilasa", "9887")]
        [TestCase("Tilasa ", "9887")]
        [TestCase("9887", "asdax ")]
        public void ReturnMovie(string movieTitle, string socialSecurityNumber)
        {
            var sut = SetupMethod_For_VideoStore();
            sut.ReturnMovie(movieTitle,socialSecurityNumber);
            Assert.IsNotNull(movieTitle);
            Assert.IsNotNull(socialSecurityNumber);
        }
    }
}
