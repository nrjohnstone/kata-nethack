using System;
using KataNetHack.Console.Input;
using KataNetHack.Console.PlayerSubsystem;

namespace KataNetHack.Console
{
    public class GameEngine
    {
        private readonly Player _player;
        private readonly Renderer.Renderer _renderer;
        private readonly IMap _map;

        public GameEngine(IInput input, Player player, Renderer.Renderer renderer, IMap map)
        {
            _player = player;
            _renderer = renderer;
            _map = map;

            input.InputReceived += HandleInputReceived;
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

            if (_map.IsExit(_player.Location.X, _player.Location.Y))
            {
                RaiseFinished();
            }

            _renderer.Render(new Renderable[0]);
        }

        public event EventHandler<EventArgs> Finished;

        private void RaiseFinished()
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }
    }
}