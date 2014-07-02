namespace Domain
{
    using System;
    using System.Linq;

    public class PlateuBuilder : IPlateuBuilder
    {
        public Plateu Build(string command)
        {
            var parameters = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var width = Convert.ToInt32(parameters[0]);
            var height = Convert.ToInt32(parameters[1]);
            return new Plateu(width, height);
        }

      

       
    }
}