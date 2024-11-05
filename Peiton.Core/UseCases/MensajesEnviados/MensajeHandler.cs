using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesEnviados;

[Injectable]
public class MensajeHandler(IMensajeEnviadoRepository mensajeEnviadoRepository)
{
    public async Task<MensajeEnviado> HandleAsync(int id)
    {
        var mensaje = await mensajeEnviadoRepository.GetByIdAsync(id); //Ojo: método sobreescrito en el repositorio
        if (mensaje == null) throw new EntityNotFoundException("Mensaje no encontrado");
        return mensaje;
    }
}