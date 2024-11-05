using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesEnviados;

[Injectable]
public class BorrarMensajeHandler(IMensajeEnviadoRepository mensajeEnviadoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var mensaje = await mensajeEnviadoRepository.GetByIdAsync(id);
        if (mensaje == null) throw new EntityNotFoundException("Mensaje no encontrado");
        mensajeEnviadoRepository.Remove(mensaje);
        await unitOfWork.SaveChangesAsync();
    }
}