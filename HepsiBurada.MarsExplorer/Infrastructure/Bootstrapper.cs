namespace Infrastructure
{
    using Autofac;

    public static class Bootstrapper
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CoreModule>();

            return builder.Build();
        }
    }
}