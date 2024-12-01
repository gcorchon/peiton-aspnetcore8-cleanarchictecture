using AutoMapper;
using Peiton.Contracts.Caja;

using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class ActualizarMovimientoCajaTuteladoHandler(IMapper mapper, ICajaRepository cajaRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarMovimientoCajaTuteladoRequest request)
    {
        var movimiento = await cajaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Movimiento no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(movimiento.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        if (!movimiento.Pendiente) throw new UnauthorizedAccessException("El movimiento no se puede actualizar");
        mapper.Map(request, movimiento);

        await unitOfWork.SaveChangesAsync();
    }
}