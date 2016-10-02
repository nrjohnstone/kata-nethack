using KataNetHack.Console.Maps;
using Xunit;

namespace KataNetHack.Tests
{
    public class StageTests
    {
        [Fact]
        public void ExploreDesign()
        {
            //IEnumerable<char> fromReader
            var stage = new Stage1();
            var map = stage.LoadMap();
            Assert.True(map.CanMoveTo(2,2));
        }
    }
}
