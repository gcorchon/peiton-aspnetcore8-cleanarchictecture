using AutoMapper;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tasaciones;

[Injectable]
public class CrearTasacionHandler(IInmuebleRepository inmuebleRepository, IMapper mapper, IIdentityService identityService, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, CrearInmuebleTasacionRequest request)
    {
        var inmueble = await inmuebleRepository.GetByIdAsync(id);

        if (inmueble == null) throw new EntityNotFoundException("Inmueble no encontrado");

        var tasacion = new InmuebleTasacion();
        mapper.Map(request, tasacion);

        tasacion.Autorizado = false;
        tasacion.Presentado = false;
        tasacion.Firme = false;
        tasacion.Fecha = DateTime.Now;
        tasacion.UsuarioId = identityService.GetUserId();

        inmueble.InmueblesTasaciones.Add(tasacion);

        await unitOfWork.SaveChangesAsync();
    }

}
