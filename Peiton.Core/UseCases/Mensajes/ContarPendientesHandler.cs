using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Mensajes;

[Injectable]
public class ContarPendientesHandler(IMensajeRepository mensajeRepository)
{
    public async Task<int> HandleAsync()
    {
        var total = await mensajeRepository.ContarMensajesSinLeerAsync();

        return total;
    }
}