using Microsoft.AspNetCore.Mvc;
using Peiton.Core.UseCases.InmuebleAvisos;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentoDePagoController : ControllerBase
{
    [HttpGet("{costeId}")]
    public async Task<IActionResult> DocumentoDePagoAsync(string costeId, ObtenerDocumentoDePagoHandler handler)
    {
        var data = await handler.HandleAsync(costeId);
        return Ok(data);
    }
}