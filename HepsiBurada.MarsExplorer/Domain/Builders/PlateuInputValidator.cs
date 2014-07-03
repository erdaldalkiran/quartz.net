namespace Domain.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class PlateuInputValidator : IPlateuBuilder
    {
        private readonly IPlateuBuilder _plateuBuilder;

        public PlateuInputValidator(IPlateuBuilder plateuBuilder)
        {
            _plateuBuilder = plateuBuilder;
        }

        public Plateu Build(string command)
        {
            ValidateCommand(command);
            return _plateuBuilder.Build(command);
        }

        private IEnumerable<int> GetSizesOfArea(string command)
        {
            return SplitAreaCommand(command).Select(x => Convert.ToInt32(x)).ToArray();
        }

        private IEnumerable<string> SplitAreaCommand(string command)
        {
            return command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void ValidateCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException("Please enter an area command which is not empty or whitespace");
            }

            var sizes = SplitAreaCommand(command).ToList();
            if (sizes.Count() != 2)
            {
                throw new ArgumentException(
                    "Invalid number of sizes. Please provide width and height of the area. Like '4 4'.");
            }

            foreach (var size in sizes)
            {
                int result;
                if (!int.TryParse(size, out result))
                {
                    throw new ArgumentException(
                        string.Format("Please provide valid sizes for area. {0} is not a valid number.", size));
                }

                if (result < 1)
                {
                    throw new ArgumentException(
                        string.Format("Please provide valid sizes for area. {0} is not a positive number.", size));
                }
            }

            if (GetSizesOfArea(command).ToList().Aggregate(1, (x, y) => x * y) <= 1)
            {
                throw new ArgumentException("Please provide valid sizes for area. Area must be greater than 1");
            }
        }
    }
}