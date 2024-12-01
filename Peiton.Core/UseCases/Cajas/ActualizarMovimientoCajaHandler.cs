using AutoMapper;
using Peiton.Contracts.Caja;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class ActualizarMovimientoCajaHandler(IMapper mapper, ICajaRepository cajaRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarMovimientoCajaRequest request)
    {
        var movimiento = await cajaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Movimiento no encontrado");
        if (!movimiento.Pendiente) throw new UnauthorizedAccessException("El movimiento no se puede actualizar");
        mapper.Map(request, movimiento);

        await unitOfWork.SaveChangesAsync();
    }
}