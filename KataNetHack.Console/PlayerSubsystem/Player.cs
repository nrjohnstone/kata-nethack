using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataNetHack.Console.PlayerSubsystem
{
    public class Player
    {
        public Player(Point startingPosition)
        {
            Position = startingPosition;
        }

        public Point Position { get; private set; }

        public void MoveNorth()
        {
        }

        public void MoveSouth()
        {
        }

        public void MoveWest()
        {
        }

        public void MoveEast()
        {
        }
    }
}