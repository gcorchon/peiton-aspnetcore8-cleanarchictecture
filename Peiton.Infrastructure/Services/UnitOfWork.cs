using Peiton.Core;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IUnitOfWork))]
public class UnitOfWork : IUnitOfWork
{
    private readonly PeitonDbContext dbContext;

    public UnitOfWork(PeitonDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync()
    {
        return this.dbContext.SaveChangesAsync();
    }

    public void Clear()
    {
        this.dbContext.ChangeTracker.Clear();
    }
}
