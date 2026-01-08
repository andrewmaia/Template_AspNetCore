using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Workers.Jobs;
using Quartz;

namespace ProjectName.Workers;
public static class DependencyInjection
{
    public static IServiceCollection AddQuartz(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var jobConfig = configuration
            .GetSection(ExampleJobConfiguration.SectionName)
            .Get<ExampleJobConfiguration>();

        services.AddQuartz(q =>
        {
            var jobKey = new JobKey(nameof(ExampleJob));
            q.AddJob<ExampleJob>(opts => opts.WithIdentity(jobKey))
             .AddTrigger(opts => opts
                 .ForJob(jobKey)
                 //.StartNow());
                 .WithCronSchedule(jobConfig!.CronExpression!));
        });

        services.AddQuartzHostedService(o => o.WaitForJobsToComplete = true);

        return services;
    }
}
