using ProjectName.Api.Extensions;
using ProjectName.Application;
using  ProjectName.ExternalServices.ViaCEP;
using ProjectName.Infrastructure.PostgreSQL;
using ProjectName.Infrastructure.Services;
using ProjectName.Workers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPostgreSQL(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddDomainServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddQuartz(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddPostalCodeService(builder.Configuration);
builder.Services.AddApplicationInsights(builder.Configuration);
builder.Logging.AddApplicationInsights();

var app = builder.Build();


app.UseSwaggerDocumentation();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
