using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Common;
using Peiton.Contracts.GestoresAdministrativos;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Common;
using Peiton.Core.UseCases.GestionesAdministrativas;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize()]
[Route("api/gestoresadministrativos")]
public class GestoresAdministrativosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaGestoresAdministrativos)]
    public async Task<IActionResult> GestionesAdministrativasAsync([FromQuery] GestionesAdministrativasFilter filter, [FromQuery] Pagination pagination, GestionesAdministrativasHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<GestionAdministrativaListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaGestoresAdministrativos)]
    public async Task<IActionResult> GestionAdministrativaAsync(int id, EntityHandler<GestionAdministrativa> handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<GestionAdministrativaViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    [PeitonAuthorization(PeitonPermission.GestionMasivaGestoresAdministrativos)]
    public async Task<IActionResult> ActualizarGestionAdministrativaAsync(int id, ActualizarGestionAdministrativaRequest request, ActualizarGestionAdministrativaHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }

    [HttpGet("tipos")]
    public async Task<IActionResult> GestionAdministrativaTiposAsync(ObtenerGestionAdministrativaTiposHandler handler)
    {
        var data = await handler.HandleAsync();
        var vm = mapper.Map<IEnumerable<ListItem>>(data);
        return Ok(vm);
    }


    //El método de crear debería de estar dentro del controlador del tutelado.

}
