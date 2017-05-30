using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViedoStore_BI.Logic
{
    public class VideoStore : IVideoStore
    {
        List<Movie> Movies = new List<Movie>()
        {
            new Movie{
                 movieTitle = "Titanic", IsRented = true
            },
            new Movie{
                 movieTitle = "Peter pan", IsRented = true
            },
            new Movie{
                 movieTitle = "Columbus", IsRented = true
            }

        };
        List<Customer> Customers = new List<Customer>()
        {
            new Customer{
                 Name = "peter", SSN="123", IsRegisterd = true
            },
            new Customer{
                 Name = "Dan", SSN="456", IsRegisterd = true
            },
            new Customer{
                 Name = "Carl", SSN="789", IsRegisterd = true
            }
        };
        List<Rental> Rentals = new List<Rental>()
        {
            new Rental{
                 Name = "Rental1", IsRented = true,
            },new Rental{
                 Name = "Rental2", IsRented = true,
            },
            new Rental{
                 Name = "Rental3", IsRented = true,
            }
        };
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
            var cust = new Customer()
            {
                Name = name,
                SSN = socialSecurityNumber,
                DateWhenJoin = DateTime.Now,
                IsRegisterd = true
            };
            //var checkifvaluesarethesame = Rentals.FirstOrDefault(X => X.Movies.Where(z => z.movieTitle != name) == Movies.Where(c => c.movieTitle != name));
            var checkifssnsarethesame = Rentals.FirstOrDefault(X => X.Customers.Where(z => z.SSN != socialSecurityNumber) == Customers.Where(c => c.SSN != socialSecurityNumber));

            //if (checkifssnsarethesame.Customers.FirstOrDefault(X => X.Name == name) == Customers.FirstOrDefault(c => c.Name == name))
            //{
                //if (checkifssnsarethesame.Customers.FirstOrDefault(X => X.SSN == socialSecurityNumber) == Customers.Where(c => c.SSN != socialSecurityNumber))
                //{
                        Customers.Add(cust);
                //}
                //else
                //{
                //    Console.WriteLine("Your social security number might be wrong, double check if errors accured");
                //}
            //}
            //else
            //{
            //    Console.WriteLine("The name you are trying to add already exists.");
            //}
        }

        public List<Movie> GetMovies()
        {
            return Movies;
        }

        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            if (Rentals.Count() == 0 && Movies.Count() == 0 && Customers.Count == 0)
            {
                var ItemToRemove = Rentals.Where(x => x.Movies.Where(z => z.movieTitle == movieTitle).First()
                == Movies.Where(p => p.movieTitle == movieTitle).First());
                var ItemToRemoveBasedOFSSN = Rentals.Where(q => q.Customers.Where(w => w.SSN == socialSecurityNumber)
                == Customers.Where(e => e.SSN == socialSecurityNumber)).First();
                Rentals.Remove(ItemToRemove.First());
                Rentals.Remove(ItemToRemoveBasedOFSSN);
            }
        }

        public void RentMovie(string movieTitle, string socialSecurityNumber)
        {

            var MovieToAdd = Rentals.Where(X => X.Movies.Where(C => C.movieTitle != movieTitle).FirstOrDefault() ==
            Movies.Where(v => v.movieTitle != movieTitle).FirstOrDefault());

            var MovieToAddBasedOfSSN = Rentals.Where(X => X.Customers.Where(c => c.SSN == socialSecurityNumber) == Customers.Where(v => v.SSN == socialSecurityNumber).FirstOrDefault());
            Rentals.Add(MovieToAddBasedOfSSN.FirstOrDefault());
            Rentals.Add(MovieToAdd.FirstOrDefault());
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
            }
            Rentals.Remove(ItemToRemove.First());
            Rentals.Remove(ItemToRemoveBasedOFSSN.First());
        }
    }
}
