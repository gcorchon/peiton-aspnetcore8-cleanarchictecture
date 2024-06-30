using Peiton.Contracts.AnoPresupuestario;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AnosPresupuestarios;

[Injectable]
public class AnosPresupuestariosHandler(IAnoPresupuestarioRepository anoPresupuestarioRepository)
{

    public async Task<PaginatedData<AnoPresupuestario>> HandleAsync(AnoPresupuestarioFilter filter, Pagination pagination)
    {
        var anosPresupuestarios = await anoPresupuestarioRepository.ObtenerAnosPrespuestariosAsync(pagination.Page, pagination.Total, filter);
        var total = await anoPresupuestarioRepository.ContarAnosPrespuestariosAsync(filter);

        return new PaginatedData<AnoPresupuestario>()
        {
            Items = anosPresupuestarios,
            Total = total
        };
    }
}