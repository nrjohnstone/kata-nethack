namespace KataNetHack.Console
{
    public class Renderable
    {
        public Renderable(IHaveLocation source, char representation, int zindex)
        {
            Source = source;
            Representation = representation;
            ZIndex = zindex;
        }

        public IHaveLocation Source { get; }
        public char Representation { get; }
        public int ZIndex { get; }
    }
}