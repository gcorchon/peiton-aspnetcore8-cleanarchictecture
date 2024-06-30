using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.AvisosTributarios;
using Peiton.Contracts.Common;
using Peiton.Contracts.Inmuebles;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.InmuebleAutorizaciones;
using Peiton.Core.UseCases.InmuebleSolicitudesAlquilerVenta;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[Route("api/[controller]")]
public class SolicitudesAlquilerVentaController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> SolicitudesAlquilerVenta([FromQuery] InmuebleSolicitudesAlquilerVentaFilter filter, [FromQuery] Pagination pagination, SolicitudesAlquilerVentaHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<InmuebleSolicitudAlquilerVentaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> SolicitudAlquilerVenta(int id, EntityHandler<InmuebleSolicitudAlquilerVenta> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<InmuebleSolicitudAlquilerVentaViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarSolicitudAlquilerVenta(int id, ActualizarInmuebleSolicitudAlquilerVentaRequest request, ActualizarEntityHandler<InmuebleSolicitudAlquilerVenta> handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

}