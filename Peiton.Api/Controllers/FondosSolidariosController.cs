using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using System.ComponentModel.DataAnnotations;
using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.UseCases.FondosSolidarios;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Common;
using Peiton.Core.Entities;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/fondos-solidarios")]
public class FondosSolidariosController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> FondosSolidariosAsync([FromQuery][Required] int tuteladoId, [FromQuery] Pagination pagination, FondosSolidariosHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, pagination);
        var vm = mapper.Map<IEnumerable<FondoSolidarioListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerFondoSolidarioAsync(int id, FondoSolidarioHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<FondoSolidarioViewModel>(data);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearFondoSolidarioAsync(CrearFondoSolidarioRequest request, CrearFondoSolidarioHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPost("archivo")]
    public async Task<IActionResult> GuardarArchivoFondoSolidarioAsync([FromForm] GuardarArchivoFondoSolidarioRequest request, GuardarArchivoFondoSolidarioHandler handler)
    {
        var fileName = await handler.HandleAsync(request);
        return Ok(fileName);
    }

    [HttpGet("{id:int}/archivo/{tipo:int}")]
    public async Task<IActionResult> DescargarArchivoFondoSolidarioAsync(int id, int tipo, DescargarArchivoFondoSolidarioHandler handler)
    {
        var data = await handler.HandleAsync(id, tipo);
        return File(data.Data, data.MimeType, data.FileName);
    }

    [HttpGet("{id:int}/archivos")]
    public async Task<IActionResult> DescargarArchivosFondoSolidarioAsync(int id, DescargarArchivosFondoSolidarioHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data.Data, data.MimeType, data.FileName);
    }

    [HttpGet("{id:int}/justificante")]
    public async Task<IActionResult> GenerarJustificanteFondoSolidarioAsync(int id, GenerarJustificanteFondoSolidarioHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data.Data, data.MimeType, data.FileName);
    }

    [HttpGet("{tuteladoId:int}/firma/{tipo}")]
    public async Task<IActionResult> GenerarDocumentoFirmaFondoSolidarioAsync(int tuteladoId, string tipo, GenerarDocumentoFirmaHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, tipo);
        return File(data.Data, data.MimeType, data.FileName);
    }


    [HttpGet("gestion-masiva")]
    public async Task<IActionResult> FondosSolidariosAsync([FromQuery] FondosSolidariosFilter filter, [FromQuery] Pagination pagination, FondosSolidariosMasivaHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<FondoSolidarioExtendidoListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("gestion-masiva/{id:int}")]
    public async Task<IActionResult> ObtenerFondoSolidarioAsync(int id, EntityHandler<FondoSolidario> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<FondoSolidarioExtendidoViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaFondoSolidario)]
    public async Task<IActionResult> ActualizarFondoSolidarioAsync(int id, ActualizarFondoSolidarioRequest request, ActualizarFondoSolidarioHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

}