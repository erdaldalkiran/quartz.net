namespace Domain.Builders
{
    using System.Collections.Generic;

    public interface IEngineBuilder
    {
        Engine Build(IList<string> commands);
    }
}