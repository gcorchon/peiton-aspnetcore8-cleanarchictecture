namespace Peiton.Core.Services;

public interface IEntityService
{
    object? GetEntity(Type type, int id);
    T? GetEntity<T>(int id) where T : class;
    Task<object?> GetEntityAsync(Type type, int id);
    Task<T?> GetEntityAsync<T>(int id) where T : class;
    void Remove<T>(T entity) where T : class;

    Task AddAsync<T>(T entity) where T : class;
}
