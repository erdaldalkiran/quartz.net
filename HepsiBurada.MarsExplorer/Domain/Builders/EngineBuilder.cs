namespace Domain.Builders
{
    using System.Collections.Generic;
    using System.Linq;

    public class EngineBuilder : IEngineBuilder
    {
        private readonly IPlateuBuilder _plateuBuilder;

        private readonly IRoverBuilder _roverBuilder;

        public EngineBuilder(IPlateuBuilder plateuBuilder, IRoverBuilder roverBuilder)
        {
            _plateuBuilder = plateuBuilder;
            _roverBuilder = roverBuilder;
        }

        public Engine Build(IList<string> commands)
        {
            var plateu = _plateuBuilder.Build(commands.First());
            var roverCommands = commands.Skip(1).ToList();
            var rovers = GetRovers(roverCommands, plateu);
            return new Engine(rovers);
        }

        private Rover GetRover(string coordinate, string movementCommands, Plateu plateu)
        {
            return _roverBuilder.Build(coordinate, movementCommands, plateu);
        }

        private IList<Rover> GetRovers(IList<string> roverCommands, Plateu plateu)
        {
            var result = new List<Rover>();
            for (var i = 0; i < roverCommands.Count(); i += 2)
            {
                result.Add(GetRover(roverCommands[i], roverCommands[i + 1], plateu));
            }

            return result;
        }
    }
}