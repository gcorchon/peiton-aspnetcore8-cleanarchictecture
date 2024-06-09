using Peiton.Core;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IEntityService))]
public class EntityService : IEntityService
{
    private readonly PeitonDbContext dbContext;

    public EntityService(PeitonDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public object? GetEntity(Type type, int id) { 
        return this.dbContext.Find(type, [id]);
    }

    public ValueTask<object?> GetEntityAsync(Type type, int id)
    {
        return this.dbContext.FindAsync(type, [id]);
    }

    public ValueTask<T?> GetEntityAsync<T>(int id) where T : class
    {
        return this.dbContext.FindAsync<T>([id]);
    }
}