using Microsoft.Extensions.DependencyInjection;
using Quartz;
using QuartzWorker.Jobs;

namespace QuartzWorker.Config {
    public static class ConfigureQuartz {
        public static void AddQuartzWorker(this IServiceCollection services) {
            services.AddQuartz(q => {
                // Use a Scoped container to create jobs. I'll touch on this later
                q.UseMicrosoftDependencyInjectionScopedJobFactory();
                // Create a "key" for the job
                var jobKey = new JobKey("AddTaskToArchivedJob");
                // Register the job with the DI container
                q.AddJob<AddTaskToArchivedJob>(opts => opts.WithIdentity(jobKey));

                // Create a trigger for the job
                q.AddTrigger(opts => opts
                    .ForJob(jobKey) // link to the HelloWorldJob
                    .WithIdentity("AddTaskToArchivedJob-trigger") // give the trigger a unique name
                    .WithCronSchedule("0/5 * * * * ?")); // run every 5 seconds
            });
            // Add the Quartz.NET hosted service
            services.AddQuartzHostedService(
                q => q.WaitForJobsToComplete = true);
            // other config
        }
    }
}
