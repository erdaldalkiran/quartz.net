namespace Domain.Commands
{
    using System;

    using Domain.Enums;

    public sealed class MovementCommandFactory
    {
        public static IMovementCommand GetMovementCommand(MovementType movementType)
        {
            switch (movementType)
            {
                case MovementType.L:
                    return new TurnLeftMovementCommand();
                case MovementType.R:
                    return new TurnRightMovementCommand();
                case MovementType.M:
                    return new MoveForwardMovementCommand();
                default:
                    throw new ArgumentOutOfRangeException(
                        string.Format("{0} movement type is not supported.", movementType));
            }
        }
    }
}