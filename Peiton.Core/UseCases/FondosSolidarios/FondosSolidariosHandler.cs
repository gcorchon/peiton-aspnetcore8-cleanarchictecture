using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class FondosSolidariosHandler(IFondoSolidarioRepository fondoSolidarioRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PaginatedData<FondoSolidario>> HandleAsync(int tuteladoId, Pagination pagination)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver los datos del tutelado");

        var items = await fondoSolidarioRepository.ObtenerFondosSolidariosAsync(pagination.Page, pagination.Total, tuteladoId);
        var total = await fondoSolidarioRepository.ContarFondosSolidariosAsync(tuteladoId);

        return new PaginatedData<FondoSolidario>()
        {
            Items = items,
            Total = total
        };
    }
}