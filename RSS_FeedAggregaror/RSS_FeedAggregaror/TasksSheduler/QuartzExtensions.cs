using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace FeedAggregaror_API.TasksSheduler
{
    public static class QuartzExtensions
    {
        public static void UseQuartz(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<IScheduler>();
        }

        public static void UseQuartz(this IApplicationBuilder app, Action<Quartz> configuration)
        {
            // Job Factory through IOC container
            var jobFactory = (IJobFactory)app.ApplicationServices.GetService(typeof(IJobFactory));
            // Set job factory
            Quartz.Instance.UseJobFactory(jobFactory);

            // Run configuration
            configuration.Invoke(Quartz.Instance);
            // Run Quartz
            Quartz.Start();
        }
    }
}
