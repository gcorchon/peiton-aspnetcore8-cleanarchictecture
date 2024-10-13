using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Extensions;
using Peiton.Contracts.Common;
using Peiton.Contracts.Companies;
using Peiton.Core.UseCases.Companys;

namespace Peiton.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> CompaniesAsync([FromQuery] BuscarCompaniesFilter filter, [FromQuery] Pagination pagination, CompaniesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var viewModel = mapper.Map<IEnumerable<CompanyViewModel>>(data.Items);
        return this.PaginatedResult(viewModel, data.Total);
    }
}

