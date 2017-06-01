using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViedoStore_BI;
using ViedoStore_BI.Logic;

namespace ViedoStore_TESTS.TestDataSource
{
    class DataSourceTest_Giver_Rental : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new[] { new Rental
            { Customers =
            new List<Customer>() {
                new Customer() { SSN = "123" } },Movies = new List<Movie>() {
                    new Movie() { movieTitle = "Carlson" } } } };
            yield return new[]
            { new Rental { Customers = new List<Customer>() {
                new Customer() { SSN = "321" } }, Movies =
                new List<Movie>() { new Movie() { movieTitle = "sad" } } } };
            yield return new[] {
                new Rental { Customers = new List<Customer>() {
                    new Customer() { SSN = "4353" } }, Movies =
                    new List<Movie>() { new Movie() { movieTitle = "vasd" } } } };
            yield return new[] {
                new Rental { Customers = new List<Customer>() {
                    new Customer() { SSN = "5421352" } }, Movies =
                    new List<Movie>() { new Movie() { movieTitle = "vaxxas" } } } };
        }

    }

}
