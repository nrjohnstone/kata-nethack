using System.Collections.Generic;

namespace KataNetHack.Console
{
    public class Map
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
                yield return new Element();
            }
        }

    }

    public class Element
    {
        //type, x, y
    }
}