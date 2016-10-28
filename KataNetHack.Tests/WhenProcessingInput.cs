using System.Drawing;
using FluentAssertions;
using KataNetHack.Console;
using KataNetHack.Console.Input;
using KataNetHack.Console.PlayerSubsystem;
using Xunit;

namespace KataNetHack.Tests
{
    public class WhenProcessingInput
    {
        // Game Engine
        // Start
        //  - Receive input (via event)
        //  - Move player
        //  - Render world
        [Fact]
        public void GivenInputToMoveThenThePlayerLocationIsUpdated()
        {
            var input = new InputDouble();
            var startingPosition = new Point(0, 0);
            var player = new Player(startingPosition);
            new GameEngine(input, player);

            input.SendInput(InputResult.Up);

            player
                .Position
                .Should()
                .NotBe(startingPosition);
        }

        [Fact]
        public void GivenInputToThenTheWorldIsRendered()
        {
            var input = new InputDouble();
            var startingPosition = new Point(0, 0);
            var player = new Player(startingPosition);
            new GameEngine(input, player);

            input.SendInput(InputResult.Up);
        }
    }
}