namespace Domain.Commands
{
    using System;

    using Domain.Enums;

    public sealed class MoveForwardMovementCommand : IMovementCommand
    {
        public Coordinate Move(Coordinate startingPoint)
        {
            switch (startingPoint.Direction)
            {
                case Compass.N:
                    return new Coordinate(startingPoint.X, startingPoint.Y + 1, startingPoint.Direction);
                case Compass.E:
                    return new Coordinate(startingPoint.X + 1, startingPoint.Y, startingPoint.Direction);
                case Compass.S:
                    return new Coordinate(startingPoint.X, startingPoint.Y - 1, startingPoint.Direction);
                case Compass.W:
                    return new Coordinate(startingPoint.X - 1, startingPoint.Y, startingPoint.Direction);
                default:
                    throw new ArgumentOutOfRangeException(
                        string.Format("Have you invented a new direction:{0}", startingPoint.Direction));
            }
        }
    }
}