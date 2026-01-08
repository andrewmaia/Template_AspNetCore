using Microsoft.EntityFrameworkCore;
using ProjectName.Application.Interfaces;

namespace ProjectName.Tests.Integration.Application.Fixtures;
public class UnitOfWorkInMemory : IUnitOfWork
{
    private readonly DbContext _context;
    public UnitOfWorkInMemory(DbContext context) => _context = context;
    public Task CommitAsync() => _context.SaveChangesAsync();
}
