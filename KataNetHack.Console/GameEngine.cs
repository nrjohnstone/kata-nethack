using KataNetHack.Console.Input;
using KataNetHack.Console.PlayerSubsystem;

namespace KataNetHack.Console
{
    public class GameEngine
    {
        private readonly IInput _input;
        private readonly Player _player;
        private readonly Renderer.Renderer _renderer;

        public GameEngine(IInput input, Player player, Renderer.Renderer renderer)
        {
            _input = input;
            _player = player;
            _renderer = renderer;

            _input.InputReceived += HandleInputReceived;
        }

        private void HandleInputReceived(InputResult inputResult)
        {
            switch (inputResult)
            {
                case InputResult.Up:
                    _player.MovedNorth();
                    break;
                case InputResult.Down:
                    _player.MovedSouth();
                    break;
                case InputResult.Left:
                    _player.MovedWest();
                    break;
                case InputResult.Right:
                    _player.MovedEast();
                    break;
                default:
                    break;
            }

            _renderer.Render(new Renderable[0]);
        }
    }
}