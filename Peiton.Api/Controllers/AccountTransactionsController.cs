using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.AccountTransactions;
using Peiton.Core.UseCases.AccountTransactions;
using System.ComponentModel.DataAnnotations;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountTransactionsController(IMapper mapper) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> AccountTransactionsAsync([FromQuery][Required] int accountId, [FromQuery] AccountTransactionsFilter filter, [FromQuery] Pagination pagination, AccountTransactionsHandler handler)
    {
        var data = await handler.HandleAsync(accountId, filter, pagination);
        var vm = mapper.Map<IEnumerable<AccountTransactionListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpGet("export")]
    public async Task<IActionResult> ExportAccountTransactionsAsync([FromQuery][Required] int accountId, [FromQuery] AccountTransactionsFilter filter, ExportAccountTransactionsHandler handler)
    {
        var data = await handler.HandleAsync(accountId, filter);
        return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "movimientos.xlsx");
    }

    [HttpPatch()]
    public async Task<IActionResult> ActualizarAccountTransactionsAsync(int id, [FromBody] ActualizarAccountTransactionsRequest request, ActualizarAccountTransactionsHandler handler)
    {
        await handler.HandleAsync(request);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarAccountTransactionAsync(int id, [FromBody] int? categoriaId, ActualizarAccountTransactionHandler handler)
    {
        await handler.HandleAsync(id, categoriaId);
        return Accepted();
    }


}