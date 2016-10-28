using System;
using System.Linq;

using FluentAssertions;

using KataNetHack.Console.Input;

using Xunit;

namespace KataNetHack.Tests
{
    public class InputTests
    {
        [Theory]
        [InlineData(ConsoleKey.W, InputResult.North)]
        [InlineData(ConsoleKey.A, InputResult.West)]
        [InlineData(ConsoleKey.S, InputResult.South)]
        [InlineData(ConsoleKey.D, InputResult.East)]
        public void PollForInput_ValidInput_FireEvent(ConsoleKey key, InputResult expectedResult)
        {
            Input sut = new Input();
            sut.ReadKey = () => new ConsoleKeyInfo(key.ToString()[0], key, false, false, false);

            sut.MonitorEvents();

            sut.PollForInput();
            var eventMonitored = sut.ShouldRaise(nameof(Input.InputReceived));
            eventMonitored.First().Parameters.First().Should().Be(expectedResult);
        }

        [Fact]
        public void PollForInput_InvalidInput_DoesNotFireEvent()
        {
            Input sut = new Input();
            sut.ReadKey = () => new ConsoleKeyInfo('Q', ConsoleKey.Q, false, false, false );

            sut.MonitorEvents();

            sut.PollForInput();
            sut.ShouldNotRaise(nameof(Input.InputReceived));
        }

        [Fact]
        public void PollForInput_NoEventHandler_DoesNotThrow()
        {
            Input sut = new Input();
            sut.ReadKey = () => new ConsoleKeyInfo('W', ConsoleKey.W, false, false, false);

            Action pollWhenNoEventSubscription = ()=>sut.PollForInput();

            pollWhenNoEventSubscription.ShouldNotThrow();
        }
    }
}