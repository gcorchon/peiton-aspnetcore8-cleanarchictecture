using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.VehiculosEntidad;
using Peiton.Core;
using Peiton.Core.UseCases.VehiculosEntidad;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.InstitucionalVehiculos)]
[Route("api/[controller]")]
public class VehiculosEntidadController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> VehiculosEntidadAsync(VehiculosEntidadHandler handler)
    {
        var data = await handler.HandleAsync();
        var viewModel = mapper.Map<IEnumerable<VehiculoEntidadViewModel>>(data);
        return Ok(viewModel);
    }

    [HttpGet("reservas")]
    public async Task<IActionResult> ReservasAsync([FromQuery] DateTime fecha, IIdentityService identity, VehiculosEntidadReservasHandler handler)
    {
        var data = await handler.HandleAsync(fecha);
        var viewModel = mapper.Map<IEnumerable<VehiculoEntidadReservaViewModel>>(data, opts => opts.Items.Add("UserId", identity.GetUserId()));
        return Ok(viewModel);
    }

    [HttpPost("reservas")]
    public async Task<IActionResult> GuardarReservasAsync(GuardarReservaRequest request, GuardarReservaHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }


}
