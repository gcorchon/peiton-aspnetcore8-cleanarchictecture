using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Salas;
using Peiton.Contracts.Salas;
using Peiton.Core;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;
using Peiton.Api.Extensions;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalasController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> SalasPaginadasAsync([FromQuery] Pagination pagination, [FromQuery] SalasFilter filter, SalasPaginadasHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<SalaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("todas")]
    [PeitonAuthorization(PeitonPermission.InstitucionalSalas)]
    public async Task<IActionResult> SalasAsync(SalasHandler handler)
    {
        var data = await handler.HandleAsync();
        var vm = mapper.Map<IEnumerable<ListItem>>(data);
        return Ok(vm);
    }

    [HttpPost("")]
    [PeitonAuthorization(PeitonPermission.AdministrarSalas)]
    public async Task<IActionResult> CrearSalaAsync(SalaViewModel request, CrearEntityHandler<Sala> handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    [PeitonAuthorization(PeitonPermission.AdministrarSalas)]
    public async Task<IActionResult> ActualizarSalaAsync(int id, SalaViewModel request, ActualizarEntityHandler<Sala> handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    [PeitonAuthorization(PeitonPermission.AdministrarSalas)]
    public async Task<IActionResult> BorrarSalaAsync(int id, SalaViewModel request, DeleteEntityHandler<Sala> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }


    [HttpGet("reservas")]
    [PeitonAuthorization(PeitonPermission.InstitucionalSalas)]
    public async Task<IActionResult> ReservasAsync([FromQuery] DateTime fecha, IIdentityService identity, ReservasHandler handler)
    {
        var data = await handler.HandleAsync(fecha);
        var vm = mapper.Map<IEnumerable<ReservaViewModel>>(data, opts => opts.Items.Add("UserId", identity.GetUserId()));
        return Ok(vm);
    }

    [HttpPost("reservas")]
    [PeitonAuthorization(PeitonPermission.InstitucionalSalas)]
    public async Task<IActionResult> ActualizarReservasAsync(GuardarReservasRequest request, ActualizarReservasHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }
}