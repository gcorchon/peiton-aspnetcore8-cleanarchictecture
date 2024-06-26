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
    public async Task<IActionResult> ConsultasAlmacenadas([FromQuery] ConsultasFilter filter, ConsultasAlmacenadasHandler handler)
    {
        var data = await handler.HandleAsync(filter);
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ConsultaAlmacenada(int id, EntityHandler<ConsultaAlmacenada> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<ConsultaViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarConsultaAlmacenada(int id, ActualizarConsultaRequest request, ActualizarConsultaAlmacenadaHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarConsultaAlmacenada(int id, DeleteEntityHandler<ConsultaAlmacenada> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("{id:int}/query")]
    public async Task<IActionResult> QueryConsultaAlmacenada(int id, EntityHandler<ConsultaAlmacenada> handler)
    {
        var data = await handler.HandleAsync(id);
        return Ok(data.Query);
    }

    [HttpPatch("{id:int}/query")]
    public async Task<IActionResult> ActualizarQueryConsultaAlmacenada(int id, [FromBody] string query, ActualizarQueryConsultaAlmacenadaHandler handler)
    {
        await handler.HandleAsync(id, query);
        return Ok();
    }

    [HttpPost("{id:int}/execute")]
    public async Task<IActionResult> EjecutarConsultaAlmacenada(int id, [FromBody] IEnumerable<ParametroConsulta> parametros, EjecutarConsultaAlmacenadaHandler handler)
    {
        var data = await handler.HandleAsync(id, parametros);
        return Ok(data);
    }

    [HttpGet("{id:int}/params")]
    public async Task<IActionResult> ObtenerParametrosConsultaAlmacenada(int id, ObtenerParametrosConsultaHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return Ok(data);
    }

    [HttpPost("sql")]
    public async Task<IActionResult> EjecutarSql([FromBody] EjecutarSQLRequest request, EjecutarSQLHandler handler)
    {
        var data = await handler.HandleAsync(request);
        return Ok(data);
    }

    [HttpPost("sql/params")]
    public async Task<IActionResult> ObtenerParametrosSQL([FromBody] string query, ObtenerParametrosSQLHandler handler)
    {
        var data = await handler.HandleAsync(query);
        return Ok(data);
    }


}
