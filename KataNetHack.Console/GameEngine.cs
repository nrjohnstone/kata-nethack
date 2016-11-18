using System;
using KataNetHack.Console.Input;
using KataNetHack.Console.PlayerSubsystem;
using KataNetHack.Console.Renderer;

namespace KataNetHack.Console
{
    public class GameEngine
    {
        private readonly Player _player;
        private readonly Renderer.Renderer _renderer;
        private readonly IMap _map;
        private readonly RenderableFactory _renderableFactory;

        public GameEngine(IInput input, Player player, Renderer.Renderer renderer, IMap map, RenderableFactory renderableFactory)
        {
            _player = player;
            _renderer = renderer;
            _map = map;
            _renderableFactory = renderableFactory;

            input.InputReceived += HandleInputReceived;
        }

        private void HandleInputReceived(InputResult inputResult)
        {
            var originalPosition = (Location)_player.Location.Clone();

            switch (inputResult)
            {
                case InputResult.North:
                    _player.MovedNorth();
                    break;
                case InputResult.South:
                    _player.MovedSouth();
                    break;
                case InputResult.West:
                    _player.MovedWest();
                    break;
                case InputResult.East:
                    _player.MovedEast();
                    break;
                default:
                    break;
            }

            if (!_map.CanMoveTo(_player.Location.Column, _player.Location.Row))
            {
                _player.Location.Column = originalPosition.Column;
                _player.Location.Row = originalPosition.Row;
            }

            if (_map.IsExit(_player.Location.Column, _player.Location.Row))
            {
                RaiseFinished();
            }

            Draw();
        }

        public event EventHandler<EventArgs> Finished;

        private void RaiseFinished()
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }

        public void Draw()
        {
            var renderables = _renderableFactory.CreateRenderable(_player);
            _renderer.Render(new [] { renderables });
        }
    }
}