using Peiton.Contracts.CNAEs;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.CNAEs;

[Injectable]
public class ActualizarCNAEHandler(ICNAERepository cnaeRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(string cnae, ActualizarCNAERequest request)
    {
        var entity = await cnaeRepository.GetAsync(c => c.Cnae2009 == cnae);
        if (entity == null) { throw new EntityNotFoundException($"CNAE {cnae} no encontrado"); }
        
        entity.CategoriaId = request.CategoriaId;

        await unityOfWork.SaveChangesAsync();
    }

}
