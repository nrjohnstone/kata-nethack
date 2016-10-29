namespace KataNetHack.Console.PlayerSubsystem
{
    public class Player: IHaveLocation
    {
        public Location Location { get; private set; }

        public Player(Location startLocation)
        {
            Location = startLocation;
        }
        
        public void MovedNorth()
        {
            --Location.Row;
        }

        public void MovedSouth()
        {
            ++Location.Row;
        }

        public void MovedWest()
        {
            --Location.Column;
        }

        public void MovedEast()
        {
            ++Location.Column;
        }
    }
}