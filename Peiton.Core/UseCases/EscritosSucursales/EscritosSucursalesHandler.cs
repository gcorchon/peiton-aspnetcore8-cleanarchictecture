using Peiton.Contracts.EscritosSucursales;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.EscritosSucursales;

[Injectable]
public class EscritosSucursalesHandler(IEscritoSucursalRepository escritoSucursalRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<IEnumerable<EscritoSucursalListItem>> HandleAsync(int tuteladoId)
    {
        if(!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return await escritoSucursalRepository.ObtenerSucursalesAsync(tuteladoId);
    }
}