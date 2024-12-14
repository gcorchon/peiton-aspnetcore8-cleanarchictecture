using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.ControlCuentasGenerales;
using Peiton.Core.UseCases.ControlCuentasGenerales;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/control-cuentas-generales")]
public class ControlCuentasGeneralesController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> ControlCuentasGeneralesAsync([FromQuery][Required] int tuteladoId, ControlCuentasGeneralesHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<ControlCuentaGeneralListItem>>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerControlCuentaGeneralAsync(int id, ControlCuentaGeneralHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<ControlCuentaGeneralViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearControlCuentaGeneralAsync(CrearControlCuentaGeneralRequest request, CrearControlCuentaGeneralHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarControlCuentaGeneralAsync(int id, ActualizarControlCuentaGeneralRequest request, ActualizarControlCuentaGeneralHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarControlCuentaGeneralAsync(int id, BorrarControlCuentaGeneralHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}