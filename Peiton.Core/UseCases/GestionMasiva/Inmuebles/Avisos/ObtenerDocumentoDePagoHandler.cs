using Peiton.Contracts.Inmuebles.DocumentosDePago;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class ObtenerDocumentoDePagoHandler(IInmuebleAvisoCosteRepository inmuebleAvisoCosteRepository)
{
    public async Task<DocumentoPago?> HandleAsync(string costeId)
    {
        var coste = await inmuebleAvisoCosteRepository.GetAsync(c => c.CosteId == costeId);
        if (coste?.DocumentoPago == null) throw new NotFoundException();
        return coste.DocumentoPago.Deserialize<DocumentoPago>();
    }

}
