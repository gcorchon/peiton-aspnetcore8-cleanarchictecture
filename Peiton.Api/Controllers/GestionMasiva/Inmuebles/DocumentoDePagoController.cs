using Microsoft.AspNetCore.Mvc;
using Peiton.Core.UseCases.GestionMasiva;

namespace Peiton.Api.Controllers.GestionMasiva;

[ApiController]
[Route("api/[controller]")]
public class DocumentoDePagoController : ControllerBase
{
    [HttpGet("{costeId}")]
    public async Task<IActionResult> DocumentoDePago(string costeId, ObtenerDocumentoDePagoHandler handler)
    {
        var data = await handler.HandleAsync(costeId);
        return Ok(data);
    }
}