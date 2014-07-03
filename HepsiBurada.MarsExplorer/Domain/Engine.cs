namespace Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Engine
    {
        private readonly IList<Rover> _rovers;

        public Engine( IList<Rover> rovers)
        {
            _rovers = rovers;
        }

        public IList<string> Play()
        {
            return _rovers.Select(x => x.Play()).ToList();
        }
    }
}