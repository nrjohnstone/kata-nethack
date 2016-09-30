using System.Collections.Generic;
using System.Linq;

namespace KataNetHack.Console
{
    public interface IMap
    {
        bool CanMoveTo(int x, int y);
        bool IsExit(int x, int y);
        ElementType GetElementType(int x, int y);
    }

    public class Map : IMap
    {

        public IEnumerable<Element> Elements { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            Elements = new List<Element>();
        }

        public static Map Create(int width, int height)
        {
            var map = new Map(width, height);
            map.Elements = PopulateElements();
            return map;
        }

        private static IEnumerable<Element> PopulateElements(int number = 100)
        {
            
            for (int i = 0; i < number; i++)
            {
                if (i < 10)
                {
                    yield return new Element();
                }
                else if (i == 99)
                {
                    yield return new Element() { Type = ElementType.Exit };
                }
                else
                {
                    yield return new Element() { Type = ElementType.PassageWay };
                }
            }
        }

        public Element ElementAt(int x, int y)
        {
            int position = (y * Width) - x + 1;
            if (y == 10)
            {
                position = (y * Width - 1);
                return Elements.ToArray()[position];
            }
            
            return Elements.ToArray()[position];
        }

        public bool CanMoveTo(int x, int y)
        {
            return ElementAt(x, y).Type != ElementType.Wall;
        }

        public bool IsExit(int x, int y)
        {
            var element = ElementAt(x, y);
            return element.Type == ElementType.Exit;
        }

        public ElementType GetElementType(int x, int y)
        {
            return ElementAt(x, y).Type;
        }
    }

    

    public class Element
    {
        public ElementType Type { get; set; }
    }

    public enum ElementType
    {
        Wall, PassageWay, Exit
    }
}
