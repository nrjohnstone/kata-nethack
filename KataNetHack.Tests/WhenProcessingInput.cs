using System.Collections.Generic;
using FluentAssertions;
using KataNetHack.Console;
using KataNetHack.Console.Input;
using KataNetHack.Console.PlayerSubsystem;
using KataNetHack.Console.Renderer;
using Xunit;

namespace KataNetHack.Tests
{
    public class WhenProcessingInput
    {
        private readonly InputDouble _input;
        private readonly Renderer _renderer;
        private readonly Player _player;

        public WhenProcessingInput()
        {
            _input = new InputDouble();
            _renderer = new Renderer(new EmptyTenByTenMap());
            _player = new Player(0, 0);

            new GameEngine(_input, _player, _renderer);
        }

        [Theory]
        [InlineData(InputResult.Up)]
        [InlineData(InputResult.Left)]
        [InlineData(InputResult.Down)]
        [InlineData(InputResult.Right)]
        public void GivenInputToMoveThenThePlayerLocationIsUpdated(InputResult inputResult)
        {
            var originalPosition = _player.Location.Clone();

            _input.SendInput(inputResult);

            _player
                .Location
                .Should()
                .NotBe(originalPosition);
        }

        [Fact]
        public void GivenInputToThenTheWorldIsRendered()
        {
            var output = new List<string>();
            _renderer.WriteLine = line => output.Add(line);

            _input.SendInput(InputResult.Up);

            output
                .Should()
                .HaveCount(10);
        }
    }
}