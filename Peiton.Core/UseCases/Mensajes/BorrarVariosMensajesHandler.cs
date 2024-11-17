using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class BorrarVariosMensajesHandler(IMensajeRepository mensajeRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int[] ids)
    {
        foreach (var id in ids)
        {
            var mensaje = await mensajeRepository.GetByIdAsync(id);
            if (mensaje == null) throw new NotFoundException("Mensaje no encontrado");
            mensajeRepository.Remove(mensaje);
        }

        await unitOfWork.SaveChangesAsync();
    }
}