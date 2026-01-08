using Microsoft.Extensions.Logging;
using ProjectName.Application.Execution;
using ProjectName.Application.UsesCases.CreateOrder;
using ProjectName.Application.UsesCases.SendEmailToOpenOrders;
using Quartz;

namespace ProjectName.Workers.Jobs;

[DisallowConcurrentExecution]
public class ExampleJob: IJob
{
    private readonly ILogger<ExampleJob> _logger;
    private readonly RequestExecutor _executor;
    public ExampleJob(ILogger<ExampleJob> logger, RequestExecutor executor)
    {
        _logger = logger;
        _executor = executor;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("{job} started at: {time}", GetType().Name, DateTimeOffset.Now);
        await _executor.ExecuteAsync<SendEmailToOpenOrdersRequest, SendEmailToOpenOrdersResponse>(new SendEmailToOpenOrdersRequest());
        _logger.LogInformation("{job} finished at: {time}", GetType().Name, DateTimeOffset.Now);
    }
}


public class ExampleJobConfiguration
{
    public const string SectionName = "ExampleJobConfiguration";
    public string? CronExpression { get; set; } 
}


