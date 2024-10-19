using Peiton.Contracts.Inmuebles;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.InmuebleAvisos;

[Injectable]
public class ObtenerDocumentoDePagoHandler(IInmuebleAvisoCosteRepository inmuebleAvisoCosteRepository)
{
    public async Task<DocumentoPago?> HandleAsync(string costeId)
    {
        var coste = await inmuebleAvisoCosteRepository.GetAsync(c => c.CosteId == costeId);
        if (coste?.DocumentoPago == null) throw new EntityNotFoundException();
        return coste.DocumentoPago.Deserialize<DocumentoPago>();
    }

}
