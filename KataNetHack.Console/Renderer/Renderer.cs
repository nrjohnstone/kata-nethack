using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataNetHack.Console.Renderer
{
    public class Renderer
    {
        private const int MAP_ROW_COUNT = 10;
        private const int MAP_COLUMN_COUNT = 10;
        private const char WALL_CHARACTER = '█';
        private const char PASSAGEWAY_CHARACTER = ' ';
        private const char EXIT_CHARACTER = '*';

        private readonly IMap _map;

        public Action<string> WriteLine = System.Console.WriteLine;
        public Action ClearScreen = System.Console.Clear;

        public Renderer(IMap map)
        {
            _map = map;
        }

        public void Render(IEnumerable<Renderable> items)
        {
            ClearScreen();

            for(int row = 1; row <= MAP_ROW_COUNT; row++)
            {
                var builder = new StringBuilder();

                for(var column = 1; column <= MAP_COLUMN_COUNT; column++)
                {
                    if(_map.GetElementType(column, row) == ElementType.Wall)
                    {
                        builder.Append(WALL_CHARACTER);
                    }
                    else if(_map.GetElementType(column, row) == ElementType.Exit)
                    {
                        builder.Append(EXIT_CHARACTER);
                    }
                    else
                    {
                        var item = items.OrderByDescending(i => i.ZIndex)
                                        .FirstOrDefault(i => i.Source.Location.X == column &&
                                                             i.Source.Location.Y == row);

                        if(item != null)
                        {
                            builder.Append(item.Representation);
                        }
                        else
                        {
                            builder.Append(PASSAGEWAY_CHARACTER);
                        }
                    }
                }

                WriteLine(builder.ToString());
            }
        }
    }
}