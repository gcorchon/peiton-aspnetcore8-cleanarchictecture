using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Contracts.DatosEconomicosCajaFuerte;
using Peiton.Core.UseCases.DatosEconomicosCajaFuerte;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/tutelados/{id:int}/datos-economicos/caja-fuerte")]
public class DatosEconomicosCajaController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    [AuthorizeTuteladoView]
    public async Task<IActionResult> DatosEconomicosCajaAsync(int id, EntityHandler<Tutelado> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<DatosEconomicosCajaViewModel>(data.DatosEconomicosCaja);
        return Ok(vm);
    }

    [HttpPut()]
    [AuthorizeTuteladoModify]
    public async Task<IActionResult> ActualizarDatosEconomicosCajaAsync(int id, DatosEconomicosCajaViewModel request, ActualizarDatosEconomicosCajaHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }
}