using Peiton.Contracts.Inmuebles;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InmuebleAvisos;

[Injectable]
public class GuardarDocumentoDePagoHandler
{
    public Task HandleAsync(int id, GuardarInmuebleAvisoRequest request)
    {

        throw new NotImplementedException();
        //await unitOfWork.SaveChangesAsync();
    }

}
