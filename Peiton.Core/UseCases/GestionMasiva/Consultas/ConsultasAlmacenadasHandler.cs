using Peiton.Contracts.Consultas;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva.Consultas;

[Injectable]
public class ConsultasAlmacenadasHandler(IConsultaAlmacenadaRepository consultaAlmacenadaRepository, IIdentityService identityService)
{
    public async Task<List<ConsultaListItem>> HandleAsync(ConsultasFilter filter)
    {
        return await consultaAlmacenadaRepository.ObtenerConsultas(identityService.GetUserId()!.Value, filter);
    }

}