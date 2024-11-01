using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Tablas;
using Peiton.Core.Utils;
using System.Text.Json;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TablasController : ControllerBase
{

    [HttpGet("{tableName}/estructura")]
    public async Task<IActionResult> ObtenerEstructuraAsync(string tableName, EstructuraHandler handler)
    {
        var data = await handler.HandleAsync(tableName);
        return Ok(data);
    }

    [HttpGet("{tableName}")]
    public async Task<IActionResult> ObtenerDatosAsync(string tableName, [FromQuery] Pagination pagination, [FromQuery] DynamicFilter filter, SelectHandler handler)
    {
        var data = await handler.HandleAsync(tableName, pagination, filter);
        return this.PaginatedResult(data.Items, data.Total);
    }

    [HttpPost("{tableName}")]
    public async Task<IActionResult> CrearAsync(string tableName, [FromBody] JsonElement request, CreateHandler handler)
    {
        await handler.HandleAsync(tableName, request);
        return Accepted();
    }

    [HttpPatch("{tableName}")]
    public async Task<IActionResult> ActualizarAsync(string tableName, [FromBody] JsonElement request, UpdateHandler handler)
    {
        await handler.HandleAsync(tableName, request);
        return Accepted();
    }

    [HttpDelete("{tableName}")]
    public async Task<IActionResult> BorrarAsync(string tableName, [FromBody] JsonElement request, DeleteHandler handler)
    {
        await handler.HandleAsync(tableName, request);
        return Accepted();
    }
}