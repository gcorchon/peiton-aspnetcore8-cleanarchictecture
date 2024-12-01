using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class MovimientoPendienteCajaTutelado(ITuteladoRepository tuteladoRepository, ICajaRepository cajaRepository)
{
    public async Task<Caja> HandleAsync(int id)
    {
        var movimiento = await cajaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Movimiento de caja no encontrado");
        if (!await tuteladoRepository.CanViewAsync(movimiento.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        if (!movimiento.Pendiente) throw new UnauthorizedAccessException("El movimiento no se puede consultar");
        return movimiento;
    }
}