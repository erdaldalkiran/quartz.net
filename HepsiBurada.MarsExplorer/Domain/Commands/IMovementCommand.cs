namespace Domain.Commands
{
    public interface IMovementCommand
    {
        Coordinate Move(Coordinate startingPoint);
    }
}