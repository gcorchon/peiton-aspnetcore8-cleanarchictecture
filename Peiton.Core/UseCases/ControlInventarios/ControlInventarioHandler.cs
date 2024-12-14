using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlInventarios;

[Injectable]
public class ControlInventarioHandler(IControlInventarioRepository controlInventarioRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<ControlInventario> HandleAsync(int id)
    {
        var controlInventario = await controlInventarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Control de Inventario no encontrado");
        if (!await tuteladoRepository.CanViewAsync(controlInventario.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return controlInventario;
    }
}