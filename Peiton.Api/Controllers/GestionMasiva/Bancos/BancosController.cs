using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Bancos;
using Peiton.Contracts.Common;
using Peiton.Core.UseCases.Credenciales;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[Route("api/[controller]")]
public class BancosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> CredencialesBloqueadasAsync([FromQuery] CredencialesBloqueadasFilter filter, [FromQuery] Pagination pagination, CredencialesBloqueadasHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<CredencialBloquedaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> CredencialBloqueadaAsync(int id, CredencialBloqueadaHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return Ok(data);
    }

    [HttpPatch("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> DesbloquearCrendencialAsync(int id, DesbloquearCredencialHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPatch("")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> DesbloquearCrendencialesAsync(DesbloquearCredencialesHandler handler)
    {
        await handler.HandleAsync();
        return Accepted();
    }

    [HttpGet("exportar")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaBancos)]
    public async Task<IActionResult> ExportarAsync([FromQuery] CredencialesBloqueadasFilter filter, ExportarCredencialesBloqueadasHandler handler)
    {
        var data = await handler.HandleAsync(filter);
        return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "credenciales-bloqueadas.xlsx");
    }

}