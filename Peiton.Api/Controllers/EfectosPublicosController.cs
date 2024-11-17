using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.EfectosPublicos;
using Peiton.Core.UseCases.EfectosPublicos;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/efectos-publicos")]
public class EfectosPublicosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> EfectosPublicosAsync([FromQuery][Required] int tuteladoId, EfectosPublicosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<EfectoPublicoListItem>>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearEfectoPublicoAsync(CrearEfectoPublicoRequest request, CrearEfectoPublicoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarEfectoPublicoAsync(int id, ActualizarEfectoPublicoRequest request, ActualizarEfectoPublicoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarEfectoPublicoAsync(int id, BorrarEfectoPublicoHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

}
