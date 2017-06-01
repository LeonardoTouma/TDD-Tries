using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
   
    [TestFixture]
    public class TriesUnitTests
    {
        [SetUp]
        public void SetupMethod()
        {

        }
        [TestCase("1", "2")]
        [TestCase("", "")]
        [TestCase("-1", "-2")]
        public void CheckIfParametersISValid(string num1, string num2)
        {
            if (!num1.Contains("") && !num2.Contains(""))
            {
                string sum = AddNumbers(num1,num2);
                if (sum.Contains(num1))
                {
                    if (sum.Contains(num2))
                    {
                        if (sum.Count() >= 1 && !sum.Contains("-"))
                        {
                            Console.WriteLine($"Great sum contains sum: {sum}");
                        }
                        else
                        {
                            Assert.IsNull(sum);
                            Assert.IsEmpty(sum);
                        }
                        Assert.IsNotNull(sum);
                    }
                  
                }
               
            }
            
        }
        public string AddNumbers(string num1, string num2)
        {
            string sum = num1 + num2;
            return sum;
        }
    }
}
