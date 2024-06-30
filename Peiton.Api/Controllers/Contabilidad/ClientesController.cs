using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Api.Extensions;
using Peiton.Authorization;
using Peiton.Contracts.Clientes;
using Peiton.Contracts.Common;
using Peiton.Contracts.Vales;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Clientes;
using Peiton.Core.UseCases.Common;

namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.ContabilidadAdministrar)]
[Route("api/[controller]")]
public class ClientesController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Vales([FromQuery] ClientesFilter filter, [FromQuery] Pagination pagination, ClientesHandler handler)
    {
        var data = await handler.HandleAsync(filter, pagination);
        var vm = mapper.Map<IEnumerable<ClienteListItem>>(data.Items);
        return this.PaginatedResult(vm, data.Total);
    }

    [HttpPost("")]
    public async Task<IActionResult> GuardarCliente([FromBody] GuardarClienteRequest data, GuardarClienteHandler handler)
    {
        await handler.HandleAsync(data);
        return Accepted();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarCliente(int id, [FromBody] GuardarClienteRequest data, ActualizarClienteHandler handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarCliente(int id, BorrarClienteHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }


}