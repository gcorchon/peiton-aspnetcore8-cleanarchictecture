using Peiton.Contracts.Common;
using Peiton.Contracts.EmergenciasCentros;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.EmergenciasCentros;

[Injectable]
public class EmergenciasCentrosHandler(IEmergenciaCentroRepository emergenciaCentroRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<EmergenciaCentro>> HandleAsync(int tuteladoId, EmergenciasCentrosFilter filter, Pagination pagination)
    {
        if(!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        var items = await emergenciaCentroRepository.ObtenerEmergenciasCentrosAsync(pagination.Page, pagination.Total, tuteladoId, filter);
        var total = await emergenciaCentroRepository.ContarEmergenciasCentrosAsync(tuteladoId, filter);

        return new PaginatedData<EmergenciaCentro>()
        {
            Items = items,
            Total = total
        };
    }
}