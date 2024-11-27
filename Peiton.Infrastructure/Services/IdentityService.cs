using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using Peiton.Contracts.Usuarios;
using Peiton.Core;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IIdentityService))]
public class IdentityService(ClaimsPrincipal claimsPrincipal, IDbService dbService) : IIdentityService
{
    private ImmutableSortedSet<int>? permisos = null;
    private Info? info = null;

    public int GetUserId()
    {
        var claim = claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Sid) ?? throw new UnauthorizedAccessException();
        return Convert.ToInt32(claim.Value);
    }

    public async Task<bool> HasPermissionAsync(int permissionId)
    {
        if (permisos == null)
        {
            var dbPerm = await dbService.QueryAsync<int>(@$"select UsuarioPermiso.Fk_Permiso as Value from UsuarioPermiso where Fk_Usuario=@usuarioId
                    union
                    select GrupoPermiso.Fk_Permiso from GrupoUsuario inner join GrupoPermiso 
                    on GrupoUsuario.Fk_Grupo = GrupoPermiso.Fk_Grupo
                    where GrupoUsuario.Fk_Usuario = @usuarioId", new { usuarioId = this.GetUserId() });
            this.permisos = dbPerm.ToImmutableSortedSet();
        }

        return this.permisos.Contains(permissionId);
    }

    public async Task<Info> GetUserProfileAsync()
    {
        if (info == null)
        {
            var data = await dbService.ExecuteScalarAsync<string>("select info from Usuario where Pk_Usuario=@usuarioId", new { usuarioId = this.GetUserId() });
            this.info = JsonConvert.DeserializeObject<Info>(data!)!;
        }
        return this.info;
    }

    public async Task<string> GetUserNameAsync()
    {
        return await dbService.ExecuteScalarAsync<string>("select NombreCompleto from Usuario where Pk_Usuario=@usuarioId", new { usuarioId = GetUserId() }) ?? throw new UnauthorizedAccessException("Usuario no logado");
    }
}
