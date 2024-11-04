using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Mensajes;
using Peiton.Core.UseCases.Mensajes;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.ComunicacionesMensajes)]
[Route("api/[controller]")]
public class MensajesController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> MensajesAsync([FromQuery] MensajesFilter filter, [FromQuery] Pagination pagination, MensajesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<MensajeListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerMensajeAsync(int id, EntityHandler<Mensaje> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<MensajeViewModel>(data);
        return Ok(vm);
    }
}