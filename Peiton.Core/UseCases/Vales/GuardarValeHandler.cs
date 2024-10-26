using Peiton.Contracts.Vales;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.Vales;

[Injectable]
public class GuardarValeHandler(IValeRepository valeRepository, IUnitOfWork unitOfWork, IIdentityService identityService)
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

        await valeRepository.AddAsync(vale);
        await unitOfWork.SaveChangesAsync();
    }

}
