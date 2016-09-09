using System;

namespace KataNetHack.Console.Input
{
    public class Input
    {
        public Func<ConsoleKeyInfo> ReadKey = () => System.Console.ReadKey();

        public InputResult GetInput()
        {
            var key = ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.W:
                    return InputResult.Up;
                case ConsoleKey.A:
                    return InputResult.Left;
                case ConsoleKey.S:
                    return InputResult.Down;
                case ConsoleKey.D:
                    return InputResult.Right;
                default:
                    return InputResult.Invalid;
            }
        }
    }
}