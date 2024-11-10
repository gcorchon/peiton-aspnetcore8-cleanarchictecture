using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesTuAppoyo;

[Injectable]
public class MensajeTuAppoyoHandler(IMensajeTuteladoRepository mensajeTuteladoRepository)
{
    public async Task<MensajeTutelado> HandleAsync(int id)
    {
        var mensaje = await mensajeTuteladoRepository.GetByIdAsync(id);
        if (mensaje == null) throw new EntityNotFoundException("Mensaje no encontrado");
        await mensajeTuteladoRepository.MarcarComoLeidoAsync(id);
        return mensaje;
    }
}