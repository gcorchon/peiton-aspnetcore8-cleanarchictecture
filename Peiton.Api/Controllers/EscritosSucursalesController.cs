using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.EscritosSucursales;
using Peiton.Core.UseCases.EscritosSucursales;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/escritos-sucursales")]
public class EscritosSucursalesController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> EscritosSucursalesAsync([FromQuery][Required] int tuteladoId, EscritosSucursalesHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<EscritoSucursalListItem>>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> GuardarEscritosSucursalesAsync([FromQuery][Required] int tuteladoId, [FromBody] GuardarEscritoSucursalRequest[] request, GuardarEscritosSucursalesHandler handler)
    {
        await handler.HandleAsync(tuteladoId, request);
        return Accepted();
    }

    [HttpPost("escrito")]
    public async Task<IActionResult> GenerarEscritoSucursalAsync([FromQuery][Required] int tuteladoId, [FromBody] GenerarEscritoSucursalRequest request, GenerarEscritoSucursalHandler handler)
    {
        var file = await handler.HandleAsync(tuteladoId, request);
        return File(file.Data, file.MimeType, file.FileName);
    }
}