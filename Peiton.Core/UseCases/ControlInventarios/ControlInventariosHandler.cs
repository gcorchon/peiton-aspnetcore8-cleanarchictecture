using Peiton.Contracts.ControlInventarios;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlInventarios;

[Injectable]
public class ControlInventariosHandler(IControlInventarioRepository controlInventarioRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<ControlInventario[]> HandleAsync(int tuteladoId)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return await controlInventarioRepository.ObtenerControlInventariosAsync(tuteladoId);
    }
}