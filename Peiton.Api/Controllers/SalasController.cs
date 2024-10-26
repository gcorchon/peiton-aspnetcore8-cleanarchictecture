using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Salas;
using Peiton.Contracts.Salas;
using Peiton.Core;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.InstitucionalSalas)]
[Route("api/[controller]")]
public class SalasController(IMapper mapper) : ControllerBase
{

    [HttpGet("")]
    public async Task<IActionResult> SalasAsync(SalasHandler handler)
    {
        var data = await handler.HandleAsync();
        var vm = mapper.Map<IEnumerable<ListItem>>(data);
        return Ok(vm);
    }

    [HttpGet("reservas")]
    public async Task<IActionResult> ReservasAsync([FromQuery] DateTime fecha, IIdentityService identity, ReservasHandler handler)
    {
        var data = await handler.HandleAsync(fecha);
        var vm = mapper.Map<IEnumerable<ReservaViewModel>>(data, opts => opts.Items.Add("UserId", identity.GetUserId()));
        return Ok(vm);
    }

    [HttpPost("reservas")]
    public async Task<IActionResult> ActualizarReservasAsync(GuardarReservasRequest request, ActualizarReservasHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }
}