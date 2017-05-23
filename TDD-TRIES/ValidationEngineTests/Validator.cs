using System;

namespace ValidationEngineTests
{
    public class Validator
    {
        public Validator()
        {
        }

        public void ValidateEmailAddress(bool ValidAdress)
        {
            if (ValidAdress != false)
            {
                ValidAdress = true;
            }
            ValidAdress = false;
        }
       public void MethodThatThrows()
        {
            throw new ArgumentException();
        }
    }
}