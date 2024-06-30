using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.NotasSimples;

[Injectable]
public class NotasSimplesHandler(INotaSimpleRepository notaSimpleRepository)
{
    public async Task<PaginatedData<NotaSimple>> HandleAsync(NotasSimplesFilter filter, Pagination pagination)
    {
        var items = await notaSimpleRepository.ObtenerNotasSimplesAsync(pagination.Page, pagination.Total, filter);
        var total = await notaSimpleRepository.ContarNotasSimplesAsync(filter);

        return new PaginatedData<NotaSimple>()
        {
            Items = items,
            Total = total
        };
    }

}
