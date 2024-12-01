using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class BorrarMovimientoPendienteCajaTutelado(ITuteladoRepository tuteladoRepository, ICajaRepository cajaRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var movimiento = await cajaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Movimiento de caja no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(movimiento.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        if (!movimiento.Pendiente) throw new UnauthorizedAccessException("El movimiento no se puede borrar");
        cajaRepository.Remove(movimiento);
        await unitOfWork.SaveChangesAsync();
    }
}