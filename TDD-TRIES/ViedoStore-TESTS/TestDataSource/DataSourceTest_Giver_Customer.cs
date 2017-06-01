using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViedoStore_BI;

namespace ViedoStore_TESTS.TestDataSource
{
    class DataSourceTest_Giver_Customer : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new[] { new Customer { SSN = "123" } };
            yield return new[] { new Customer { SSN = "321" } };
            yield return new[] { new Customer { SSN = "423" } };
            yield return new[] { new Customer { SSN = "54312" } };
        }
    }
}
