namespace Peiton.Core.Services;

public interface IEntityService
{
    object? GetEntity(Type type, int id);
    ValueTask<object?> GetEntityAsync(Type type, int id);
    ValueTask<T?> GetEntityAsync<T>(int id) where T:class;
}
