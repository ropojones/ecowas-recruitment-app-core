using Microsoft.Extensions.DependencyInjection;
using Quartz;
namespace EcoRecruit.Core.BackgroundServices
{
    public static  class QuartzDependencyInjection
    {
        public static void AddQuartzInfrastructure(this IServiceCollection services)
        {
            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();

                var jobKey = JobKey.Create(nameof(BackgroundJobAccountActivationNotification));

                options.AddJob<BackgroundJobAccountActivationNotification>(jobKey);
                options.AddTrigger(trigger => trigger.ForJob(jobKey)
                       .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));
            });

            services.AddQuartzHostedService();
        }
    }
}
