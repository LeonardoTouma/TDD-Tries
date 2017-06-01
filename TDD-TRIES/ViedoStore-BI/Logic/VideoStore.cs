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
                IsRented = movie.IsRented,
                movieTitle = movie.movieTitle,
                ID = movie.ID,
                DateWhenAdded = movie.DateWhenAdded
            };
            Movies.Add(mov);
        }

        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
            Rental rent = new Rental()
            {
                IsRented = true,
                Movies = Movies.Where(X => X.movieTitle == movieTitle).ToList(),
                Customers = Customers.Where(X => X.SSN == socialSecurityNumber).ToList()
            };
            Rentals.Add(rent);
        }

        public List<Customer> GetCustomers_Thrue_List()
        {
            return Customers.ToList();
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
            Customers.Add(cust);
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
            if (Movies.Count() > 0 && Rentals.Count() > 0 && Customers.Count() > 0)
            {
                foreach (var item in Rentals.ToList())
                {
                    foreach (var item1 in item.Movies.ToList())
                    {
                        foreach (var item2 in item.Customers.ToList())
                        {
                            if (item1.movieTitle != movieTitle)
                            {
                                if (item2.SSN != socialSecurityNumber)
                                {
                                    var rent = new Rental()
                                    {
                                        Customers = Customers.Where(x => x.SSN == socialSecurityNumber).ToList(),
                                        Movies = Movies.Where(x => x.movieTitle == movieTitle).ToList(),
                                        DateWhenRented = DateTime.Now,
                                        IsRented = true,
                                    };
                                    Rentals.Add(rent);
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException();
                            }
                        }
                    }
                }
            }

        }
        public void ReturnMovie(string movieTitle, string socialSecurityNumber)
        {

            foreach (var item in Rentals)
            {
                foreach (var item1 in item.Movies)
                {
                    foreach (var item2 in item.Customers)
                    {
                        if (item1.movieTitle == movieTitle)
                        {
                            if (item2.SSN == socialSecurityNumber)
                            {
                                var ItemToReMove = Rentals.Where
                                (X => X.Movies.FirstOrDefault(p => p.movieTitle == item1.movieTitle)
                                == Movies.FirstOrDefault(c => c.movieTitle == movieTitle));
                                var ItemToRentBasedOFSSN = Rentals.Where
                                (q => q.Customers.FirstOrDefault(w => w.SSN == socialSecurityNumber)
                                == Customers.Where(e => e.SSN == item2.SSN))
                                .FirstOrDefault();
                                Rentals.Remove(ItemToReMove.FirstOrDefault());
                                Rentals.Remove(ItemToRentBasedOFSSN);
                            }
                        }
                    }
                }
            }

        }
    }
}
