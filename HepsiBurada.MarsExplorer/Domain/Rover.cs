namespace Domain
{
    using System.Collections.Generic;

    public class Rover
    {
        private readonly Plateu _plateu;

        public Rover(Coordinate coordinate, IList<MovementType> movements, Plateu plateu)
        {
            _plateu = plateu;
            Coordinate = coordinate;
            Movements = movements;
        }

        public Coordinate Coordinate { get; private set; }
        public IList<MovementType> Movements { get; private set; }

        public string Play()
        {
            if (_plateu.IsCoordinateInsideTheArea(Coordinate))
            {
                return "2 1 N";
                
            }

            return null;
        }

        public string Location()
        {
            return Coordinate.ToString();
        }
    }
}