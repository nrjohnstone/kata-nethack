using System;
using System.Collections.Generic;
using System.Text;

using FluentAssertions;

using KataNetHack.Console;

using Moq;

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

            var sut = builder.WithWallAt(0, 0)
                             .Build();

            sut.Render();

            builder.OutputLines[0].Should().Be("█" + new string(' ', MAP_COLUMN_COUNT - 1));
            builder.AssertRowEmpty(1);
        }

        [Fact]
        public void Render_MismatchingXYCoordinatesWall_RendersCellAsWall()
        {
            var builder = new RendererBuilder();

            var sut = builder.WithWallAt(3, 2)
                             .Build();

            sut.Render();

            builder.AssertRowEmpty(0);
            builder.AssertRowEmpty(1);
            builder.OutputLines[2].Should().Be("   █      ");
            builder.AssertRowEmpty(3);
        }
    }

    public class Renderer
    {
        private const int MAP_ROW_COUNT = 10;
        private const int MAP_COLUMN_COUNT = 10;
        private const char WALL_CHARACTER = '█';
        private const char PASSAGEWAY_CHARACTER = ' ';

        private readonly IMap _map;

        public Action<string> WriteLine = System.Console.WriteLine;

        public Renderer(IMap map)
        {
            _map = map;
        }

        public void Render()
        {
            for(int row = 0;row < MAP_ROW_COUNT;row++)
            {
                var builder = new StringBuilder();

                for(var column = 0;column < MAP_COLUMN_COUNT;column++)
                {
                    if(_map.GetElementType(column, row) == ElementType.Wall)
                    {
                        builder.Append(WALL_CHARACTER);
                    }
                    else
                    {
                        builder.Append(PASSAGEWAY_CHARACTER);
                    }
                }

                WriteLine(builder.ToString());
            }
        }
    }

    public class RendererBuilder
    {
        private Mock<IMap> Map { get; } = new Mock<IMap>();
        public IReadOnlyList<string> OutputLines => _lines;
        private readonly List<string> _lines = new List<string>();

        public RendererBuilder()
        {
            Map.Setup(obj => obj.GetElementType(It.IsAny<int>(), It.IsAny<int>()))
               .Returns(ElementType.PassageWay);
        }

        public RendererBuilder WithWallAt(int x, int y)
        {
            Map.Setup(obj => obj.GetElementType(x, y))
               .Returns(ElementType.Wall);

            return this;
        }

        public Renderer Build()
        {
            return new Renderer(Map.Object)
                   {
                       WriteLine = line => _lines.Add(line)
                   };
        }
    }

    public static class RendererAssertions
    {
        private static readonly string EMPTY_ROW = new string(' ', 10);

        public static void AssertRowEmpty(this RendererBuilder builder, int row)
        {
            builder.OutputLines[row].Should().Be(EMPTY_ROW);
        }
    }
}