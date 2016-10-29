using KataNetHack.Console.Maps;
using KataNetHack.Console.PlayerSubsystem;
using KataNetHack.Console.Renderer;

namespace KataNetHack.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new Input.Input();
            
            var stageOne = new Stage1();
            var map = stageOne.LoadMap();
            var renderer = new Renderer.Renderer(map);

            var spawnPoint = map.SpawnLocation();
            var player = new Player(spawnPoint);

            var continuePlaying = true;
            var engine = new GameEngine(input, player, renderer, map, new RenderableFactory());
            engine.Finished += (sender, eventArgs) => continuePlaying = false;

            while (continuePlaying)
            {
                input.PollForInput();
            }
        }
    }
}