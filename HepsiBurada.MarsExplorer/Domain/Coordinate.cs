namespace Domain
{
    public class Coordinate
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Compass Direction { get; private set; }

        public Coordinate(int x, int y, Compass direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", X, Y, Direction);
        }
    }
}