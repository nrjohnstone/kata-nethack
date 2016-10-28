using System;

namespace KataNetHack.Console.Input
{
    public class Input : IInput, IInputPoller
    {
        public Func<ConsoleKeyInfo> ReadKey = () => System.Console.ReadKey(intercept:true);

        public event Action<InputResult> InputReceived;

        public void PollForInput()
        {
            InputResult inputReceived;
            var key = ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.W:
                    inputReceived = InputResult.North;
                    break;
                case ConsoleKey.A:
                    inputReceived = InputResult.West;
                    break;
                case ConsoleKey.S:
                    inputReceived = InputResult.South;
                    break;
                case ConsoleKey.D:
                    inputReceived = InputResult.East;
                    break;
                default:
                    inputReceived = InputResult.Invalid;
                    break;
            }

            if(inputReceived != InputResult.Invalid)
                InputReceived?.Invoke(inputReceived);
        }
    }
}