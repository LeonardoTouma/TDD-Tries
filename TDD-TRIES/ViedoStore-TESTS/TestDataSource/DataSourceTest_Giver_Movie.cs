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
    class DataSourceTest_Giver_Movie:IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            //yield return new[] { new Movie { ID = 1, DateWhenAdded = DateTime.Now, movieTitle = "Tila", IsRented = true } };
            //yield return new[] { new Movie { ID = 2, DateWhenAdded = DateTime.Now, movieTitle = "Vila", IsRented = false } };
            //yield return new[] { new Movie { ID = 3, DateWhenAdded = DateTime.UtcNow, movieTitle = "Sila", IsRented = false } };
            //yield return new[] { new Movie { ID = 4,  DateWhenAdded = DateTime.Today, movieTitle = "Dasa", IsRented = false } };
            yield return new[] { new Movie {movieTitle = "Tila" } };
            yield return new[] { new Movie {movieTitle = "Vila" } };
            yield return new[] { new Movie {movieTitle = "Sila"} };
            yield return new[] { new Movie {movieTitle = "Dasa"} };
            
        }
    }
}
