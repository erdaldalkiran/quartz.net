namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Autofac;

    using Domain.Builders;

    using Infrastructure;

    internal class Program
    {
        private static List<string> GetCommands()
        {
            var result = new List<string>();
            using (var stream = new StreamReader("Input.txt"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }

            return result;
        }

        private static void Main()
        {
            try
            {
                var container = Bootstrapper.CreateContainer();
                var engineBuilder = container.Resolve<IEngineBuilder>();
                var engine = engineBuilder.Build(GetCommands());
                var output = engine.Play().ToList();
                output.ForEach(Console.WriteLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to end program.");
            Console.ReadKey();
        }

    }
}