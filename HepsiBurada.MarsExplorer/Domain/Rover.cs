namespace Domain
{
    using System.Collections.Generic;

    using Domain.Commands;
    using Domain.Enums;

    public sealed class Rover
    {
        public const string SignalLost = "Signal Lost";

        private readonly Plateu _plateu;

        public Rover(Coordinate coordinate, IList<MovementType> movements, Plateu plateu)
        {
            _plateu = plateu;
            Coordinate = coordinate;
            Movements = movements;
        }

        public Coordinate? Coordinate { get; private set; }
        public IList<MovementType> Movements { get; private set; }

        public string Location()
        {
            return Coordinate.ToString();
        }

        public string Play()
        {
            foreach (var movementType in Movements)
            {
                var lastCoordinate = MovementCommandFactory.GetMovementCommand(movementType).Move(Coordinate.Value);
                if (_plateu.IsCoordinateInsideTheArea(lastCoordinate))
                {
                    Coordinate = lastCoordinate;
                }
                else
                {
                    Coordinate = null;
                    break;
                }
            }

            return Coordinate.HasValue ? Coordinate.Value.ToString() : SignalLost;
        }
    }
}