using AutoMapper;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Common;

[Injectable]
public class CrearEntityHandler<T>(IMapper mapper, IEntityService entityService, IUnityOfWork unityOfWork) where T : class, new()
{
    public async Task HandleAsync<U>(U data)
    {
        var entity = mapper.Map(data, new T());
        await entityService.AddAsync(entity);
        await unityOfWork.SaveChangesAsync();
    }
}