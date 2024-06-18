using Peiton.Contracts.AvisosTributarios;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class AvisosTributariosHandler(IAvisoTributarioRepository avisoTributarioRepository)
{
    public async Task<PaginatedData<AvisoTributario>> HandleAsync(AvisosTributariosFilter filter, Pagination pagination)
    {
        var items = await avisoTributarioRepository.ObtenerAvisosTributariosAsync(pagination.Page, pagination.Total, filter);
        var total = await avisoTributarioRepository.ContarAvisosTributariosAsync(filter);

        return new PaginatedData<AvisoTributario>()
        {
            Items = items,
            Total = total
        };
    }

}
