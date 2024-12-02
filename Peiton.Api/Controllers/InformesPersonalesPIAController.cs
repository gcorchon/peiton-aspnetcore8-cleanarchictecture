using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.UseCases.InformesPersonalesPIA;
using Peiton.Contracts.InformesPersonalesPIA;

namespace Peiton.Api.Controllers;

[ApiController]

[Route("api/[controller]")]
public class InformesPersonalesPIAController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> InformesPersonalesPIAAsync([FromQuery][Required] int tuteladoId, [FromQuery] Pagination pagination, InformesPersonalesPIAHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, pagination);
        var vm = mapper.Map<IEnumerable<InformePersonalPIAListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerInformePersonalAsync(int id, InformePersonalPIAHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data.Data, data.MimeType, data.FileName);
    }

    [HttpPost()]
    public async Task<IActionResult> ValidarInformePersonalAsync([FromForm] ValidarInformePersonalPIARequest request, ValidarInformePersonalPIAHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }
}