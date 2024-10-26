using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Common;

[Injectable]
public class DeleteEntityHandler<T>(IEntityService entityService, IUnitOfWork unitOfWork) where T : class
{
    public async Task HandleAsync(int id)
    {
        var entity = await entityService.GetEntityAsync<T>(id);
        if (entity == null) throw new EntityNotFoundException($"{typeof(T).Name} Id {id} not found");
        entityService.Remove(entity);
        await unitOfWork.SaveChangesAsync();
    }
}