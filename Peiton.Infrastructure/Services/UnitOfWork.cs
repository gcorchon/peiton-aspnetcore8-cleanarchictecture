using Peiton.Core;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IUnityOfWork))]
public class UnitOfWork : IUnityOfWork
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
}
