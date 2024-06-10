
using AutoMapper;
using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Contabilidad.Asientos;

[Injectable]
public class AsientosHuerfanosHandler(IAsientoRepository asientoRepository)
{    
    public async Task<PaginatedData<Asiento>> HandleAsync(AsientosHuerfanosFilter filter, Pagination pagination)
    {
        var asientos = await asientoRepository.ObtenerAsientosHuerfanosAsync(pagination.Page, pagination.Total, filter);
        var total = await asientoRepository.ContarAsientosHuerfanosAsync(filter);

        return new PaginatedData<Asiento>() {
            Items = asientos,
            Total = total
        };
    }
}