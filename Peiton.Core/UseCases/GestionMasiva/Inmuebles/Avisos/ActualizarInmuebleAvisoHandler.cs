using AutoMapper;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
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

        int ordenCoste = 1;
        foreach (var coste in request.Costes)
        {
            if (coste.EmpresaId == null || coste.Importe == null) continue;

            if(coste.CosteId == null)
            {
                var costeEntity = new InmuebleAvisoCoste()
                {
                    EmpresaId = coste.EmpresaId.Value,
                    Importe = coste.Importe.Value,
                    Orden = ordenCoste++,
                    CosteId = Guid.NewGuid().ToString()
                };
                inmuebleAviso.InmuebleAvisosCostes.Add(costeEntity);
            }
            else 
            {
                var costeEntity = inmuebleAviso.InmuebleAvisosCostes.SingleOrDefault(ic => ic.CosteId == coste.CosteId);
                if (costeEntity == null) throw new ArgumentException("CosteId no válido");
                costeEntity.EmpresaId = coste.EmpresaId.Value;
                costeEntity.Importe = coste.Importe.Value;
                costeEntity.Orden = ordenCoste++;
            }
        }

        var costesPrevios = request.Costes.Where(c => c.CosteId != null).ToList();
        var costesAEliminar = inmuebleAviso.InmuebleAvisosCostes.Where(ic => !costesPrevios.Any(c => c.CosteId == ic.CosteId)).ToList();

        foreach (var coste in costesAEliminar)
        {
            inmuebleAviso.InmuebleAvisosCostes.Remove(coste);
        }

        await unityOfWork.SaveChangesAsync();
    }

}
