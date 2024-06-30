using AutoMapper;
using Peiton.Contracts.AvisosTributarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.AvisosTributarios;

[Injectable]
public class GuardarAvisoTributarioHandler(IMapper mapper, IAvisoTributarioRepository avisoTributarioRepository, IUnityOfWork unityOfWork, IIdentityService identityService)
{
    public async Task HandleAsync(GuardarAvisoTributarioRequest request)
    {
        var avisoTributario = new AvisoTributario()
        {
            UsuarioId = identityService.GetUserId()!.Value,
            TuteladoId = request.TuteladoId,
            EnTramite = false,
            Resuelto = false,
            Fecha = DateTime.Now
        };

        mapper.Map(request, avisoTributario);

        await avisoTributarioRepository.AddAsync(avisoTributario);
        await unityOfWork.SaveChangesAsync();
    }

}
