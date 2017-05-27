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
        [TestCase("Titanic",  "123")]
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
        public List<Customer> GetCustomers()
        {
            return customers;
        }
        public List<Rental> GetRentalsFor(string socialSecurityNumber)
        {
            var itemtoget = rentals.Where(X => X.Customers.FirstOrDefault(z => z.SSN == socialSecurityNumber) ==
            customers.Where(c => c.SSN == socialSecurityNumber)).ToList();
            return itemtoget;
        }
        [TestCase("Peter", "456")]
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

        public void ReturnMovie(string movieTitle, string socialSecurityNumber)
        {
            var ItemToRent = rentals.Where(x => x.Movies.Where(z => z.movieTitle == movieTitle)
            == movies.Where(p => p.movieTitle == movieTitle).ToList());
            var ItemToRentBasedOFSSN = rentals.Where(q => q.Customers.Where(w => w.SSN == socialSecurityNumber)
            == customers.Where(e => e.SSN == socialSecurityNumber));
            foreach (var item in ItemToRent)
            {
                foreach (var item1 in ItemToRentBasedOFSSN)
                {
                    item.IsRented = item1.IsRented;
                    item.LateReturns = item1.LateReturns;
                    item.ID = item1.ID;
                    item.Name = item1.Name;
                    item.AmountOfMoviesRented = item1.AmountOfMoviesRented;
                }
            }
            rentals.Remove(ItemToRent.First());
            rentals.Remove(ItemToRentBasedOFSSN.First());
            //----------------TEST--------------
            Assert.IsNotNull(ItemToRent);
            Assert.IsNotNull(ItemToRentBasedOFSSN);
        }

    }
}
