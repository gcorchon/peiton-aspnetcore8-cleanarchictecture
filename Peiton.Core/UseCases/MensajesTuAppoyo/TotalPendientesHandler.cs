using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.MensajesTuAppoyo;

[Injectable]
public class TotalPendientesHandler(IMensajeTuteladoRepository mensajeTuteladoRepository)
{
    public async Task<int> HandleAsync()
    {
        return await mensajeTuteladoRepository.ContarMensajesSinLeerAsync();
    }
}