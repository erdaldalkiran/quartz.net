namespace Domain.Commands
{
    using Domain.Enums;

    public sealed class TurnRightMovementCommand : IMovementCommand
    {
        public Coordinate Move(Coordinate startingPoint)
        {
            var newDirection = (int)startingPoint.Direction + 1;
            if (newDirection == 4)
            {
                newDirection -= 4;
            }
            var direction = (Compass)newDirection;
            return new Coordinate(startingPoint.X, startingPoint.Y, direction);
        }
    }
}