namespace Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EngineTests
    {
        private Engine _engine;

        [TestInitialize]
        public void TestInitialize()
        {
            _engine = new Engine(new PlateuInputValidator(new PlateuBuilder()), new RoverInputValidator(new RoverBuilder()));
        }

        [TestMethod]
        public void InitializeEngineWithValidValues()
        {
            _engine.Initialize(new List<string> { "3 5", "1 2 N", "LM" });

            return;
        }

        [TestMethod]
        public void InitializeEngineWithoutCommands()
        {
            ArgumentExceptionTesting(new List<string>());
        }

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
        public void MoveOneRoverForward()
        {
            _engine.Initialize(new List<string> { "10 10", "1 1 N", "M" });
            var result = _engine.Play();

            var expected = new List<string> { "2 1 N" };

            Assert.IsTrue(expected.SequenceEqual(result));
        }


        private void ArgumentExceptionTesting(List<string> commands)
        {
            ExceptionTesting(commands, typeof(ArgumentException));
        }

        private void ExceptionTesting(List<string> commands, Type type)
        {
            try
            {
                _engine.Initialize(commands);
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