using System.Collections.Generic;
using KataNetHack.Console;
using KataNetHack.Console.Renderer;

namespace KataNetHack.Tests
{
    public class RendererDouble : Renderer
    {
        public List<string> Output { get; }

        public RendererDouble(IMap map) : base(map)
        {
            Output = new List<string>();
            WriteLine = line => Output.Add(line);
            ClearScreen = () => Output.Clear();
        }
    }
}