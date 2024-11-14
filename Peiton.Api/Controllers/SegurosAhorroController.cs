using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.SegurosAhorro;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.SegurosAhorro;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/seguros-ahorro")]
public class SegurosAhorroController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> SegurosAhorroAsync([FromQuery][Required] int tuteladoId, EntityHandler<Tutelado> handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<SeguroAhorroListItem>>(data.SegurosAhorro);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearSeguroAhorroAsync(CrearSeguroAhorroRequest request, CrearSeguroAhorroHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarSeguroAhorroAsync(int id, ActualizarSeguroAhorroRequest request, ActualizarSeguroAhorroHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarSeguroAhorroAsync(int id, BorrarSeguroAhorroHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

}
