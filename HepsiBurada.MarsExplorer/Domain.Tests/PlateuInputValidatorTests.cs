namespace Domain.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlateuInputValidatorTests
    {

        private PlateuInputValidator _plateuInputValidator;

        [TestInitialize]
        public void TestInitialize()
        {
            _plateuInputValidator = new PlateuInputValidator(new PlateuBuilder());
        }

        [TestMethod]
        public void BuildPlateuWithNegativeAreaValues()
        {
            ArgumentExceptionTesting("-1 -3");
        }

        [TestMethod]
        public void BuildPlateuWithoutArea()
        {
            ArgumentExceptionTesting("1 1");
        }


        [TestMethod]
        public void BuildPlateuWithEmptyAreaCommand()
        {
            ArgumentExceptionTesting("");
        }

        [TestMethod]
        public void BuildPlateuWithMissingAreaCommand()
        {
            ArgumentExceptionTesting("1");
        }

        [TestMethod]
        public void BuildPlateuWithNonNumericAreaCommand()
        {
            ArgumentExceptionTesting("a 3");
        }

        private void ArgumentExceptionTesting(string command)
        {
            try
            {
                _plateuInputValidator.Build(command);
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