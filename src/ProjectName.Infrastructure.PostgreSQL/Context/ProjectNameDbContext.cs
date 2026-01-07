using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Enums;
using ProjectName.Infrastructure.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.PostgreSQL.Context;

public class ProjectNameDbContext:DbContext
{
    public ProjectNameDbContext(DbContextOptions<ProjectNameDbContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ProjectNameDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<OrderEntity> Orders { get; set; }
}
