using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.TuteladoObjetivos;
using Peiton.Core.UseCases.Objetivos;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ObjetivosController(IMapper mapper) : ControllerBase
{

    [HttpGet("{tipoObjetivoId:int}")]
    public async Task<IActionResult> ObjetivosAsync(int tipoObjetivoId, [FromQuery][Required] int tuteladoId, ObjetivosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, tipoObjetivoId);
        var vm = mapper.Map<IEnumerable<TuteladoObjetivoViewModel>>(data);
        return Ok(vm);
    }

    [HttpPost("{tipoObjetivoId:int}")]
    public async Task<IActionResult> GuardarObjetivosAsync(int tipoObjetivoId, [FromQuery][Required] int tuteladoId, [FromBody] GuardarObjetivosRequest[] request, GuardarObjetivosHandler handler)
    {
        await handler.HandleAsync(tuteladoId, tipoObjetivoId, request);
        return Accepted();
    }
}