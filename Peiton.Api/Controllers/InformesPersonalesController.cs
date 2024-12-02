using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.UseCases.InformesPersonales;
using Peiton.Contracts.InformesPersonales;

namespace Peiton.Api.Controllers;

[ApiController]

[Route("api/[controller]")]
public class InformesPersonalesController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> InformesPersonalesAsync([FromQuery][Required] int tuteladoId, [FromQuery] Pagination pagination, InformesPersonalesHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, pagination);
        var vm = mapper.Map<IEnumerable<InformePersonalListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerInformePersonalAsync(int id, InformePersonalHandler handler)
    {
        var data = await handler.HandleAsync(id);
        return File(data.Data, data.MimeType, data.FileName);
    }

    [HttpPost()]
    public async Task<IActionResult> ValidarInformePersonalAsync([FromForm] ValidarInformePersonalRequest request, ValidarInformePersonalHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }
}