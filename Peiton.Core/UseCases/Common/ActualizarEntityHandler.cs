using AutoMapper;
using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Common;

[Injectable]
public class ActualizarEntityHandler<T>(IMapper mapper, IEntityService entityService, IUnityOfWork unityOfWork) where T : class
{
    public async Task HandleAsync<U>(int id, U data)
    {
        var entity = await entityService.GetEntityAsync<T>(id);
        if (entity == null) throw new EntityNotFoundException($"{typeof(T).Name} Id {id} not found");
        
        mapper.Map(data, entity);

        await unityOfWork.SaveChangesAsync();
    }
}