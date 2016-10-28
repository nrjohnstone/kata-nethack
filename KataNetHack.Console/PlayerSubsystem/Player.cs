namespace KataNetHack.Console.PlayerSubsystem
{
    public class Player: IHaveLocation
    {
        public Location Location { get; private set; }

        public Player(int x, int y)
        {
            Location = new Location(x, y);
        }
        
        public void MovedNorth()
        {
            Location.Y += 1;
        }

        public void MovedSouth()
        {
        }

        public void MovedWest()
        {
        }

        public void MovedEast()
        {
        }
    }
}