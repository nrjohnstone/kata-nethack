using System;

namespace KataNetHack.Console.Input
{
    public interface IInput
    {
        event Action<InputResult> InputReceived;
    }
}