
using Peiton.Contracts.AnoPresupuestario;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.AnosPresupuestarios;

[Injectable]
public class AnoPresupuestarioUpdateHandler(IEntityService entityService, IUnityOfWork unitOfWork)
{
    public async Task HandleAsync(int id, AnoPrespuestarioUpdateRequest data)
    {
        var anoPresupuestario = await entityService.GetEntityAsync<AnoPresupuestario>(id);
        if(anoPresupuestario == null) throw new  NotFoundException();

        anoPresupuestario.Descripcion = data.Descripcion;
        anoPresupuestario.FechaModificacion = DateTime.Today;
        await unitOfWork.SaveChangesAsync();
    }
}