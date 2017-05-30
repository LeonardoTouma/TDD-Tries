using System;
using ViedoStore_BI;
using ViedoStore_BI.Logic;

namespace ViedoStore_UI
{

    public class SpeakDirectWithCustomer
    {
        VideoStore vid = new VideoStore();
        public void CollectionOfMoviesAvalible()
        {
            Console.WriteLine("This is our collection of movies: ");
            if (vid.GetMovies().Count != 0)
            {
                foreach (var item in vid.GetMovies())
                {
                    Console.WriteLine($"Title: {item.movieTitle}, When added: {item.DateWhenAdded}");
                }
                vid.GetMovies();
            }
            else
            {
                Console.WriteLine("List is empty");
            }
            Console.ReadKey();

        }

        public void ReturnAMovie()
        {
            Console.WriteLine("What movie would you like to return?");
            Console.WriteLine("Movietitle: ");
            string movietitle = Console.ReadLine();
            Console.WriteLine("Social securityNumber:");
            string SOC = Console.ReadLine();
            vid.RemoveRental(movietitle, SOC);
            Console.WriteLine("Movie removed.");
        }

        public void RentAMovie()
        {
            Console.WriteLine("What movie would you like to rent?");
            Console.WriteLine("Movietitle: ");
            string movietitle = Console.ReadLine();
            Console.WriteLine("Social securityNumber:");
            string SOC = Console.ReadLine();
            vid.RentMovie(movietitle, SOC);
            Console.WriteLine($"You are now renting: {movietitle}, on this soc: {SOC}");
        }

        public void MakeAMovieAvalible()
        {
            Console.WriteLine("What movie would you like to add? ");
            Console.WriteLine("MovieTitle: ");
            string movietitle = Console.ReadLine();
            Console.WriteLine("What is your SOC?");
            string soc = Console.ReadLine();
            vid.AddRental(movietitle, soc);
            Console.WriteLine("Movie added.");
            Console.WriteLine("The movie is now avalible, this is the movies that is now avalible:");
            vid.GetMovies();
        }

        public void Register()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Soc: ");
            string SOC = Console.ReadLine();
            vid.RegisterCustomer(name, SOC);
            Console.WriteLine("You are now registerd, this is the rest of the customers:");
            foreach (var item in vid.GetCustomers())
            {
                Console.WriteLine($"Name: {item.Name}, SSN: {item.SSN}");
            }
        }

    }
}
