using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.SueldosPensiones;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.SueldosPensiones;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/sueldos-pensiones")]
public class SueldosPensionesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> SueldosPensionesAsync([FromQuery][Required] int tuteladoId, SueldosPensionesHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<SueldoPensionListItem>>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearSueldoPensionAsync(CrearSueldoPensionRequest request, CrearSueldoPensionHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarSueldoPensionAsync(int id, ActualizarSueldoPensionRequest request, ActualizarSueldoPensionHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarSueldoPensionAsync(int id, BorrarSueldoPensionHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

}
