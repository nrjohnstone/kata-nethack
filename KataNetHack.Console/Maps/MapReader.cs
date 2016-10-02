using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace KataNetHack.Console.Maps
{
    internal class MapReader
    {
        public IEnumerable<char> GetMapElements(string filePath, int size = 100)
        {
            var result = new List<char>();
            using(var stream = new MemoryStream())
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    result.Add((char) reader.Read());
                }
            }

            return result;
        }
    }
}
