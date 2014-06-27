namespace ConsoleApp
{
    using System;

    using Quartz;

    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;

            var value = dataMap.GetString("says");
            var key = context.JobDetail.Key;
            Console.WriteLine("Key: {0} Says:{1}",key,value);
        }
    }
}