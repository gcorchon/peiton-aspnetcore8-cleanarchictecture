using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Grupos;
using Peiton.Core;
using Peiton.Core.UseCases.Grupos;


namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GruposController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> UsuariosAsync(GruposHandler handler)
    {
        var data = await handler.HandleAsync();
        var vm = mapper.Map<IEnumerable<GrupoConUsuaios>>(data);
        return Ok(vm);
    }




}
