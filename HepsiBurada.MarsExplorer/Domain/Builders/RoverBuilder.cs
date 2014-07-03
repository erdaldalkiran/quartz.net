namespace Domain.Builders
{
    using System;
    using System.Linq;

    using Domain.Enums;

    public sealed class RoverBuilder : IRoverBuilder
    {
        public Rover Build(string coordinate, string movement, Plateu plateu)
        {
            var coordinateParameters = coordinate.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var x = Convert.ToInt32(coordinateParameters[0]);
            var y = Convert.ToInt32(coordinateParameters[1]);
            var direction = (Compass)Enum.Parse(typeof(Compass), coordinateParameters[2]);
            var movements = movement.Select(z => (MovementType)Enum.Parse(typeof(MovementType), z.ToString())).ToList();
            return new Rover(new Coordinate(x, y, direction), movements, plateu);
        }
    }
}