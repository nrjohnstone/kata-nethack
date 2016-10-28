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
        private readonly Location _startingPosition;
        private readonly Player _player;

        public WhenProcessingInput()
        {
            _input = new InputDouble();
            _renderer = new Renderer(new EmptyTenByTenMap());
            _startingPosition = new Location(0, 0);
            _player = new Player(_startingPosition.X, _startingPosition.Y);

            new GameEngine(_input, _player, _renderer);
        }

        [Fact]
        public void GivenInputToMoveThenThePlayerLocationIsUpdated()
        {
            _input.SendInput(InputResult.Up);

            _player
                .Location
                .Should()
                .NotBe(_startingPosition);
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