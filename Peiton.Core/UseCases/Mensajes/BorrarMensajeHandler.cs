using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class BorrarMensajeHandler(IMensajeRepository mensajeRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var mensaje = await mensajeRepository.GetByIdAsync(id);
        if (mensaje == null) throw new NotFoundException("Mensaje no encontrado");
        mensajeRepository.Remove(mensaje);
        await unitOfWork.SaveChangesAsync();
    }
}