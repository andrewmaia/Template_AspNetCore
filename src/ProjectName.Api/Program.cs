using  ProjectName.ExternalServices.ViaCEP;
using ProjectName.Application;
using ProjectName.Infrastructure.PostgreSQL;
using ProjectName.Infrastructure.Services;
using ProjectName.Workers;
using ProjectName.Api.Extensions;


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

var app = builder.Build();


app.UseSwaggerDocumentation();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
