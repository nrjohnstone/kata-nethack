using System.Linq;
using KataNetHack.Console;
using KataNetHack.Console.Maps;

namespace KataNetHack.Tests
{
    public class EmptyTenByTenMap : Map
    {
        public EmptyTenByTenMap()
            : base(new ListMatrix(Enumerable.Range(0, 100).Select(number => ' ')))
        {   
        }
    }
}