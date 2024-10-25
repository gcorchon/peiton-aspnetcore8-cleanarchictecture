using Peiton.Contracts.Common;
using Peiton.Contracts.GestoresAdministrativos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionesAdministrativas;

[Injectable]
public class GestionesAdministrativasHandler(IGestionAdministrativaRepository gestionAdministrativaRepository)
{
    public async Task<PaginatedData<GestionAdministrativa>> HandleAsync(GestionesAdministrativasFilter filter, Pagination pagination)
    {
        var items = await gestionAdministrativaRepository.ObtenerGestionesAdministrativasAsync(pagination.Page, pagination.Total, filter);
        var total = await gestionAdministrativaRepository.ContarGestionesAdministrativasAsync(filter);

        return new PaginatedData<GestionAdministrativa>()
        {
            Items = items,
            Total = total
        };
    }

}
