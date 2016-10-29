using System.Collections.Generic;
using FluentAssertions;
using KataNetHack.Console;
using Xunit;

namespace KataNetHack.Tests
{

    public class MapTests
    {
        private static Map Sut(int width, int height)
        {
            var items = new StageItemBuilder().WithWidth(width).WithHeight(height).Build();

            var sut = Map.Create(items, width, height) as Map;
            return sut;
        }

        [Fact]
        public void Create_OnMapFactory_ReturnsMap()
        {
            var sut = Map.Create(new List<char>(), 0, 0) as Map;
            Assert.IsType<Map>(sut);
        }

        [Fact]
        public void Width_OnMapWith10Width_Returns10()
        {
            var sut = Sut(10, 1);

            Assert.Equal(10, sut.Width);
        }

        [Fact]
        public void Height_OnMapWith10Height_Returns10()
        {
            var sut = Sut(1, 10);

            Assert.Equal(10, sut.Height);
        }

        [Fact]
        public void Coordinate_1And1_IsAWall()
        {
            var items = new StageItemBuilder().Build();
            var sut = Map.Create(items, 10, 10) as Map;

            var corner = sut.ElementAt(1, 1); 

            Assert.Equal(ElementType.Wall, corner.Type);
        }

        [Fact]
        public void CanMoveTo_AWallOnA10X10Map_ShouldReturnFalse_()
        {
            var items = new StageItemBuilder().Build();
            var sut = Map.Create(items, 10, 10);

            var result = sut.CanMoveTo(1, 1);

            result.Should().BeFalse();
        }


        [Fact]
        public void CanMoveTo_OverAValidCoordinateOnA10X10Map_ShouldReturnTrue()
        {
            var sut = Sut(10, 10);

            var result = sut.CanMoveTo(2, 2);

            result.Should().BeTrue();
        }


        [Fact]
        public void CanMoveTo_OverAnotherValidCoordinateOnA10X10Map_ShouldReturnTrue()
        {
            var sut = Sut(10, 10);

            var result = sut.CanMoveTo(4, 5);

            result.Should().BeTrue();
        }


        [Fact]
        public void CanMoveTo_OverYetAnotherValidCoordinateOnA10X10Map_ShouldReturnTrue()
        {
            var sut = Sut(10, 10);

            var result = sut.CanMoveTo(9, 7);

            result.Should().BeTrue();
        }


        [Fact]
        public void CanMoveTo_OverExitOnA10X10Map_ShouldReturnTrue()
        {
            var sut = Sut(10, 10);

            var result = sut.CanMoveTo(9, 9);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsExit_OnAWall_IsFalse()
        {
            var sut = Sut(10, 10);

            var result = sut.IsExit(1, 1);

            result.Should().BeFalse();
        }

        [Fact]
        public void IsExit_OnAPassageWay_IsFalse()
        {
            var sut = Sut(10, 10);

            var result = sut.IsExit(1, 1);

            result.Should().BeFalse();
        }


        [Fact]
        public void IsExit_OnAnExit_IsTrue()
        {
            var sut = Sut(10, 10);

            var result = sut.IsExit(9, 9);

            result.Should().BeTrue();
        }


        [Fact]
        public void GetElementType_OnAWall_ReturnsWall()
        {
            var sut = Sut(10, 10);

            var result = sut.GetElementType(1, 1);

            result.Should().Be(ElementType.Wall);
        }


        [Fact]
        public void GetElementType_OnAPassageWay_ReturnsPassageWay()
        {
            var sut = Sut(10, 10);
            var result = sut.GetElementType(5, 5);

            result.Should().Be(ElementType.PassageWay);
        }

        [Fact]
        public void GetElementType_WhenSetToX2Y2_LocationIsX2Y2()
        {
            var sut = Sut(10, 10);
            var result = sut.GetElementType(2, 2);
            var pic = sut.ToString();
            result.Should().Be(ElementType.SpawnPoint);
        }

        [Fact]
        public void SpawnLocation_WhenSetToX2Y2_LocationIsX2Y2()
        {
            var sut = Sut(10, 10);
            var result = sut.SpawnLocation();
            var pic = sut.ToString();
            Assert.Equal(2, result.X);
            Assert.Equal(2, result.Y);
        }
    }
}
