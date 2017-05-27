using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViedoStore_BI.Logic
{
    class VideoStore : IVideoStore
    {
        List<Movie> Movies = new List<Movie>();
        List<Customer> Customers = new List<Customer>();
        List<Rental> Rentals = new List<Rental>();
        public void AddMovie(Movie movie)
        {
            var mov = new Movie()
            {
                IsRented = true,
                movieTitle = movie.movieTitle,
                ID = movie.ID,
                DateWhenAdded = movie.DateWhenAdded
            };
            Movies.Add(mov);
        }

        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            return Customers;
        }

        public List<Rental> GetRentalsFor(string socialSecurityNumber)
        {
            if (Rentals.Count != 0)
            {
                foreach (var item in Customers)
                {
                    if (item.SSN == socialSecurityNumber)
                    {
                        return Rentals.Where(X => X.Customers.First(z => z.SSN == socialSecurityNumber) ==
                        Customers.Where(y => y.SSN == socialSecurityNumber)).ToList();
                    }
                    return Rentals;
                }
            }
            return Rentals;
        }

        public void RegisterCustomer(string name, string socialSecurityNumber)
        {
            foreach (var item in Customers)
            {
                if (item.Name != name)
                {
                    if (item.SSN != socialSecurityNumber)
                    {
                        var cust = new Customer()
                        {
                            Name = name,
                            SSN = socialSecurityNumber,
                            DateWhenJoin = DateTime.Now,
                            IsRegisterd = true
                        };
                        Customers.Add(cust);
                    }
                    Console.WriteLine("Your social security number is wrong, double check if errors accured");

                }
                Console.WriteLine("The name you are trying to add already exists.");
            }
        }

        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            var ItemToRemove = Rentals.Where(x => x.Movies.Where(z => z.movieTitle == movieTitle)
            == Movies.Where(p => p.movieTitle == movieTitle).ToList());
            var ItemToRemoveBasedOFSSN = Rentals.Where(q => q.Customers.Where(w => w.SSN == socialSecurityNumber)
            == Customers.Where(e => e.SSN == socialSecurityNumber));
            Rentals.Remove(ItemToRemove.First());
            Rentals.Remove(ItemToRemoveBasedOFSSN.First());

        }

        public void RentMovie(string movieTitle, string socialSecurityNumber)
        {
            foreach (var item in Movies)
            {
                foreach (var item2 in Customers)
                {
                    var rent = new Rental();
                    
                }
            }

        }

        public void ReturnMovie(string movieTitle, string socialSecurityNumber)
        {
            var ItemToRemove = Rentals.Where(x => x.Movies.Where(z => z.movieTitle == movieTitle)
            == Movies.Where(p => p.movieTitle == movieTitle).ToList());
            var ItemToRemoveBasedOFSSN = Rentals.Where(q => q.Customers.Where(w => w.SSN == socialSecurityNumber)
            == Customers.Where(e => e.SSN == socialSecurityNumber));
            foreach (var item in ItemToRemove)
            {
                foreach (var item1 in ItemToRemoveBasedOFSSN)
                {
                    item.IsRented = item1.IsRented;
                    item.LateReturns = item1.LateReturns;
                    item.ID = item1.ID;
                    item.Name = item1.Name;
                    item.AmountOfMoviesRented = item1.AmountOfMoviesRented;
                }
                //item.IsRented = false;
                //item.AmountOfMoviesRented--;
                //item.DateWhenRented = DateTime.Now;
            }
            Rentals.Remove(ItemToRemove.First());
            Rentals.Remove(ItemToRemoveBasedOFSSN.First());
        }
    }
}
