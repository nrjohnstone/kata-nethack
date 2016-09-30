using System.Linq;
using KataNetHack.Console;
using Xunit;

namespace KataNetHack.Tests
{

    public class MapTests
    {
        [Fact]
        public void Create_OnMapFactory_ReturnsMap()
        {
            var sut = Map.Create(0, 0);
            Assert.IsType<Map>(sut);
        }

        [Fact]
        public void Elements_OnMap_Returns100Elements()
        {
            var sut = Map.Create(10, 10);
            var elements = sut.Elements;
            Assert.Equal(100, elements.Count());
        }

        [Fact]
        public void Width_OnMapWith10Width_Returns10()
        {
            var sut = Map.Create(10, 0);
            Assert.Equal(10, sut.Width);
        }

        [Fact]
        public void Height_OnMapWith10Width_Returns10()
        {
            var sut = Map.Create(0, 10);
            Assert.Equal(10, sut.Height);
        }

        [Fact]
        public void Coordinate_0And0_IsAWall()
        {
            var sut = Map.Create(10, 10);
            var corner = sut.ElementAt(0, 0); 
            Assert.Equal(corner.Type, ElementType.Wall);
        }

    }
}
