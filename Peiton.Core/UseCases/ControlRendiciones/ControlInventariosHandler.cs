using Peiton.Contracts.ControlRendiciones;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlRendiciones;

[Injectable]
public class ControlRendicionesHandler(IControlRendicionRepository controlRendicionRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<ControlRendicion[]> HandleAsync(int tuteladoId)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return await controlRendicionRepository.ObtenerControlRendicionesAsync(tuteladoId);
    }
}