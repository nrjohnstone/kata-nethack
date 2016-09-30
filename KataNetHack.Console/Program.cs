namespace KataNetHack.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Input.Input input = new Input.Input();

            input.InputReceived += i => System.Console.WriteLine($"Input: {i}");

            while(true)
            {
                input.PollForInput();
            }
        }
    }
}