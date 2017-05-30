using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ViedoStore_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeakDirectWithCustomer vid = new SpeakDirectWithCustomer();
            bool choice1 = true;
            while (choice1)
            {
                Console.WriteLine("Welcome To my videostore");
                Console.WriteLine($"What would you like to do?" +
                    $" 1. ReturnAMovie " +
                    $" 2. RentAMovie" +
                    $" 3.Make A Movie Avalible in the rental list" +
                    $" 4. Register" +
                    $" 5. See all avalible movies");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Thread.Sleep(1);
                        Console.Clear();
                        vid.ReturnAMovie();
                        break;
                    case "2":
                        Thread.Sleep(1);
                        Console.Clear();
                        vid.RentAMovie();
                        break;
                    case "3":
                        Thread.Sleep(1);
                        Console.Clear();
                        vid.MakeAMovieAvalible();
                        break;
                    case "4":
                        Thread.Sleep(1);
                        Console.Clear();
                        vid.Register();
                        break;
                    case "5":
                        Thread.Sleep(1);
                        Console.Clear();
                        vid.CollectionOfMoviesAvalible();
                        break;
                    default:
                        choice1 = false;
                        break;
                }
            }
            
        }
          
    }
}
