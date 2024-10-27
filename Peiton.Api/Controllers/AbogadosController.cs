using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Microsoft.AspNetCore.Authorization;
using Peiton.Core.UseCases.Abogados;

namespace Peiton.Api.Controllers;

[ApiController]
[Authorize()]
[Route("api/[controller]")]
public class AbogadosController(IMapper mapper) : ControllerBase
{
    [HttpGet("senalamientos")]
    public async Task<IActionResult> AbogadosSenalamientosAsync([FromQuery] string query, AbogadosSenalamientosHandler handler)
    {
        var data = await handler.HandleAsync(query);
        var vm = mapper.Map<IEnumerable<ListItem>>(data);
        return Ok(vm);
    }
}