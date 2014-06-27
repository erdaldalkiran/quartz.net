namespace ConsoleApp
{
    using System;
    using System.Threading;

    using Common.Logging.Simple;

    using Quartz;
    using Quartz.Impl;

    public class Program
    {
        private static void Main(string[] args)
        {
            Common.Logging.LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter{Level = Common.Logging.LogLevel.Info};
            try
            {
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                scheduler.Start();

                IJobDetail job = JobBuilder.Create<HelloJob>()
                    .WithIdentity("jobkey ", "groupkey ")
                    .UsingJobData("says","Erdal was here!")
                    .Build();

                ITrigger trigger =
                    TriggerBuilder.Create()
                        .WithIdentity("trigger1", "group1")
                        .StartNow()
                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(1).RepeatForever())
                        .Build();

                scheduler.ScheduleJob(job, trigger);

                Thread.Sleep(TimeSpan.FromSeconds(10));

                scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
    }
}
