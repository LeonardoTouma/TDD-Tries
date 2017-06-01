using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 2 numbers");
            Console.WriteLine("Num1: ");
            string num1 = Console.ReadLine();
            Console.WriteLine("Num2: ");
            string num2 = Console.ReadLine();
            TriesUnitTests ts = new TriesUnitTests();
            string sum = ts.AddNumbers(num1,num2);
            Console.WriteLine("The sum is: " + sum);
            Console.ReadKey();


        }
    }
}
