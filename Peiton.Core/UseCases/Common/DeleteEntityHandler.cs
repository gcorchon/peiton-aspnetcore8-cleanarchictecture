using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Common;

[Injectable]
public class DeleteEntityHandler<T>(IEntityService entityService, IUnityOfWork unityOfWork) where T:class
{    
    public async Task HandleAsync(int id)
    {
        var entity = await entityService.GetEntityAsync<T>(id);
        if (entity == null) throw new NotFoundException();
        entityService.Remove(entity);
        await unityOfWork.SaveChangesAsync();
    }
}