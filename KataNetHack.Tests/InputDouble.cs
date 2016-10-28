using System;
using KataNetHack.Console.Input;

namespace KataNetHack.Tests
{
    public class InputDouble : IInput
    {
        public event Action<InputResult> InputReceived;

        public void SendInput(InputResult inputResult)
        {
            InputReceived?.Invoke(inputResult);
        }
    }
}