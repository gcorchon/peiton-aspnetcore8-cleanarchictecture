using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Common;

[Injectable]
public class EntityHandler<T>(IEntityService entityService) where T : class
{
    public async Task<T> HandleAsync(int id)
    {
        var entity = await entityService.GetEntityAsync<T>(id);
        if (entity == null) throw new EntityNotFoundException($"{typeof(T).Name} Id {id} not found");
        return entity;
    }
}