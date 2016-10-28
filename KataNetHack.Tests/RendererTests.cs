using FluentAssertions;

using KataNetHack.Console;

using Xunit;

namespace KataNetHack.Tests
{
    public class RendererTests
    {
        private const int MAP_ROW_COUNT = 10;
        private const int MAP_COLUMN_COUNT = 10;

        [Fact]
        public void Render_EntireMapPassageway_Writes10Rows()
        {
            var builder = new RendererBuilder();
            var sut = builder.Build();

            sut.Render();

            builder.OutputLines.Should().HaveCount(MAP_ROW_COUNT);
        }

        [Fact]
        public void Render_EntireMapPassageway_AllLines10Spaces()
        {
            var builder = new RendererBuilder();
            var sut = builder.Build();

            sut.Render();

            for(int row = 0;row < MAP_ROW_COUNT;row++)
            {
                builder.AssertRowEmpty(row);
            }
        }

        [Fact]
        public void Render_TopLeftCellWall_RendersCellAsWall()
        {
            var builder = new RendererBuilder();

            var sut = builder.WithWallAt(1, 1)
                             .Build();

            sut.Render();

            builder.OutputLines[0].Should().Be("█" + new string(' ', MAP_COLUMN_COUNT - 1));
            builder.AssertRowEmpty(1);
        }

        [Theory]
        [InlineData(ElementType.Wall, '█')]
        [InlineData(ElementType.Exit, '◌')]
        public void Render_MismatchingXYCoordinates_RendersCellAsExpected(ElementType elementType, char expected)
        {
            var builder = new RendererBuilder();

            var sut = builder.WithCellAt(4, 3, elementType)
                             .Build();

            sut.Render();

            string leftPadding = "   ";
            string rightPadding = "      ";

            builder.AssertRowEmpty(0);
            builder.AssertRowEmpty(1);
            builder.OutputLines[2].Should().Be(leftPadding + expected + rightPadding);
            builder.AssertRowEmpty(3);
        }
    }
}