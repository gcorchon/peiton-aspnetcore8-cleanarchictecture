using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Extensions;
using Peiton.Contracts.Common;
using Peiton.Contracts.Usuarios;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Usuarios;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> UsuariosAsync(UsuariosHandler handler)
    {
        var data = await handler.HandleAsync();
        var vm = mapper.Map<IEnumerable<UsuarioConGrupos>>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> UsuarioAsync(int id, EntityHandler<Usuario> handler)
    {
        var usuario = await handler.HandleAsync(id);
        var vm = mapper.Map<UsuarioViewModel>(usuario);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearUsuarioAsync(GuardarUsuarioRequest request, CrearUsuarioHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }


    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarUsuarioAsync(int id, GuardarUsuarioRequest request, ActualizarUsuarioHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarUsuarioAsync(int id, BorrarUsuarioHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("usuarios-y-grupos")]
    public async Task<IActionResult> UsuariosGruposAsync([FromQuery] string q, ObtenerUsuariosGruposHandler handler)
    {
        var data = await handler.HandleAsync(q);
        return Ok(data);
    }

    [HttpGet("bloqueados")]
    public async Task<IActionResult> UsuariosAsync([FromQuery] UsuariosBloqueadosFilter filter, [FromQuery] Pagination pagination, UsuariosBloqueadosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<UsuarioBloqueado>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpPatch("{id:int}/desbloquear")]
    public async Task<IActionResult> DesbloquearUsuarioAsync(int id, DesbloquearUsuarioHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}
