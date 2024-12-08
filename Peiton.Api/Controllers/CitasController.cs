using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Core.UseCases.Citas;
using System.ComponentModel.DataAnnotations;
using Peiton.Contracts.Citas;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitasController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> CitasAsync([FromQuery][Required] int tuteladoId, CitasHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<CitaListItem>>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearCitaAsync(CrearCitaRequest request, CrearCitaHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarCitaAsync(int id, ActualizarCitaRequest request, ActualizarCitaHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarCitaAsync(int id, BorrarCitaHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}