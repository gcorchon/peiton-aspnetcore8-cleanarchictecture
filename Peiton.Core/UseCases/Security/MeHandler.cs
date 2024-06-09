using Peiton.Contracts.Security;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Security;

[Injectable]
public class MeHandler
{
    private readonly IUsuarioRepository usuarioRepository;
    private readonly IIdentityService identityService;
    public MeHandler(IUsuarioRepository usuarioRepository, IIdentityService identityService)
    {
        this.usuarioRepository = usuarioRepository;
        this.identityService = identityService;
    }

    public async Task<MeViewModel> HandleAsync()
    {
        int? usuarioId = identityService.GetUserId();
        if(usuarioId is null) throw new UnauthorizedAccessException();
        
        var user = await this.usuarioRepository.GetByIdAsync(usuarioId.Value);

        if (user == null) throw new UnauthorizedAccessException();

        var permisos = await this.usuarioRepository.GetPermissionsAsync(usuarioId.Value);
        return new MeViewModel() { Id = usuarioId.Value, Name = user!.NombreCompleto, Permissions = permisos };
    }
}