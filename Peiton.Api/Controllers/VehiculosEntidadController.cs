using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.VehiculosEntidad;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.VehiculosEntidad;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[PeitonAuthorization(PeitonPermission.InstitucionalVehiculos)]
[Route("api/[controller]")]
public class VehiculosEntidadController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> VehiculosEntidadAsync(VehiculosEntidadHandler handler)
    {
        var data = await handler.HandleAsync();
        var viewModel = mapper.Map<IEnumerable<VehiculoEntidadViewModel>>(data);
        return Ok(viewModel);
    }

    [HttpGet("reservas")]
    public async Task<IActionResult> ReservasAsync([FromQuery] DateTime fecha, IIdentityService identity, VehiculosEntidadReservasHandler handler)
    {
        var data = await handler.HandleAsync(fecha);
        var viewModel = mapper.Map<IEnumerable<VehiculoEntidadReservaViewModel>>(data, opts => opts.Items.Add("UserId", identity.GetUserId()));
        return Ok(viewModel);
    }

    [HttpPost("reservas")]
    public async Task<IActionResult> GuardarReservasAsync(GuardarReservaRequest request, GuardarReservaHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    /*
    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerQuejaAsync(int id, EntityHandler<Queja> handler)
    {
        var entity = await handler.HandleAsync(id);
        var vm = mapper.Map<QuejaViewModel>(entity);
        return Ok(vm);
    }

    [HttpPost()]
    public async Task<IActionResult> CrearQuejaAsync(GuardarQuejaRequest data, CrearrQuejaHandler handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarQuejaAsync(int id, [FromBody] GuardarQuejaRequest data, ActualizarQuejaHandler handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    [PeitonAuthorization(PeitonPermission.InstitucionalVehiculosEntidadBorrar)]
    public async Task<IActionResult> BorrarQuejaAsync(int id, DeleteEntityHandler<Queja> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpPost("documentos")]
    public async Task<IActionResult> GuardarDocumentoAsync([FromForm] IFormFile file, GuardarDocumentoHandler handler)
    {
        var fileName = await handler.HandleAsync(file);
        return Ok(fileName);
    }

    [HttpGet("documentos")]
    public async Task<IActionResult> DescargarDocumentoAsync([FromQuery] string path)
    {
        var filePath = FilePathValidator.CombineSafe("App_Data/VehiculosEntidad", path);

        if (!System.IO.File.Exists(filePath)) return NotFound();

        var content = await System.IO.File.ReadAllBytesAsync(filePath);
        return File(content, MimeTypeHelper.GetMimeType(filePath), path.Substring(path.IndexOf("_") + 1));
    }
    */
}
