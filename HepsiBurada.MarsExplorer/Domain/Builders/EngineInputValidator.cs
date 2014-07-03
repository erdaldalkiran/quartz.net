namespace Domain.Builders
{
    using System;
    using System.Collections.Generic;

    public class EngineInputValidator : IEngineBuilder
    {
        private readonly IEngineBuilder _engineBuilder;

        public EngineInputValidator(IEngineBuilder engineBuilder)
        {
            _engineBuilder = engineBuilder;
        }

        public Engine Build(IList<string> commands)
        {
            ValidateCommands(commands);
            return _engineBuilder.Build(commands);
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
    }
}