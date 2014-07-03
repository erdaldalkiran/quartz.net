namespace Domain.Commands
{
    using Domain.Enums;

    public sealed class TurnLeftMovementCommand : IMovementCommand
    {
        public Coordinate Move(Coordinate startingPoint)
        {
            var newDirection = (int)startingPoint.Direction - 1;
            if (newDirection == -1)
            {
                newDirection += 4;
            }
            var direction = (Compass)newDirection;
            return new Coordinate(startingPoint.X, startingPoint.Y, direction);
        }
    }
}