using FluentAssertions;

using KataNetHack.Console.Maps;
using KataNetHack.Console.PlayerSubsystem;
using KataNetHack.Console.Renderer;
using Xunit;

namespace KataNetHack.Tests
{
    public class WhenRenderingTheGame
    {
        [Fact]
        public void ThenItRendersThePlayer()
        {
            var map = new Stage1().LoadMap();
            var renderer = new RendererDouble(map);

            var engine = new GameEngineBuilder()
                .WithRenderer(renderer)
                .WithPlayer(new Player(map.SpawnLocation()))
                .Build();

            engine.Draw();

            int zeroBasedRow = map.SpawnLocation().Row - 1;
            int zeroBasedColumn = map.SpawnLocation().Column - 1;
            char cellForSpawnLocation = renderer.Output[zeroBasedRow][zeroBasedColumn];

            cellForSpawnLocation.Should().Be(RenderableFactory.PLAYER_REPRESENTATION);
        }
    }
}