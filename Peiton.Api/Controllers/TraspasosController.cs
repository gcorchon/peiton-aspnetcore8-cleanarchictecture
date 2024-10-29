using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Traspasos;
using Peiton.Core.UseCases.Sucursales;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TraspasosController : ControllerBase
{
    [HttpPost("")]
    public async Task<IActionResult> TraspasarAsync(TraspasoRequest request, TraspasosHandler handler)
    {
        await handler.HandleAsync(request.OrigenId, request.DestinoId, request.Trabajador);
        return Accepted();
    }
}