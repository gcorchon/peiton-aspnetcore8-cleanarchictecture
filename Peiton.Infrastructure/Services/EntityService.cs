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

    public Task<object?> GetEntityAsync(Type type, int id)
    {
        return this.dbContext.FindAsync(type, [id]).AsTask();
    }

    public T? GetEntity<T>(int id) where T : class
    {
        return this.dbContext.Find<T>([id]);
    }

    public Task<T?> GetEntityAsync<T>(int id) where T : class
    {
        return this.dbContext.FindAsync<T>([id]).AsTask();
    }

    public void Remove<T>(T entity) where T : class
    {
        this.dbContext.Remove<T>(entity);
    }
}