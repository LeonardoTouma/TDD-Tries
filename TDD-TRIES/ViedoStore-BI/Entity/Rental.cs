using System;
using System.Collections.Generic;

namespace ViedoStore_BI
{
    public class Rental
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsRented { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>()
        {
             new Customer{  Name = "Dans", SSN="123"},
             new Customer { Name = "Peters", SSN = "456"  },
             new Customer{ Name = "Carls", SSN="789" }
        };

        public List<Movie> Movies { get; set; } = new List<Movie>()
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

        public int AmountOfMoviesRented { get; set; }
        public int LateReturns { get; set; }
        public DateTime DateWhenRented { get; set; }
        public Rental()
        {
            DateWhenRented =  DateTime.Now;
            ID++;
            IsRented = true;
        }
    }
}