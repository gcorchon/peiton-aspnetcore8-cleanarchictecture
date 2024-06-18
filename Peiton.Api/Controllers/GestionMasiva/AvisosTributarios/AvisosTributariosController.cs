using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.AvisosTributarios;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.GestionMasiva;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[Route("api/[controller]")]
public class AvisosTributariosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaAvisosTributarios)]
    public async Task<IActionResult> AvisosTributarios([FromQuery] AvisosTributariosFilter filter, [FromQuery] Pagination pagination, AvisosTributariosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<AvisoTributarioListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaAvisosTributarios)]
    public async Task<IActionResult> AvisoTributario(int id, EntityHandler<AvisoTributario> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<AvisoTributarioViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaAvisosTributarios)]
    public async Task<IActionResult> ActualizarAvisoTributario(int id, ActualizarAvisoTributarioRequest request, ActualizarEntityHandler<AvisoTributario> handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpPatch("{id:int}/resolver")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaAvisosTributarios)]
    public async Task<IActionResult> ResolverAvisoTributario(int id, ActualizarAvisoTributarioRequest request, ResolverAvisoTributarioHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpPost("")]
    [PeitonAuthorization(PeitonPermission.GestionIndividualDatosEconomicosTributos)]
    public async Task<IActionResult> GuardarAvisoTributario(GuardarAvisoTributarioRequest request, GuardarAvisoTributarioHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }
}