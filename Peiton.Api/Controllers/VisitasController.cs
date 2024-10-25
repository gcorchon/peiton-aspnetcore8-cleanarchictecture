using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Documentos;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.Documentos;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize()]
[PeitonAuthorization(PeitonPermission.InstitucionalVisitas)]
[Route("api/documentos")]
public class VisitasController : ControllerBase
{

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarRegistroEntradaAsync(int id, DeleteEntityHandler<RegistroEntrada> handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}