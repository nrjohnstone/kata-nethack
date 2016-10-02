using System;
using System.Linq;

namespace KataNetHack.Console.Maps
{
    public class Stage1 : IStage
    {
        private readonly string _mapTile = "Stage 1";
        private readonly string _mapDescription = "Tutorial stage";
        private readonly string _mapDescriptor =
@"==========
=!       =
=        =
=        =
=        =
=        =
=        =
=        =
=       *=
==========";


        public string MapTile => _mapTile;

        public string MapDescription => _mapDescription;

        public string MapDescriptor => _mapDescriptor.Replace(Environment.NewLine, "").Trim();

        public IMap LoadMap()
        {
            return Map.Create(_mapDescriptor.Replace(Environment.NewLine, "").ToCharArray(), CalculateWidth(), CalculateHeight());
        }

        private int CalculateHeight()
        {
            return _mapDescriptor.Count(f => f == '\n') + 1;
        }

        private int CalculateWidth()
        {
            return _mapDescriptor.IndexOf(Environment.NewLine);
        }
    }

    public interface IStage
    {
        string MapTile { get; }
        string MapDescription { get; }
        string MapDescriptor { get; }
    }
}
