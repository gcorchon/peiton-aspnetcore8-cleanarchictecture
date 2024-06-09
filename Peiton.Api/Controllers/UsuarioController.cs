using Microsoft.AspNetCore.Mvc;
using Peiton.Core;

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
}
