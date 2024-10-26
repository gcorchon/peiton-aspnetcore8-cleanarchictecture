using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AnosPresupuestarios;

[Injectable]
public class AnoPresupuestarioDeleteHandler(IAnoPresupuestarioRepository anoPresupuestarioRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var anoPresupuestario = await anoPresupuestarioRepository.GetByIdAsync(id);
        if (anoPresupuestario == null) throw new EntityNotFoundException($"No existe el año presupuestario con Id {id}");

        anoPresupuestarioRepository.Remove(anoPresupuestario);

        await unitOfWork.SaveChangesAsync();
    }
}