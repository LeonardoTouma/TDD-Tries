using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationTests
    {
        Validator sut = new Validator();
        [TestCase(true)]
        //[TestCase(false)]
        public void TrueForValidAddress(bool ValidAdress)
        {
            sut.ValidateEmailAddress(ValidAdress);
            Assert.IsTrue(ValidAdress);
        }
        //[TestCase(true)]
        [TestCase(false)]
        public void FalseForValidAddress(bool ValidAdress)
        {
            sut.ValidateEmailAddress(ValidAdress);
            Assert.IsFalse(ValidAdress);
        }
        [Test]
       public void ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
            new TestDelegate(sut.MethodThatThrows));
        }
        
    }
}
