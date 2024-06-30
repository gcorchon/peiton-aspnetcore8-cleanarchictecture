using Peiton.Contracts.Vales;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.Vales;

[Injectable]
public class GuardarValeHandler(IValeRepository valeRepository, IUnityOfWork unityOfWork, IIdentityService identityService)
{
    public async Task HandleAsync(GuardarValeRequest request)
    {
        var vale = new Vale()
        {
            Importe = request.Importe,
            ObservacionesSolicitud = request.Observaciones,
            Archivos = request.Archivos.ToXDocument()!.ToString(),
            SolicitanteId = identityService.GetUserId(),
            FechaSolicitud = DateTime.Now.Date
        };

        valeRepository.Add(vale);
        await unityOfWork.SaveChangesAsync();
    }

}
