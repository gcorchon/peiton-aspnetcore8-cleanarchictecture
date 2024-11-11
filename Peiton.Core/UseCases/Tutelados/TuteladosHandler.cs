using Peiton.Contracts.Common;
using Peiton.Contracts.Tutelados;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tutelados;

[Injectable]
public class TuteladosHandler(ITuteladoRepository tutaladoRepository)
{
    public async Task<PaginatedData<Tutelado>> HandleAsync(TuteladosFilter filter, Pagination pagination)
    {
        var items = await tutaladoRepository.ObtenerTuteladosAsync(pagination.Page, pagination.Total, filter);
        var total = await tutaladoRepository.ContarTuteladosAsync(filter);

        return new PaginatedData<Tutelado>()
        {
            Items = items,
            Total = total
        };
    }
}