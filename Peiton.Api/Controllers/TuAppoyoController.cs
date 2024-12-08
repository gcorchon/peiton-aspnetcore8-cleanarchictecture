using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.TuAppoyo;
using Peiton.Core.UseCases.TuAppoyo;

namespace Peiton.Api.Controllers;

[ApiController]

[Route("api/tu-appoyo")]
public class TuAppoyoController(IMapper mapper) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> ConfiguracionTuAppoyoAsync(int id, ConfiguracionTuAppoyoHandler handler)
    {
        var data = await handler.HandleAsync(id);
        var vm = mapper.Map<ConfiguracionViewModel>(data);
        return Ok(vm);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> GuardarConfiguracionTuAppoyoAsync(int id, [FromBody] ConfiguracionViewModel request, GuardarConfiguracionTuAppoyoHandler handler)
    {
        await handler.HandleAsync(id, request);
        return Accepted();
    }


}