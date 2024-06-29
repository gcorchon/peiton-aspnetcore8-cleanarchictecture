using AutoMapper;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class ActualizarInmuebleAvisoHandler(IInmuebleAvisoRepository inmuebleAvisoRepository, IMapper mapper, IUnityOfWork unityOfWork)
{
    public async Task HandleAsync(int id, GuardarInmuebleAvisoRequest request)
    {
        var inmuebleAviso = await inmuebleAvisoRepository.GetByIdAsync(id);
        if (inmuebleAviso == null) throw new NotFoundException();

        if (inmuebleAviso.Resuelto) throw new ArgumentException("El aviso ya se encuentra resuelto");

        mapper.Map(request, inmuebleAviso);

        inmuebleAviso.InmuebleAvisosCostes.Merge(request.Costes, e => e.CosteId, c => c.CosteId, (entity, item, index, isNew) =>
        {
            entity.EmpresaId = item.EmpresaId;
            entity.Importe = item.Importe;
            entity.Orden = ++index;
            if (isNew) {
                entity.CosteId = Guid.NewGuid().ToString();
            }
        });

        await unityOfWork.SaveChangesAsync();
    }

}
