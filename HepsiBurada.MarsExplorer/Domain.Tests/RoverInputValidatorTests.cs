namespace Domain.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RoverInputValidatorTests
    {
        private RoverInputValidator _roverInputValidator;

        [TestInitialize]
        public void TestInitialize()
        {
            _roverInputValidator = new RoverInputValidator(new RoverBuilder());
        }

        [TestMethod]
        public void BuildRoverWithoutCoordinates()
        {
            ArgumentExceptionTesting("", "LMLMLM" );
        }

        [TestMethod]
        public void BuildRoverWithMissingCoordinates()
        {
            ArgumentExceptionTesting("1 2", "LMLMLM" );
        }

        [TestMethod]
        public void BuildRoverWithNonNumericCoordinates()
        {
            ArgumentExceptionTesting("1 b N", "LMLMLM" );
        }

        [TestMethod]
        public void BuildRoverWithNegativeCoordinates()
        {
            ArgumentExceptionTesting("-1 4 N", "LMLMLM" );
        }

        [TestMethod]
        public void BuildRoverWithInvalidDirection()
        {
            ArgumentExceptionTesting("1 4 A", "LMLMLM");
        }

        
        [TestMethod]
        public void BuildRoverWithoutMovement()
        {
            ArgumentExceptionTesting("1 4 N", "");
        }

        [TestMethod]
        public void BuildRoverWithInvalidMovement()
        {
            ArgumentExceptionTesting("1 4 N", "LLMMRRSS");
        }
        

        private void ArgumentExceptionTesting(string coordinateCommand, string movementCommand)
        {
            try
            {
                _roverInputValidator.Build(coordinateCommand,movementCommand,new Plateu(1,2));
            }
            catch (ArgumentException)
            {
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail("ArgumentException has been expected. But {0} has been thrown.", ex.GetType());
            }

            Assert.Fail("ArgumentException has been expected. But no exception has been thrown.");
        }
    }
}