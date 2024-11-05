using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Mensajes;
using Peiton.Core.UseCases.MensajesEnviados;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.ComunicacionesMensajes)]
[Route("api/[controller]")]
public class MensajesEnviadosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> MensajesAsync([FromQuery] MensajesFilter filter, [FromQuery] Pagination pagination, MensajesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<MensajeEnviadoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerMensajeAsync(int id, MensajeHandler handler) //Hace falta un handler especial en lugar del genérico para comprobar que el usuario que lee el mensaje es el destinatario
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<MensajeViewModel>(data);
        return Ok(vm);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarMensajeAsync(int id, BorrarMensajeHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("{id:int}/exportar")]
    public async Task<IActionResult> ExportarMensajeAsync(int id, ExportarMensajeHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data, "application/pdf");
    }
}