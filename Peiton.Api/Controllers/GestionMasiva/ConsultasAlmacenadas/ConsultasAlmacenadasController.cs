using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.Consultas;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.ConsultasAlmacenadas;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[PeitonAuthorization(PeitonPermission.GestionMasivaConsultasAlmacenadas)]
[Route("api/consultas")]
public class ConsultasAlmacenadasController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> ConsultasAlmacenadasAsync([FromQuery] ConsultasFilter filter, ConsultasAlmacenadasHandler handler)
    {
        var data = await handler.HandleAsync(filter);
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ConsultaAlmacenadaAsync(int id, EntityHandler<ConsultaAlmacenada> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<ConsultaViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarConsultaAlmacenadaAsync(int id, ActualizarConsultaRequest request, ActualizarConsultaAlmacenadaHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarConsultaAlmacenadaAsync(int id, DeleteEntityHandler<ConsultaAlmacenada> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("{id:int}/query")]
    public async Task<IActionResult> QueryConsultaAlmacenadaAsync(int id, EntityHandler<ConsultaAlmacenada> handler)
    {
        var data = await handler.HandleAsync(id);
        return Ok(data.Query);
    }

    [HttpPatch("{id:int}/query")]
    public async Task<IActionResult> ActualizarQueryConsultaAlmacenadaAsync(int id, [FromBody] string query, ActualizarQueryConsultaAlmacenadaHandler handler)
    {
        await handler.HandleAsync(id, query);
        return Ok();
    }

    [HttpPost("{id:int}/execute")]
    public async Task<IActionResult> EjecutarConsultaAlmacenadaAsync(int id, [FromBody] IEnumerable<ParametroConsulta> parametros, EjecutarConsultaAlmacenadaHandler handler)
    {
        var data = await handler.HandleAsync(id, parametros);
        return Ok(data);
    }

    [HttpGet("{id:int}/params")]
    public async Task<IActionResult> ObtenerParametrosConsultaAlmacenadaAsync(int id, ObtenerParametrosConsultaHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return Ok(data);
    }

    [HttpPost("sql")]
    public async Task<IActionResult> EjecutarSqlAsync([FromBody] EjecutarSQLRequest request, EjecutarSQLHandler handler)
    {
        var data = await handler.HandleAsync(request);
        return Ok(data);
    }

    [HttpPost("sql/params")]
    public async Task<IActionResult> ObtenerParametrosSQLAsync([FromBody] string query, ObtenerParametrosSQLHandler handler)
    {
        var data = await handler.HandleAsync(query);
        return Ok(data);
    }


}
