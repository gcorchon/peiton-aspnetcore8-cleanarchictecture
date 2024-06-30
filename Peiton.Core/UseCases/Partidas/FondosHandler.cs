using Peiton.Contracts.Asientos;
using Peiton.Contracts.Common;
using Peiton.Contracts.Enums;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Partidas;

[Injectable]
public class FondosHandler(IAsientoRepository asientoRepository)
{
    public async Task<PaginatedData<FondoListItem>> HandleAsync(FondosFilter filter, TipoFondo tipoFondo, Pagination pagination)
    {
        IEnumerable<CapituloPartidaFilter> partidaFilter = tipoFondo switch
        {
            TipoFondo.Total => [new CapituloPartidaFilter { Capitulo="8", Partida = "83192" },
                                new CapituloPartidaFilter { Capitulo="8", Partida = "83190" }
            ],
            TipoFondo.Tutela => [new CapituloPartidaFilter() { Capitulo = "8", Partida = "83190" }],
            TipoFondo.Bankia => [new CapituloPartidaFilter() { Capitulo = "8", Partida = "83192" }],
            _ => throw new NotImplementedException(),
        };

        var items = await asientoRepository.ObtenerFondoAsync(pagination.Page, pagination.Total, filter, partidaFilter);
        var total = await asientoRepository.ContarFondoAsync(filter, partidaFilter);
        var diferencia = await asientoRepository.ObtenerDiferenciaFondoAsync(filter, partidaFilter);

        return new PaginatedData<FondoListItem>()
        {
            Items = items,
            Total = total,
            Extra = new Dictionary<string, object> { { "Diferencia", diferencia } }
        };
    }

}
