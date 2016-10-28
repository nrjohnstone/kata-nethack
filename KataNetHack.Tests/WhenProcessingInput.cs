using System.Collections.Generic;
using FluentAssertions;
using KataNetHack.Console;
using KataNetHack.Console.Input;
using KataNetHack.Console.Maps;
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
        private readonly GameEngine _engine;

        public WhenProcessingInput()
        {
            _input = new InputDouble();
            var map = new Stage1().LoadMap();
            _renderer = new Renderer(map);
            _player = new Player(5, 5);

            _engine = new GameEngine(_input, _player, _renderer, map);
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

        [Fact]
        public void GivenThePlayerMovesToExitThenTheGameEnds()
        {
            var finishedEventWasRaised = false;
            _engine.Finished += (sender, args) => finishedEventWasRaised = true;

            // The exit of the Stage1 map is at 9,9 so put the player at 8,9 and move right
            _player.Location.X = 8;
            _player.Location.Y = 9;
            
            _input.SendInput(InputResult.Right);

            finishedEventWasRaised
                .Should()
                .BeTrue();
        }

        [Fact]
        public void GivenAWallIsNorthOfTheUserAndTheUserMovesNorthThenTheLocationRemainsTheSame()
        {
            _player.Location.X = 2;
            _player.Location.Y = 2;
            var originalLocation = _player.Location.Clone();

            _input.SendInput(InputResult.Up);

            _player
                .Location
                .Should()
                .Be(originalLocation);
        }
    }
}