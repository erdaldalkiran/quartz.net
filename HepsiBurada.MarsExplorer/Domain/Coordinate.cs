namespace Domain
{
    using Domain.Enums;

    public struct Coordinate
    {
        public Compass Direction;

        public int X;

        public int Y;

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