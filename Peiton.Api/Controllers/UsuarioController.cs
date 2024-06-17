using Microsoft.AspNetCore.Mvc;
using Peiton.Core;
using Peiton.Core.UseCases.Usuarios;

namespace Peiton.Api;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    [Route("{id:int}")]
    public async Task<IActionResult> GetUserById(int id, GetUserByIdHandler handler){
        var usuario = await handler.HandleAsync(id);
        if(usuario is null) return NotFound();
        return Ok(usuario);
    }

    [Route("usuarios-y-grupos")]
    public async Task<IActionResult> UsuariosGrupos([FromQuery] string q, ObtenerUsuariosGruposHandler handler)
    {
        var data = await handler.HandleAsync(q);
        return Ok(data);
    }
}
