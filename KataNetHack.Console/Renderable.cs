namespace KataNetHack.Console
{
    public class Renderable
    {
        public IHaveLocation Source { get; }
        public char Representation { get; }
        public int ZIndex { get; }
    }
}