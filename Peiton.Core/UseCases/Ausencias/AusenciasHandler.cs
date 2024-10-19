using Peiton.Contracts.Ausencias;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Ausencias;

[Injectable]
public class AusenciasHandler(IAusenciaRepository ausenciaRepository)
{
    public async Task<PaginatedData<Ausencia>> HandleAsync(AusenciasFilter filter, Pagination pagination)
    {
        var items = await ausenciaRepository.ObtenerAusenciasAsync(pagination.Page, pagination.Total, filter);
        var total = await ausenciaRepository.ContarAusenciasAsync(filter);

        return new PaginatedData<Ausencia>()
        {
            Items = items,
            Total = total
        };
    }
}
