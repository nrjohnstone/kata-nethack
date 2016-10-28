using KataNetHack.Console.Maps;
using KataNetHack.Console.PlayerSubsystem;

namespace KataNetHack.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new Input.Input();
            var player = new Player(0, 0);

            var stageOne = new Stage1();
            var renderer = new Renderer.Renderer(stageOne.LoadMap());

            var engine = new GameEngine(input, player, renderer);

            while (true)
            {
                input.PollForInput();
            }
        }
    }
}