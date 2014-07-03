namespace Domain.Tests
{
    using Domain.Builders;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlateBuilderTests
    {
        [TestMethod]
        public void BuildPlateuWithValidParameters()
        {
            var plateu = new PlateuBuilder().Build("3 3");

            Assert.AreEqual("3 3", plateu.ToString());
        }
    }
}