using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Visitas;

[Injectable]
public class RegistrosEntradaSinSalidaHandler(IRegistroEntradaRepository registroEntradaRepository)
{
    public async Task<PaginatedData<RegistroEntrada>> HandleAsync(Pagination pagination)
    {
        var items = await registroEntradaRepository.ObtenerVisitasSinSalidaAsync(pagination.Page, pagination.Total);
        var total = await registroEntradaRepository.ContarVisitasSinSalidaAsync();

        return new PaginatedData<RegistroEntrada>()
        {
            Items = items,
            Total = total
        };

    }

}
