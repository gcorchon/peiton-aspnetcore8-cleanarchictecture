using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.AnosPresupuestarios;

[Injectable]
public class AnoPresupuestarioDeleteHandler(IAnoPresupuestarioRepository anoPresupuestarioRepository, IUnityOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var anoPresupuestario = await anoPresupuestarioRepository.GetByIdAsync(id);
        if(anoPresupuestario == null) throw new NotFoundException();

        anoPresupuestarioRepository.Remove(anoPresupuestario);
        
        await unitOfWork.SaveChangesAsync();
    }
}