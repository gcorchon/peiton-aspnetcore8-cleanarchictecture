using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Directorio;
using Peiton.Core.UseCases.Directorio;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectorioController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> DirectorioAsync([FromQuery] DirectorioFilter filter, DirectorioHandler handler)
    {
        var data = await handler.HandleAsync(filter);
        var vm = mapper.Map<IEnumerable<DirectorioListItem>>(data);
        return Ok(vm);
    }
}