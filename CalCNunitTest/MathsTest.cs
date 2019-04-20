using BusinessLogic;
using BusinessLogic.Service.Interfaces;
using NUnit.Framework;
namespace Tests
{
    public class Tests
    {
        private IMathService mathService;

        [SetUp]
        public void Setup()
        {
        //Initialize DI Container
         Container.Initialize();
         mathService = Container.mathService;
        }

        [Test]
        public void Add_AddingTwuNumbers_ReturnsSum()
        {
            //Arrange
            decimal expected = 4;
            decimal num1 = 2;
            decimal num2 = 2;
            
            //Act
      
            decimal myAnswer = mathService.Add(num1, num2);
            
            //Assert
            Assert.AreEqual(expected,myAnswer);
        }
        [Test]
        public void Subtract_SubtractingTwoNumbers_ReturnsDifference()
        {
            //Arrange
            decimal expected = 2;
            decimal num1 = 4;
            decimal num2 = 2;

            //Act   
            decimal myAnswer = mathService.Subtract(num1, num2);

            //Assert
            Assert.AreEqual(expected, myAnswer);
        }
        [Test]
        public void Divide_DividingTwoNumbers_ReturnsQuotient()
        {
            //Arrange
            decimal expected = 3;
            decimal num1 = 6;
            decimal num2 = 2;

            //Act   
            decimal myAnswer = mathService.Divide(num1, num2);

            //Assert
            Assert.AreEqual(expected, myAnswer);
        }
        [Test]
        public void Multiply_MultiplyingTwoNumbers_ReturnsProduct()
        {
            //Arrange
            decimal expected = 12;
            decimal num1 = 6;
            decimal num2 = 2;

            //Act   
            decimal myAnswer = mathService.Multiply(num1, num2);

            //Assert
            Assert.AreEqual(expected, myAnswer);
        }
    }
}