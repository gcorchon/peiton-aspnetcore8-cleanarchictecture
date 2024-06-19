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
using Peiton.Core.UseCases.GestionMasiva;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[Route("api/[controller]")]
public class AvisosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Avisos([FromQuery] InmuebleAvisosFilter filter, [FromQuery] Pagination pagination, AvisosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<InmuebleAvisoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Aviso(int id, EntityHandler<InmuebleAviso> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<InmuebleAvisoViewModel>(data);
        return Ok(vm);
    }

    
}