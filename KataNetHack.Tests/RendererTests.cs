using System.Collections.Generic;

using FluentAssertions;

using KataNetHack.Console;

using Xunit;

namespace KataNetHack.Tests
{
    public class RendererTests
    {
        private const int MAP_ROW_COUNT = 10;
        private const int MAP_COLUMN_COUNT = 10;
        private const char WALL_CELL = '█';
        private const char EXIT_CELL = '*';

        private IEnumerable<Renderable> NoRenderables() => new Renderable[0];

        [Fact]
        public void Render_EntireMapPassageway_Writes10Rows()
        {
            var builder = new RendererBuilder();
            var sut = builder.Build();

            sut.Render(NoRenderables());

            builder.OutputLines.Should().HaveCount(MAP_ROW_COUNT);
        }

        [Fact]
        public void Render_EntireMapPassageway_AllLines10Spaces()
        {
            var builder = new RendererBuilder();
            var sut = builder.Build();

            sut.Render(NoRenderables());

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

            sut.Render(NoRenderables());

            builder.OutputLines[0].Should().Be(WALL_CELL + new string(' ', MAP_COLUMN_COUNT - 1));
            builder.AssertRowEmpty(1);
        }

        [Theory]
        [InlineData(ElementType.Wall, WALL_CELL)]
        [InlineData(ElementType.Exit, EXIT_CELL)]
        public void Render_MismatchingXYCoordinates_RendersCellAsExpected(ElementType elementType, char expected)
        {
            var builder = new RendererBuilder();

            var sut = builder.WithCellAt(4, 3, elementType)
                             .Build();

            sut.Render(NoRenderables());

            string leftPadding = "   ";
            string rightPadding = "      ";

            builder.AssertRowEmpty(0);
            builder.AssertRowEmpty(1);
            builder.OutputLines[2].Should().Be(leftPadding + expected + rightPadding);
            builder.AssertRowEmpty(3);
        }

        [Fact]
        public void Render_SingleRenderable_RendersAtGivenLocation()
        {
            var builder = new RendererBuilder();

            var sut = builder.Build();

            sut.Render(new[]
                       {
                           CreateRenderable(4, 3, '§', 0),
                       });

            builder.AssertRowEmpty(0);
            builder.AssertRowEmpty(1);
            builder.OutputLines[2].Should().Be("   §      ");
            builder.AssertRowEmpty(3);
        }

        [Fact]
        public void Render_MultipleRenderablesDifferentLocations_RendersAll()
        {
            var builder = new RendererBuilder();

            var sut = builder.Build();

            sut.Render(new[]
                       {
                           CreateRenderable(2, 2, '~', 0),
                           CreateRenderable(4, 3, '§', 0),
                           CreateRenderable(8, 3, '@', 0),
                       });

            builder.AssertRowEmpty(0);
            builder.OutputLines[1].Should().Be(" ~        ");
            builder.OutputLines[2].Should().Be("   §   @  ");
            builder.AssertRowEmpty(3);
        }

        [Fact]
        public void Render_MultipleRenderablesSameLocation_RendersHighestZIndex()
        {
            var builder = new RendererBuilder();

            var sut = builder.Build();

            sut.Render(new[]
                       {
                           CreateRenderable(2, 2, '~', 1),
                           CreateRenderable(4, 3, '§', 0),
                           CreateRenderable(2, 2, '@', 3),
                           CreateRenderable(2, 2, '!', 2),
                       });

            builder.OutputLines[1].Should().Be(" @        ");
        }

        [Theory]
        [InlineData(ElementType.Wall, WALL_CELL)]
        [InlineData(ElementType.Exit, EXIT_CELL)]
        public void Render_RenderableOverlaysMap_RendersMap(ElementType mapElementType, char representation)
        {
            var builder = new RendererBuilder();

            var sut = builder.WithCellAt(3, 2, mapElementType)
                             .Build();

            sut.Render(new[]
                       {
                           CreateRenderable(3, 2, '§', 0),
                       });

            var leftPassageWay = "  ";
            var rightPassageWay = "       ";
            builder.OutputLines[1].Should().Be(leftPassageWay + representation + rightPassageWay);
        }

        private Renderable CreateRenderable(int x, int y, char representation, int zindex) =>
            new Renderable(new FakeHaveLocation(x, y), representation, zindex);

        private class FakeHaveLocation: IHaveLocation
        {
            public FakeHaveLocation(int x, int y)
            {
                Location = new Location(x, y);
            }

            public Location Location { get; }
        }
    }
}