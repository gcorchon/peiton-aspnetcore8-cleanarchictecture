using AutoMapper;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class EliminarMovimientoCajaHandler(IMapper mapper, ICajaRepository cajaRepository, ICajaIncidenciaRepository cajaIncidenciaRepository, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id)
    {
        var movimiento = await cajaRepository.GetByIdAsync(id);

        if (movimiento == null) throw new NotFoundException();

        if (movimiento.Pendiente) throw new ArgumentException("Sólo se pueden eliminar movimientos pagados");

        if (!movimiento.FechaPago.HasValue || movimiento.FechaPago.Value.Date != DateTime.Now.Date) throw new ArgumentException("Sólo se pueden eliminar movimientos pagados el día actual");

        var cajaIncidencia = mapper.Map(movimiento, new CajaIncidencia());

        cajaIncidenciaRepository.Add(cajaIncidencia);

        cajaIncidencia.RazonIncidenciaCajaId = 1;

        cajaRepository.Remove(movimiento);

        await unityOfWork.SaveChangesAsync();
    }

}
