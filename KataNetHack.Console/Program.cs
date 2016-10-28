using KataNetHack.Console.Maps;
using KataNetHack.Console.PlayerSubsystem;

namespace KataNetHack.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new Input.Input();
            var player = new Player(5, 5);

            var stageOne = new Stage1();
            var map = stageOne.LoadMap();
            var renderer = new Renderer.Renderer(map);

            var continuePlaying = true;
            var engine = new GameEngine(input, player, renderer, map);
            engine.Finished += (sender, eventArgs) => continuePlaying = false;

            while (continuePlaying)
            {
                input.PollForInput();
            }
        }
    }
}