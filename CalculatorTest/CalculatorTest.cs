using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculators;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Contracts;
using System;
using Moq;
using System.Security.Cryptography;
using BadRandomGeneratorSpace;

namespace CalculatorTest
{
    // This test class is going to show some examples of some tests with and without mocking
    [TestClass]
    public class CalculatorTest
    {
        // Good practice would be to define a private object _sut here 
        // (meaning structure under testing), but because calculator is a static
        // we can forgo this. See the tests for BadRandomGenerator for an example.

        //This is the most basic call with just one assertion
        [TestMethod]
        public void Add_ValidInput_ShouldPass()
        {
            //Arrange
            int a = 2;
            int b = 3;
            int expected = 5;
            //Act 
            //Explicitly state var here because add might not return an int for some unexpected reason
            //Thus we want to make sure it gets caught at the assert.
            var actual = Calculator.add(a, b);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        //This is the same idea but with multiple input/output values
        [DataRow(5, 4, 9)]
        [DataRow(10,25,35)]
        [DataRow(50,25,75)]
        [DataTestMethod]
        public void Add_ValidNubersMultipleInput_ShouldPass(int a, int b, int expected)
        {
            //Arrange

            //Act
            var actual = Calculator.add(a, b);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        //Division Happy flow
        [DataRow(20, 4, 5)]
        [DataRow(100, 25, 4)]
        [DataRow(3, 3,1)]
        [DataTestMethod]
        public void Div_VaidInput_ShouldPass(int a, int b, int expected)
        {
            //Arrange

            //Act
            var actual = Calculator.div(a, b);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //Example of testing exception throws. In this case we will divide by zero and assert the exception
        [TestMethod]
        public void Div_InvalidInput_ShouldThrowException()
        {
            //Arrange
            int a = 10;
            int b = 0;

            //Act

            //Assert
            Assert.ThrowsException<DivideByZeroException>(() => Calculator.div(a, b), "Cannot divide by zero");
        }

        //Example of mocking an object with one mocked funtion. Keep in mind that the method has to be overridable to be able to be mocked.
        [TestMethod]
        public void addRandomNumber_ValidInput_ShouldPass()
        {
            //Arrange
            int a = 10;
            int b = 5;
            int expected = 15;
            // 1) Create Mock of BadRandomGenerator
            // 2) .Setup(x=>x.DesiredMethodToMock()) here we define which method we want to mock
            // 3) .Returns(y). when this method is called it will always return y.
            var mock = new Mock<BadRandomGenerator>();
            mock.Setup(x => x.GenerateRandomInt()).Returns(b);

            //Act
            var actual = Calculator.addRandomNumber(a, mock.Object);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //The next example will be mocking an object with a method that has an argument
        [TestMethod]
        public void addRandomNumberWithBoundries_ValidInput_ShouldPass()
        {
            //Arrange
            int a = 10;
            int b = 5;
            int expected = 15;
            var mock = new Mock<BadRandomGenerator>();
            //It.IsAny<int>() denotes that any input is valid as long as it is an integer
            mock.Setup(x => x.GenerateRandomIntWithBoundaries(It.IsAny<int>())).Returns(b);

            //Act
            var actual = Calculator.addRandomNumberWithBoundries(a, b, mock.Object);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //Finally we have a void function that modifies a value of the mocked object which we have to verify
        [TestMethod]
        public void addAndModifyRandom_ValidInput_ShouldPass()
        {
            //Arrange
            int a = 10;
            int b = 5;
            int expected = 15;
            var mock = new Mock<BadRandomGenerator>();
            //adds verifier if when ModifyB() is called that the argument matches expected
            mock.Setup(x => x.ModifyB(expected)).Verifiable();

            //Act
            Calculator.addAndModifyRandom(a, b, mock.Object);

            //Assert
            mock.Verify();
        }




        }
}
