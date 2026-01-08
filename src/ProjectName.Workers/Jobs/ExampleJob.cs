using Microsoft.Extensions.Logging;
using ProjectName.Application.UsesCases;
using Quartz;

namespace ProjectName.Workers.Jobs;

[DisallowConcurrentExecution]
public class ExampleJob: IJob
{
    private readonly ILogger<ExampleJob> _logger;
    private readonly SendEmailToOpenOrdersUseCase _useCase;
    public ExampleJob(ILogger<ExampleJob> logger, SendEmailToOpenOrdersUseCase useCase)
    {
        _logger = logger;
        _useCase = useCase;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("{job} started at: {time}", GetType().Name, DateTimeOffset.Now);
        await _useCase.ExecuteAsync();
        _logger.LogInformation("{job} finished at: {time}", GetType().Name, DateTimeOffset.Now);
    }
}


public class ExampleJobConfiguration
{
    public const string SectionName = "ExampleJobConfiguration";
    public string? CronExpression { get; set; } 
}


