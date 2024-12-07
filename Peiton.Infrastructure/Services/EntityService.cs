using Peiton.Core;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IEntityService))]
public class EntityService(PeitonDbContext dbContext) : IEntityService
{


    public object? GetEntity(Type type, int id)
    {
        return dbContext.Find(type, [id]);
    }

    public Task<object?> GetEntityAsync(Type type, int id)
    {
        return dbContext.FindAsync(type, [id]).AsTask();
    }

    public T? GetEntity<T>(int id) where T : class
    {
        return dbContext.Find<T>([id]);
    }

    public Task<T?> GetEntityAsync<T>(int id) where T : class
    {
        return dbContext.FindAsync<T>([id]).AsTask();
    }

    public void Remove<T>(T entity) where T : class
    {
        dbContext.Remove<T>(entity);
    }

    public Task AddAsync<T>(T entity) where T : class
    {
        return dbContext.AddAsync<T>(entity).AsTask();
    }
}