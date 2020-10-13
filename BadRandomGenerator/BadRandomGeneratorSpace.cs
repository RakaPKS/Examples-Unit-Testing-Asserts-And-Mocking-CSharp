using System;
using System.Numerics;

namespace BadRandomGeneratorSpace
{
    public class BadRandomGenerator
    {
        public int b;

        public BadRandomGenerator()
        {
            this.b = new Random().Next();
        }

        //Generates a random int
        public virtual int GenerateRandomInt()
        {   
            return new Random().Next();
        }

        // Generates a random int between a, b. If a is upperbound int, then return 0
        public virtual int GenerateRandomIntWithBoundaries(int a)
        {
            if(a == Int32.MaxValue)
            {
                return 0;
            }
            return new Random().Next(a, b);
        }

        //Modifies stored integer b by a
        public virtual void ModifyB(int a)
        {
            this.b = a;
        }
    }
}
