using System.Linq;
using KataNetHack.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataNetHack.Tests
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void Create_OnMapFactory_ReturnsMap()
        {
            var sut = Map.Create(0, 0);
            Assert.IsInstanceOfType(sut, typeof(Map));
        }

        [TestMethod]
        public void Elements_OnMap_Returns100Elements()
        {
            var sut = Map.Create(10, 10);
            var elements = sut.Elements;
            Assert.AreEqual(100, elements.Count());
        }

        [TestMethod]
        public void Width_OnMapWith10Width_Returns10()
        {
            var sut = Map.Create(10, 0);
            Assert.AreEqual(10, sut.Width);
        }

        [TestMethod]
        public void Height_OnMapWith10Width_Returns10()
        {
            var sut = Map.Create(0, 10);
            Assert.AreEqual(10, sut.Height);
        }

    }
}
