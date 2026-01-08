using ProjectName.Application;
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
