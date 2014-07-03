namespace Domain.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Autofac;

    using Domain.Builders;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EngineTests : BaseTest
    {
        private IEngineBuilder _engineBuilder;

        [TestMethod]
        public void MoveOneRoverForward()
        {
            var engine = _engineBuilder.Build(new List<string> { "10 10", "1 1 N", "M" });
            var result = engine.Play();

            var expected = new List<string> { "1 2 N" };

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void MoveRoversToLawa()
        {
            var engine = _engineBuilder.Build(new List<string> { "2 2", "2 2 N", "MMMMM", "0 0 S", "MMMMMMMM" });
            var result = engine.Play();

            var expected = new List<string> { Rover.SignalLost, Rover.SignalLost };

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void PlayTwoRoversWithValidInputs()
        {
            var engine = _engineBuilder.Build(new List<string> { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" });
            var result = engine.Play();

            var expected = new List<string> { "1 3 N", "5 1 E" };

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void RoverCannotTurnInTime()
        {
            var engine =
                _engineBuilder.Build(
                    new List<string> { "3 7", "0 0 N", "MMMMMMMRMMMRMMMMMMMRMMMM", "0 0 E", "MMMLMMMMMMMLMMMLMMMMMMML" });
            var result = engine.Play();

            var expected = new List<string> { Rover.SignalLost, "0 0 E" };

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void RoversMoveDiagonally()
        {
            var engine =
                _engineBuilder.Build(new List<string> { "3 3", "0 0 N", "MRMLMRMLMRML", "0 0 E", "MLMRMLMRMLMR" });
            var result = engine.Play();

            var expected = new List<string> { "3 3 N", "3 3 E" };

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void RoversTravelsOnEdges()
        {
            var engine =
                _engineBuilder.Build(
                    new List<string> { "3 7", "0 0 N", "MMMMMMMRMMMRMMMMMMMRMMMR", "0 0 E", "MMMLMMMMMMMLMMMLMMMMMMML" });
            var result = engine.Play();

            var expected = new List<string> { "0 0 N", "0 0 E" };

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TenRoversMoveOneStepForward()
        {
            var engine =
                _engineBuilder.Build(
                    new List<string>
                    {
                        "10 10",
                        "0 0 N",
                        "MLRLR",
                        "1 1 N",
                        "MLRLR",
                        "2 2 N",
                        "MLRLR",
                        "3 3 N",
                        "MLRLR",
                        "4 4 N",
                        "MLRLR",
                        "5 5 N",
                        "MLRLR",
                        "6 6 N",
                        "MLRLR",
                        "7 7 N",
                        "MLRLR",
                        "8 8 N",
                        "MLRLR",
                        "9 9 N",
                        "MLRLR"
                    });
            var result = engine.Play();

            var expected = new List<string>
                           {
                               "0 1 N",
                               "1 2 N",
                               "2 3 N",
                               "3 4 N",
                               "4 5 N",
                               "5 6 N",
                               "6 7 N",
                               "7 8 N",
                               "8 9 N",
                               "9 10 N"
                           };

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _engineBuilder = Container.Resolve<IEngineBuilder>();
        }

        [TestMethod]
        public void TurnOneRoverFromwestNoNorth()
        {
            var engine = _engineBuilder.Build(new List<string> { "10 10", "1 1 W", "R" });
            var result = engine.Play();

            var expected = new List<string> { "1 1 N" };

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TurnOneRoverLeft()
        {
            var engine = _engineBuilder.Build(new List<string> { "10 10", "1 1 N", "L" });
            var result = engine.Play();

            var expected = new List<string> { "1 1 W" };

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TurnOneRoverRight()
        {
            var engine = _engineBuilder.Build(new List<string> { "10 10", "1 1 N", "R" });
            var result = engine.Play();

            var expected = new List<string> { "1 1 E" };

            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}