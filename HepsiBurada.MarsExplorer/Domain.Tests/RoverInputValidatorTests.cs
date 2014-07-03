namespace Domain.Tests
{
    using System;

    using Autofac;

    using Domain.Builders;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RoverInputValidatorTests : BaseTest
    {
        private IRoverBuilder _roverInputValidator;

        [TestMethod]
        public void BuildRoverWithInvalidDirection()
        {
            ArgumentExceptionTesting("1 4 A", "LMLMLM");
        }

        [TestMethod]
        public void BuildRoverWithInvalidMovement()
        {
            ArgumentExceptionTesting("1 4 N", "LLMMRRSS");
        }

        [TestMethod]
        public void BuildRoverWithMissingCoordinates()
        {
            ArgumentExceptionTesting("1 2", "LMLMLM");
        }

        [TestMethod]
        public void BuildRoverWithNegativeCoordinates()
        {
            ArgumentExceptionTesting("-1 4 N", "LMLMLM");
        }

        [TestMethod]
        public void BuildRoverWithNonNumericCoordinates()
        {
            ArgumentExceptionTesting("1 b N", "LMLMLM");
        }

        [TestMethod]
        public void BuildRoverWithOutsideOfPlateu()
        {
            ArgumentExceptionTesting("5 5 N", "MMMM", new Plateu(4, 4));
        }

        [TestMethod]
        public void BuildRoverWithoutCoordinates()
        {
            ArgumentExceptionTesting("", "LMLMLM");
        }

        [TestMethod]
        public void BuildRoverWithoutMovement()
        {
            ArgumentExceptionTesting("1 4 N", "");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _roverInputValidator = Container.Resolve<IRoverBuilder>();
        }

        private void ArgumentExceptionTesting(string coordinateCommand, string movementCommand, Plateu plateu = null)
        {
            if (plateu == null)
            {
                plateu = new Plateu(2, 2);
            }

            try
            {
                _roverInputValidator.Build(coordinateCommand, movementCommand, plateu);
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