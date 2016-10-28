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
            --Location.Y;
        }

        public void MovedSouth()
        {
            ++Location.Y;
        }

        public void MovedWest()
        {
            --Location.X;
        }

        public void MovedEast()
        {
            ++Location.X;
        }
    }
}