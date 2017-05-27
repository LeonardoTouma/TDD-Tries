using System;
using System.Collections.Generic;

namespace ViedoStore_BI
{
    public class Movie
    {
        public int ID { get; set; }
        public string movieTitle { get; set; }
        public DateTime DateWhenAdded { get; set; }
        public bool IsRented { get; set; }
        public Movie()
        {
            DateWhenAdded = DateTime.Now;
            ID++;
        }
    }
}