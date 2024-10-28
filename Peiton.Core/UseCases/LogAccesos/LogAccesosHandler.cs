using Peiton.Contracts.Common;
using Peiton.Contracts.LogAccesos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.LogAccesos;

[Injectable]
public class LogAccesosHandler(ILogAccesoRepository logAccesoRepository)
{
    public async Task<PaginatedData<LogAcceso>> HandleAsync(LogAccesosFilter filter, Pagination pagination)
    {
        var items = await logAccesoRepository.ObtenerLogAccesosAsync(pagination.Page, pagination.Total, filter);
        var total = await logAccesoRepository.ContarLogAccesosAsync(filter);

        return new PaginatedData<LogAcceso>()
        {
            Items = items,
            Total = total
        };
    }

}
