using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Mensajes;
using Peiton.Core.UseCases.Mensajes;

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

    [HttpPost()]
    public async Task<IActionResult> EnviarMensajeAsync(EnviarMensajeRequest request, EnviarMensajeHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
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

    [HttpDelete()]
    public async Task<IActionResult> BorradoMultipleMensajesAsync([FromBody] int[] ids, BorrarVariosMensajesHandler handler)
    {
        await handler.HandleAsync(ids);
        return Accepted();
    }

    [HttpPatch("{id:int}/archivar")]
    public async Task<IActionResult> ArchivarMensajeAsync(int id, ArchivarMensajeHandler handler)
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


    [HttpGet("total-general")] //Whatappeiton + TuAppoyo
    public async Task<IActionResult> ContarTotalGeneralAsync(ContarPendientesGeneralHandler handler)
    {
        var total = await handler.HandleAsync();
        return Ok(total);
    }

    [HttpGet("total-pendientes")]
    public async Task<IActionResult> ContarTotalPendientesAsync(ContarPendientesHandler handler)
    {
        var total = await handler.HandleAsync();
        return Ok(total);
    }
}