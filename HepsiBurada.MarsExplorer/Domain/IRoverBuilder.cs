namespace Domain
{
    public interface IRoverBuilder
    {
        Rover Build(string coordinate, string movement, Plateu plateu);
    }
}