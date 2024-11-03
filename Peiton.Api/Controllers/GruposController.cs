using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Grupos;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerGrupoAsync(int id, EntityHandler<Grupo> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<GrupoViewModel>(data);
        return Ok(vm);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarGrupoAsync(int id, DeleteEntityHandler<Grupo> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPost()]
    public async Task<IActionResult> CrearGrupoAsync(GuardarGrupoRequest request, CrearGrupoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarGrupoAsync(int id, GuardarGrupoRequest request, ActualizarGrupoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }
}
