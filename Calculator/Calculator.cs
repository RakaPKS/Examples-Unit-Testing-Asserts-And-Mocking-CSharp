using System;
using System.Security.Cryptography.X509Certificates;
using BadRandomGeneratorSpace;

namespace Calculators
{
    public static class Calculator
    {
        public static int add(int a,  int b)
        {
            return a + b;
        }
        public static int div(int a, int b)
        {
            if (b == 0)
                throw new System.DivideByZeroException("Cannot divide by zero");
            else
                return a / b;
        }
        public static int addRandomNumber(int a, BadRandomGenerator random)
        {
            return a + random.GenerateRandomInt();
        }

        public static int addRandomNumberWithBoundries(int a, int b, BadRandomGenerator random)
        {
            return a + random.GenerateRandomIntWithBoundaries(b);
        }

        public static void addAndModifyRandom(int a, int b, BadRandomGenerator random)
        {
            random.ModifyB(a+b);
        }

    }
}
