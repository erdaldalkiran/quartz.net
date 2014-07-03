namespace Domain.Tests
{
    using System;
    using System.Collections.Generic;

    using Autofac;

    using Domain.Builders;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EngineInputValidatorTests : BaseTest
    {
        private IEngineBuilder _engineInputValidator;

        [TestMethod]
        public void InitializeEngineWithMissingRoverCommands()
        {
            ArgumentExceptionTesting(new List<string> { "10 1", "1 2 N" });
        }

        public void InitializeEngineWithNullArgument()
        {
            ExceptionTesting(null, typeof(ArgumentNullException));
        }

        [TestMethod]
        public void InitializeEngineWithValidValues()
        {
            _engineInputValidator.Build(new List<string> { "3 5", "1 2 N", "LM" });
        }

        [TestMethod]
        public void InitializeEngineWithoutCommands()
        {
            ArgumentExceptionTesting(new List<string>());
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _engineInputValidator = Container.Resolve<IEngineBuilder>();
        }


        private void ArgumentExceptionTesting(List<string> commands)
        {
            ExceptionTesting(commands, typeof(ArgumentException));
        }

        private void ExceptionTesting(List<string> commands, Type type)
        {
            try
            {
                _engineInputValidator.Build(commands);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(type, ex.GetType());
                return;
            }

            Assert.Fail("ArgumentException has been expected. But no exception has been thrown.");
        }
    }
}