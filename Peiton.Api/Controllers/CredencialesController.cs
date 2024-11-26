using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Credenciales;
using Peiton.Contracts.Common;
using Peiton.Core.UseCases.Credenciales;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CredencialesController(IMapper mapper) : ControllerBase
{

    [HttpGet()]
    public async Task<IActionResult> CredencialesAsync([FromQuery][Required] int tuteladoId, CredencialesHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<CredencialListItem>>(data);
        return Ok(vm);
    }

    [HttpGet("posicion-global")]
    public async Task<IActionResult> CredencialesPosicionGlobalAsync([FromQuery][Required] int tuteladoId, PosicionGlobalHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId);
        var vm = mapper.Map<IEnumerable<CredencialPosicionGlobal>>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarCredencialAsync(int id, ActualizarCredencialRequest request, ActualizarCredencialHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpPatch("{id:int}/resetear")]
    public async Task<IActionResult> ResetearCredencialAsync(int id, ResetearCredencialHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPost()]
    public async Task<IActionResult> CrearCredencialAsync(CrearCredencialRequest request, CrearCredencialHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarCredencialAsync(int id, BorrarCredencialHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("bloqueadas")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> CredencialesBloqueadasAsync([FromQuery] CredencialesBloqueadasFilter filter, [FromQuery] Pagination pagination, CredencialesBloqueadasHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<CredencialBloquedaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}/datos")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> CredencialAsync(int id, CredencialBloqueadaHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return Ok(data);
    }

    [HttpPatch("bloqueadas/{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> DesbloquearCrendencialAsync(int id, DesbloquearCredencialHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPatch("bloqueadas")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> DesbloquearCrendencialesAsync(DesbloquearCredencialesHandler handler)
    {
        await handler.HandleAsync();
        return Accepted();
    }

    [HttpGet("exportar-bloqueadas")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> ExportarAsync([FromQuery] CredencialesBloqueadasFilter filter, ExportarCredencialesBloqueadasHandler handler)
    {
        var data = await handler.HandleAsync(filter);
        return File(data, MimeTypeHelper.Excel, "credenciales-bloqueadas.xlsx");
    }

}