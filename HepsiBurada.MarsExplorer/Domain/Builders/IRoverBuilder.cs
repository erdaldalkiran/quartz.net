namespace Domain.Builders
{
    public interface IRoverBuilder
    {
        Rover Build(string coordinate, string movement, Plateu plateu);
    }
}