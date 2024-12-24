using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.RendicionesAnuales;
using Peiton.Core.UseCases.RendicionesAnuales;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RendicionesController : ControllerBase
{
    [HttpPost()]
    public async Task<IActionResult> CrearRendicionAsync(GenerarRendicionAnualRequest request, GenerarRendicionAnualHandler handler)
    {
        var archivo = await handler.HandleAsync(request);
        return File(archivo.Data, archivo.MimeType, archivo.FileName);        
    }
}