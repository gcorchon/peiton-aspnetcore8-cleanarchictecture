using Peiton.Contracts.Common;
using Peiton.Contracts.Visitas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Visitas;

[Injectable]
public class ObtenerVisitantesHandler(IRegistroEntradaVisitanteRepository registroEntradaVisitanteRepository)
{
    public async Task<Visitante[]> HandleAsync(string query)
    {
        return await registroEntradaVisitanteRepository.ObtenerVisitantesAsync(query);
    }

}
