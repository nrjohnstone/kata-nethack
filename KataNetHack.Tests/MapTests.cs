using System.Linq;
using FluentAssertions;
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
        public void Height_OnMapWith10Height_Returns10()
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

        [Fact]
        public void CanMoveTo_AWallOnA10X10Map_ShouldReturnFalse_()
        {
            var sut = Map.Create(10, 10);

            var result = sut.CanMoveTo(0, 0);

            result.Should().BeFalse();
        }


        [Fact]
        public void CanMoveTo_OverAValidCoordinateOnA10X10Map_ShouldReturnTrue()
        {
            var sut = Map.Create(10, 10);

            var result = sut.CanMoveTo(1, 1);

            result.Should().BeTrue();
        }


        [Fact]
        public void CanMoveTo_OverAnotherValidCoordinateOnA10X10Map_ShouldReturnTrue()
        {
            var sut = Map.Create(10, 10);

            var result = sut.CanMoveTo(4, 5);

            result.Should().BeTrue();
        }


        [Fact]
        public void CanMoveTo_OverYetAnotherValidCoordinateOnA10X10Map_ShouldReturnTrue()
        {
            var sut = Map.Create(10, 10);

            var result = sut.CanMoveTo(9, 7);

            result.Should().BeTrue();
        }


        [Fact]
        public void CanMoveTo_OverExitOnA10X10Map_ShouldReturnTrue()
        {
            var sut = Map.Create(10, 10);

            var result = sut.CanMoveTo(10, 10);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsExit_OnAWall_IsFalse()
        {
            var sut = Map.Create(10, 10);

            var result = sut.IsExit(0, 0);

            result.Should().BeFalse();
        }

        [Fact]
        public void IsExit_OnAPassageWay_IsFalse()
        {
            var sut = Map.Create(10, 10);

            var result = sut.IsExit(1, 1);

            result.Should().BeFalse();
        }


        [Fact]
        public void IsExit_OnAnExit_IsTrue()
        {
            var sut = Map.Create(10, 10);

            var result = sut.IsExit(10, 10);

            result.Should().BeTrue();
        }


        [Fact]
        public void GetElementType_OnAWall_ReturnsWall()
        {
            var sut = Map.Create(10, 10);

            var result = sut.GetElementType(0, 0);

            result.Should().Be(ElementType.Wall);
        }


        [Fact]
        public void GetElementType_OnAPassageWay_ReturnsPassageWay()
        {
            var sut = Map.Create(10, 10);

            var result = sut.GetElementType(5, 5);

            result.Should().Be(ElementType.PassageWay);
        }
    }
}
