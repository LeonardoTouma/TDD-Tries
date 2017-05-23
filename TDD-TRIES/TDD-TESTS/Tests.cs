using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_TESTS
{
    [TestFixture]
    public class Tests
    {
            [Test]
            public void CheckInfo()
            {
                var infos = new InfoNeeded();
                string hej = "tjena";
                infos.GetInfo(hej);
                Assert.AreEqual("tjena", hej, "Value of hej:");
            }
     }
}
