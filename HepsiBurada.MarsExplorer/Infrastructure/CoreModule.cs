namespace Infrastructure
{
    using Autofac;

    using Domain.Builders;

    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EngineBuilder>().Named<IEngineBuilder>("engineBuilder");
            builder.RegisterDecorator<IEngineBuilder>(
                (context, inner) => new EngineInputValidator(inner),
                fromKey: "engineBuilder");
            
            builder.RegisterType<PlateuBuilder>().Named<IPlateuBuilder>("plateuBuilder");
            builder.RegisterDecorator<IPlateuBuilder>(
                (context, inner) => new PlateuInputValidator(inner),
                fromKey: "plateuBuilder");
            
            builder.RegisterType<RoverBuilder>().Named<IRoverBuilder>("roverBuilder");
            builder.RegisterDecorator<IRoverBuilder>(
               (context, inner) => new RoverInputValidator(inner), 
               fromKey: "roverBuilder");
        }
    }
}