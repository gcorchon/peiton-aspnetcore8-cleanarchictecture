using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlInventarios;

[Injectable]
public class BorrarControlInventarioHandler(IControlInventarioRepository controlInventarioRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var controlInventario = await controlInventarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Control de Inventario no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(controlInventario.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        controlInventarioRepository.Remove(controlInventario);
        await unitOfWork.SaveChangesAsync();
    }
}