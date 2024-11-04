using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class MensajeHandler(IMensajeRepository mensajeRepository)
{
    public async Task<Mensaje> HandleAsync(int id)
    {
        var mensaje = await mensajeRepository.GetByIdAsync(id); //Ojo: método sobreescrito en el repositorio
        if (mensaje == null) throw new EntityNotFoundException("Mensaje no encontrado");
        return mensaje;
    }
}