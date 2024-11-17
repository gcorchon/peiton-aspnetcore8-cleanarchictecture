using Peiton.Contracts.AnoPresupuestario;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AnosPresupuestarios;

[Injectable]
public class AnoPresupuestarioUpdateHandler(IEntityService entityService, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, AnoPrespuestarioUpdateRequest data)
    {
        var anoPresupuestario = await entityService.GetEntityAsync<AnoPresupuestario>(id);
        if (anoPresupuestario == null) throw new NotFoundException($"No existe el año presupuestario con Id {id}");

        anoPresupuestario.Descripcion = data.Descripcion;
        anoPresupuestario.FechaModificacion = DateTime.Today;
        await unitOfWork.SaveChangesAsync();
    }
}