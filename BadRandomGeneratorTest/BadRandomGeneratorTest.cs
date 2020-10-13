using BadRandomGeneratorSpace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BadRandomGeneratorTest
{
    //This class contains some additional examples regarding asserts
    [TestClass]
    public class BadRandomGeneratorTest
    {
        //Initialize object
        private readonly BadRandomGenerator _sut;

        public BadRandomGeneratorTest()
        {
            _sut = new BadRandomGenerator();
        }

        //We can only really check if it returns anything at all and if it is an int. Not a super useful test
        [TestMethod]
        public void GenerateRandomInt_ShouldReturnInteger()
        {
            //Arrange 
            //Act
            var actual = _sut.GenerateRandomInt();
            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(int));

        }

        [TestMethod]
        public void GenerateRandomIntWithBoundaries_ValidInput_ShouldPass()
        {
            //Arrange
            int b = _sut.b;
            int a = _sut.b - 2;
            //Act
            var actual = _sut.GenerateRandomIntWithBoundaries(a);

            //Assert
            Assert.IsTrue(actual >= a && actual <= b);
        }

        [TestMethod]
        public void GenerateRandomIntWithBoundaries_MaxBoundInput_ShouldBeZero()
        {
            //Arrange
            int a = Int32.MaxValue;
            int expected = 0;
            //Act 
            var actual = _sut.GenerateRandomIntWithBoundaries(a);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }

}
