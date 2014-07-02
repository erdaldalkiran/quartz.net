namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly IPlateuBuilder _plateuBuilder;

        private readonly IRoverBuilder _roverBuilder;

        #region Fields

        private Plateu _plateu;

        private readonly IList<Rover> _rovers = new List<Rover>();

        #endregion

        #region Constructors and Destructors

        public Engine(IPlateuBuilder plateuBuilder, IRoverBuilder roverBuilder)
        {
            _plateuBuilder = plateuBuilder;
            _roverBuilder = roverBuilder; ;
        }

        #endregion

        #region Public Methods and Operators

        public IList<string> Play()
        {
            return _rovers.Select(x => x.Play()).ToList();
        }

        #endregion

        #region Methods



        public void Initialize(IList<string> commands)
        {
            ValidateCommands(commands);

            _plateu = _plateuBuilder.Build(commands.First());
            var roverCommands = commands.Skip(1).ToList();
            SetRovers(roverCommands);
        }

        private void SetARover(string coordinate, string movementCommands)
        {
            var rover = _roverBuilder.Build(coordinate, movementCommands,_plateu);
            _rovers.Add(rover);
        }

        private void SetRovers(IList<string> roverCommands)
        {
            for (var i = 0; i < roverCommands.Count(); i += 2)
            {
                SetARover(roverCommands[i], roverCommands[i + 1]);
            }
        }

        private void ValidateCommands(IList<string> commands)
        {
            if (commands == null)
            {
                throw new ArgumentNullException("commands");
            }
            if (commands.Count < 3)
            {
                throw new ArgumentException("Please enter at least 3 commands. First one for area, others for rover");
            }

            if ((commands.Count - 1) % 2 != 0)
            {
                throw new ArgumentException("Missing rover command. Please check all rover commands are entered.");
            }
        }



        #endregion
    }
}