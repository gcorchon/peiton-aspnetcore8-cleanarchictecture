using Peiton.Contracts.Common;
using Peiton.Contracts.Visitas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Visitas;

[Injectable]
public class RegistrosEntradaHandler(IRegistroEntradaRepository registroEntradaRepository)
{
    public async Task<PaginatedData<RegistroEntrada>> HandleAsync(RegistroEntradaFilter filter, Pagination pagination)
    {
        var items = await registroEntradaRepository.ObtenerRegistrosEntradaAsync(pagination.Page, pagination.Total, filter);
        var total = await registroEntradaRepository.ContarRegistrosEntradaAsync(filter);

        return new PaginatedData<RegistroEntrada>()
        {
            Items = items,
            Total = total
        };
    }

}
