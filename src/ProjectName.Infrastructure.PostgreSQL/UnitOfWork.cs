using ProjectName.Application.Interfaces;
using ProjectName.Infrastructure.PostgreSQL.Context;


namespace ProjectName.Infrastructure.PostgreSQL;
public class UnitOfWork : IUnitOfWork
{
    private readonly ProjectNameDbContext _db;

    public UnitOfWork(ProjectNameDbContext db)
    {
        _db = db;
    }

    public Task CommitAsync()
    {
        return _db.SaveChangesAsync();
    }
}
