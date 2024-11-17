using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class MensajeHandler(IMensajeRepository mensajeRepository, IUnitOfWork unitOfWork)
{
    public async Task<Mensaje> HandleAsync(int id)
    {
        var mensaje = await mensajeRepository.GetByIdAsync(id); //Ojo: método sobreescrito en el repositorio para que solo puedan leer los mensajes los dueños de los mensajes
        if (mensaje == null) throw new NotFoundException("Mensaje no encontrado");

        if (!mensaje.Leido)
        {
            mensaje.Leido = true;
            mensaje.FechaLectura = DateTime.Now;
            await unitOfWork.SaveChangesAsync();
        }
        return mensaje;
    }
}