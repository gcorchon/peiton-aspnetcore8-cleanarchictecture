using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.MensajesTuAppoyo;
using Peiton.Contracts.MensajesTuAppoyo;
using Peiton.Core.UseCases.Common;
using AutoMapper;
using Peiton.Core.Entities;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.ComunicacionesMensajesTuAppoyo)]
[Route("api/[controller]")]
public class MensajesTuAppoyoController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> MensajesTuAppoyoAsync([FromQuery] MensajesTuAppoyoFilter filter, [FromQuery] Pagination pagination, MensajesTuAppoyoHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        return this.PaginatedResult(data.Items, data.Total);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearMensajeTuAppoyoAsync(CrearMensajeRequest request, EnviarMensajeTuAppoyoHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerMensajeTuteladoAsync(int id, MensajeTuAppoyoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<MensajeTuAppoyoViewModel>(data);
        return Ok(vm);
    }

    [HttpGet("enviados")]
    public async Task<IActionResult> MensajesTuAppoyoEnviadosAsync([FromQuery] MensajesTuAppoyoEnviadosFilter filter, [FromQuery] Pagination pagination, MensajesTuAppoyoEnviadosHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        return this.PaginatedResult(data.Items, data.Total);
    }

    [HttpGet("total-pendientes")]
    public async Task<IActionResult> TotalPendientessAsync(TotalPendientesHandler handler)
    {
        var data = await handler.HandleAsync();
        return Ok(data);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarMensajeTuAppoyoAsync(int id, [FromQuery] string tipo, BorrarMensajeTuAppoyoHandler handler)
    {
        await handler.HandleAsync(id, tipo);
        return Accepted();
    }

    [HttpDelete]
    public async Task<IActionResult> EliminarMultipleAsync([FromBody] int[] messageIds, BorrarMensajesTuAppoyoHandler handler)
    {
        await handler.HandleAsync(messageIds, "recibido");
        return Accepted();
    }
}