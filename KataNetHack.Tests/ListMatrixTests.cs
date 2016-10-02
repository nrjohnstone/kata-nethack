using System;
using System.Collections.Generic;
using KataNetHack.Console;
using KataNetHack.Console.Maps;
using Xunit;

namespace KataNetHack.Tests
{
    public class ListMatrixTests
    {
        private static ListMatrix ListMatrix10x10()
        {
            var items = new StageItemBuilder().Build();
            var sut = new ListMatrix(items);
            return sut;
        }

        [Fact]
        public void Ctor_Null_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentNullException>(() => new ListMatrix(null));
        }
        
        [Fact]
        public void Ctor_EmtpyListAndCapacityDoesntMatch_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ListMatrix(new List<char>(), 10, 10));
        }
        
        [Fact]
        public void ElementAt_EmtpyList_ThrowsArgumentOutOfRangeException()
        {
            var sut = new ListMatrix(new List<char>(), 0, 0);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.ElementAt(1, 1));
        }

        [Fact]
        public void Position_1And1OnA10x10Matrix_Is0()
        {
            var sut = ListMatrix10x10();
            Assert.Equal(0, sut.Position(1, 1));
        }

        [Fact]
        public void Position_2And2OnA10x10Matrix_Is11()
        {
            var sut = ListMatrix10x10();
            Assert.Equal(11, sut.Position(2, 2));
        }

        [Fact]
        public void Position_9And9OnA10x10Matrix_Is11()
        {
            var sut = ListMatrix10x10();
            Assert.Equal(99, sut.Position(10, 10));
        }
        
        [Fact]
        public void Position_3And2OnA3x2Matrix_Is6()
        {
            var items = new StageItemBuilder().WithWidth(3).WithHeight(2).Build();
            var sut = new ListMatrix(items, 3, 2);
            Assert.Equal(5, sut.Position(3, 2));
        }

        [Fact]
        public void Position_20And5OnA20x5Matrix_Is99()
        {
            var items = new StageItemBuilder().WithWidth(20).WithHeight(5).Build();
            var sut = new ListMatrix(items, 20, 5);
            Assert.Equal(99, sut.Position(20, 5));
        }

        [Fact]
        public void ElementAt_FirstElementOnAMapWithTopWall_IsAWall()
        {
            var sut = ListMatrix10x10();
            Assert.Equal(ElementType.Wall, sut.ElementAt(1, 1).Type);
        }

        [Fact]
        public void ElementAt_FirstElementOnAMapWithBottomWall_IsAWall()
        {
            var sut = ListMatrix10x10();
            Assert.Equal(ElementType.Wall, sut.ElementAt(10, 10).Type);
        }

        [Fact]
        public void ElementAt_BottomCornerWhenBottomCornerIsExit_IsAnExit()
        {
            var sut = ListMatrix10x10();
            Assert.Equal(ElementType.Exit, sut.ElementAt(9, 9).Type);
        }

        [Fact]
        public void ElementAt_TopRightCorner_IsAnPassageWay()
        {
            var sut = ListMatrix10x10();
            Assert.Equal(ElementType.Exit, sut.ElementAt(9, 9).Type);
        }

        [Fact]
        public void ToString_IsAwesome()
        {
            var sut = ListMatrix10x10();
            var result = sut.ToString();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void ToString_IsStillAwesome()
        {
            var items = new StageItemBuilder().WithWidth(20).WithHeight(5).Build();
            var sut = new ListMatrix(items, 20, 5);
            var result = sut.ToString();
            Assert.NotEmpty(result);
        }

    }
}
