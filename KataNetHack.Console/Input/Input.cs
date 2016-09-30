using System;

namespace KataNetHack.Console.Input
{
    public class Input
    {
        public Func<ConsoleKeyInfo> ReadKey = () => System.Console.ReadKey();

        public event Action<InputResult> InputReceived;

        public void PollForInput()
        {
            InputResult inputReceived;
            var key = ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.W:
                    inputReceived = InputResult.Up;
                    break;
                case ConsoleKey.A:
                    inputReceived = InputResult.Left;
                    break;
                case ConsoleKey.S:
                    inputReceived = InputResult.Down;
                    break;
                case ConsoleKey.D:
                    inputReceived = InputResult.Right;
                    break;
                default:
                    inputReceived = InputResult.Invalid;
                    break;
            }

            if (inputReceived != InputResult.Invalid)
                InputReceived?.Invoke(inputReceived);
        }
    }
}