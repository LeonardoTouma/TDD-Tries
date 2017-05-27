using System;
using System.Collections.Generic;

namespace ViedoStore_BI
{
    public class Rental
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsRented { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Movie> Movies { get; set; }

        public int AmountOfMoviesRented { get; set; }
        public int LateReturns { get; set; }
        public DateTime DateWhenRented { get; set; }
        public Rental()
        {
            DateWhenRented =  DateTime.Now;
            ID++;
        }
    }
}