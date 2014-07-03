namespace Domain.Tests
{
    using Autofac;

    using Infrastructure;

    public abstract class BaseTest
    {
        protected readonly IContainer Container;

        protected BaseTest()
        {
            Container = Bootstrapper.CreateContainer();
        }
    }
}
