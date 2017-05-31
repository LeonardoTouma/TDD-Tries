using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViedoStore_BI;

namespace ViedoStore_TESTS
{
    [TestFixture]
    public class VideoStoreTests : IVideoStore
    {
        public List<Movie> movies = new List<Movie>();
        public List<Rental> rentals = new List<Rental>();
        public List<Customer> customers = new List<Customer>();
        [TestCaseSource(typeof(Movie))]
        public void AddMovie(Movie movie)
        {
            Movie movie2 = new Movie()
            {
                DateWhenAdded = DateTime.Now,
                IsRented = true,
                movieTitle = movie.movieTitle
            };
            Assert.AreEqual(movie, movie2);

        }
        [TestCase("Titanic", "123")]
        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
            Rental rent = new Rental()
            {
                IsRented = true,
                Movies = movies.Where(X => X.movieTitle == movieTitle).ToList(),
                Customers = customers.Where(X => X.SSN == socialSecurityNumber).ToList()
            };
            rentals.Add(rent);
            Assert.IsNotNull(rent);
            Assert.IsTrue(rent.IsRented);

        }
        [Test]
        public List<Customer> GetCustomers()
        {
            Assert.IsNotNull(customers);
            return customers;
        }
        [Test]
        public List<Rental> GetRentalsFor(string socialSecurityNumber)
        {
            var itemtoget = rentals.Where(X => X.Customers.FirstOrDefault(z => z.SSN == socialSecurityNumber) ==
            customers.Where(c => c.SSN == socialSecurityNumber)).ToList();
            Assert.IsNotNull(itemtoget);
            Assert.IsNotEmpty(itemtoget);
            return itemtoget;
        }
        [TestCase("Peter", "456")]
        [TestCase("1", "456")]
        [TestCase("¤!()/=", "123")]

        public void RegisterCustomer(string name, string socialSecurityNumber)
        {
            Customer cust = new Customer()
            {
                SSN = socialSecurityNumber,
                Name = name,
                IsRegisterd = true,
            };
            customers.Add(cust);
            Assert.IsNotNull(cust);
            Assert.IsTrue(cust.IsRegisterd);
        }
        [TestCaseSource(typeof(Rental))]
        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            var ItemToRemove = rentals.Where(x => x.Movies.Where(z => z.movieTitle == movieTitle)
           == movies.Where(p => p.movieTitle == movieTitle).ToList());
            var ItemToRemoveBasedOFSSN = rentals.Where(q => q.Customers.Where(w => w.SSN == socialSecurityNumber)
            == customers.Where(e => e.SSN == socialSecurityNumber));
            rentals.Remove(ItemToRemove.First());
            rentals.Remove(ItemToRemoveBasedOFSSN.First());
            //------------------TEST-----------------
            Assert.IsNotNull(ItemToRemove);
            Assert.IsNotNull(ItemToRemoveBasedOFSSN);
        }
        [TestCase("Peter pan", "5443")]
        public void RentMovie(string movieTitle, string socialSecurityNumber)
        {
            var rent = new Rental()
            {
                Customers = customers.Where(x => x.SSN == socialSecurityNumber).ToList(),
                Movies = movies.Where(x => x.movieTitle == movieTitle).ToList(),
                DateWhenRented = DateTime.Now,
                IsRented = true,
            };
            rentals.Add(rent);
            //------------------TEST-----------------
            Assert.IsNotNull(rent);
            Assert.IsTrue(rent.IsRented);
        }
        [TestCase("Tilasa", "9887")]
        public void ReturnMovie(string movieTitle, string socialSecurityNumber)
        {
            foreach (var item in rentals)
            {
                foreach (var item1 in item.Movies)
                {
                    foreach (var item2 in item.Customers)
                    {
                        if (item1.movieTitle == movieTitle)
                        {
                            if (item2.SSN == socialSecurityNumber)
                            {
                                var ItemToReMove = rentals.Where
                                (X => X.Movies.FirstOrDefault(p => p.movieTitle == item1.movieTitle)
                                == movies.FirstOrDefault(c => c.movieTitle == movieTitle));
                                var ItemToRentBasedOFSSN = rentals.Where
                                (q => q.Customers.FirstOrDefault(w => w.SSN == socialSecurityNumber)
                                == customers.Where(e => e.SSN == item2.SSN))
                                .FirstOrDefault();
                                rentals.Remove(ItemToReMove.FirstOrDefault());
                                rentals.Remove(ItemToRentBasedOFSSN);
                                //------------------
                                Assert.IsNotNull(ItemToReMove);
                                Assert.IsNotNull(ItemToRentBasedOFSSN);
                            }
                        }
                    }
                }
            }

            //var ItemToRent = rentals.Where(x => x.Movies.Where(z => z.movieTitle == movieTitle)
            //== movies.Where(p => p.movieTitle == movieTitle)).FirstOrDefault();
            //var ItemToRentBasedOFSSN = rentals.Where(q => q.Customers.Where(w => w.SSN == socialSecurityNumber)
            //== customers.Where(e => e.SSN == socialSecurityNumber)).FirstOrDefault();



            //rentals.Remove(ItemToRent);
            //rentals.Remove(ItemToRentBasedOFSSN);
            //----------------TEST--------------
            
        }

    }
}
