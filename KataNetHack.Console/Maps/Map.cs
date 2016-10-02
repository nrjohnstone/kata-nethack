using System.Collections.Generic;
using System.Linq;
using System.Text;
using KataNetHack.Console.Maps;

namespace KataNetHack.Console
{
    public interface IMap
    {
        bool CanMoveTo(int column, int row);
        bool IsExit(int column, int row);
        ElementType GetElementType(int column, int row);
    }

    public class Map : IMap
    {
        private readonly Matrix _matrix;

        public int Width => _matrix.Width;
        public int Height => _matrix.Height;

        public Map(Matrix matrix)
        {
            this._matrix = matrix;
        }

        public static IMap Create(IEnumerable<char> mapItems, int width, int height)
        {
            var matrix = new ListMatrix(mapItems, width, height);
            var map = new Map(matrix);
            
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
                else if (i == 88)
                {
                    yield return new Element() { Type = ElementType.Exit };
                }
                else
                {
                    yield return new Element() { Type = ElementType.PassageWay };
                }
            }
        }

        public Element ElementAt(int column, int row)
        {
            return this._matrix.ElementAt(column, row);
        }

        public bool CanMoveTo(int column, int row)
        {
            return ElementAt(column, row).Type != ElementType.Wall;
        }

        public bool IsExit(int column, int row)
        {
            var element = ElementAt(column, row);
            return element.Type == ElementType.Exit;
        }

        public ElementType GetElementType(int column, int row)
        {
            return ElementAt(column, row).Type;
        }

        public override string ToString()
        {
            return _matrix.ToString();
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
