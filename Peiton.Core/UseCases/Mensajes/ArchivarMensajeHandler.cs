using Peiton.Contracts.Mensajes;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class ArchivarMensajeHandler(IMensajeRepository mensajeRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var mensaje = await mensajeRepository.GetByIdAsync(id);
        if (mensaje == null) throw new EntityNotFoundException("Mensaje no encontrado");
        mensaje.Archivado = true;
        await unitOfWork.SaveChangesAsync();
    }
}