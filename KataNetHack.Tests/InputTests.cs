using System;

using FluentAssertions;

using KataNetHack.Console.Input;

using Xunit;

namespace KataNetHack.Tests
{
    public class InputTests
    {
        [Theory]
        [InlineData(ConsoleKey.W, InputResult.Up)]
        [InlineData(ConsoleKey.A, InputResult.Left)]
        [InlineData(ConsoleKey.S, InputResult.Down)]
        [InlineData(ConsoleKey.D, InputResult.Right)]
        public void GetInput_ValidInput_ReturnsExpectedResult(ConsoleKey key, InputResult expectedResult)
        {
            Input sut = new Input();
            AssertInputReturns(key, expectedResult, sut);
        }

        [Fact]
        public void GetInput_InvalidInput_ReturnsInvalid()
        {
            Input sut = new Input();
            sut.ReadKey = () => GetInvalidKeyInput();
            InputResult result =  sut.GetInput();

            result.Should().Be(InputResult.Invalid);
        }

        private void AssertInputReturns(ConsoleKey key, InputResult expectedResult, Input sut)
        {
            sut.ReadKey = () => new ConsoleKeyInfo(key.ToString()[0], key, false, false, false);

            InputResult result = sut.GetInput();

            result.Should().Be(expectedResult);
        }

        private ConsoleKeyInfo GetInvalidKeyInput()
        {
            return new ConsoleKeyInfo('Q', ConsoleKey.Q, false, false, false );
        }
    }
}