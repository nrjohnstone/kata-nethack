using KataNetHack.Console.PlayerSubsystem;

namespace KataNetHack.Console.Renderer
{
    public class RenderableFactory
    {
        public const char PLAYER_REPRESENTATION = '☺';
        public const int PLAYER_ZINDEX = 10;

        public Renderable CreateRenderable(Player player)
        {
            return new Renderable(player, PLAYER_REPRESENTATION, PLAYER_ZINDEX);
        }
    }
}