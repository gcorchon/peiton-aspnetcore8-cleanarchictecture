using Peiton.Contracts.Consultas;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ConsultasAlmacenadas;

[Injectable]
public class ConsultasAlmacenadasHandler(IConsultaAlmacenadaRepository consultaAlmacenadaRepository, IIdentityService identityService)
{
    public Task<List<ConsultaListItem>> HandleAsync(ConsultasFilter filter)
    {
        return consultaAlmacenadaRepository.ObtenerConsultasAsync(identityService.GetUserId(), filter);
    }

}