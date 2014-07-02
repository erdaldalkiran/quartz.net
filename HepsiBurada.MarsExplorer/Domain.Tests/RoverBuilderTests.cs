namespace Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RoverBuilderTests
    {
        
        [TestMethod]
        public void BuildRoverWithValidParameters()
        {
            var roverBuilder = new RoverBuilder();
            var rover = roverBuilder.Build("1 1 N", "MM", new Plateu(10, 10));

            Assert.AreEqual("1 1 N", rover.Location());
        }
        
    }
}