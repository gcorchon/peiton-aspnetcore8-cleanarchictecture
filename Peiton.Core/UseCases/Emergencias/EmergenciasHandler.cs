using Peiton.Contracts.Common;
using Peiton.Contracts.Emergencias;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Emergencias;

[Injectable]
public class EmergenciasHandler(IEmergenciaRepository emergenciaRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<Emergencia>> HandleAsync(int tuteladoId, EmergenciasFilter filter, Pagination pagination)
    {
        if(!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var items = await emergenciaRepository.ObtenerEmergenciasAsync(pagination.Page, pagination.Total, tuteladoId, filter);
        var total = await emergenciaRepository.ContarEmergenciasAsync(tuteladoId, filter);

        return new PaginatedData<Emergencia>()
        {
            Items = items,
            Total = total
        };
    }
}