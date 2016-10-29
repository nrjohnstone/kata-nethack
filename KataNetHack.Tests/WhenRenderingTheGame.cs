using FluentAssertions;
using KataNetHack.Console.Input;
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
            var input = new InputDouble();
            var renderer = new RendererDouble(map);

            var engine = new GameEngineBuilder()
                .WithInput(input)
                .WithRenderer(renderer)
                .WithPlayer(new Player(map.SpawnLocation()))
                .Build();

            input.SendInput(InputResult.East);

            renderer
                .Output[4]
                .Should()
                .Contain(RenderableFactory.PLAYER_REPRESENTATION.ToString());
        }
    }
}