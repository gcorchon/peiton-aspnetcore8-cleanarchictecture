using Peiton.Contracts.Visitas;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.Visitas;

[Injectable]
public class ActualizarRegistroEntradaHandler(IRegistroEntradaRepository registroEntradaRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, RegistroEntradaViewModel request)
    {

        var registroEntrada = await registroEntradaRepository.GetByIdAsync(id);
        if (registroEntrada == null) throw new NotFoundException("El registro de entrada no existe");

        registroEntrada.Dni = request.Visitante.Dni;
        registroEntrada.Nombre = request.Visitante.Nombre;
        registroEntrada.Tutelado = request.Visitante.Tutelado;
        registroEntrada.Fecha = request.Fecha;
        registroEntrada.HoraEntrada = request.HoraEntrada;
        registroEntrada.HoraSalida = request.HoraSalida;
        registroEntrada.MotivoEntradaId = request.MotivoEntradaId;
        registroEntrada.Observaciones = request.Observaciones;
        registroEntrada.Personas = request.Visitadas.ToXDocument()!.ToString();

        await unitOfWork.SaveChangesAsync();
    }
}
