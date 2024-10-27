using AutoMapper;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Sucesiones;

[Injectable]
public class CrearSucesionHandler(ISucesionRepository sucesionRepository, IMapper mapper, IIdentityService identityService, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearSucesionRequest request)
    {
        var sucesion = new Sucesion();
        mapper.Map(request, sucesion);

        sucesion.Fecha = DateTime.Now;
        sucesion.UsuarioId = identityService.GetUserId();

        sucesionRepository.Add(sucesion);
        await unitOfWork.SaveChangesAsync();
    }

}
