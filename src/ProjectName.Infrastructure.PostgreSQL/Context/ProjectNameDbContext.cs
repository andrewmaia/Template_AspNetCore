using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Enums;
using ProjectName.Domain.Entities;

namespace ProjectName.Infrastructure.PostgreSQL.Context;

public class ProjectNameDbContext:DbContext
{
    public ProjectNameDbContext(DbContextOptions<ProjectNameDbContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ProjectNameDbContext).Assembly);

        modelBuilder.HasPostgresEnum<OrderStatus>();

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Order> Orders { get; set; }
}
