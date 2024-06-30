using Peiton.Contracts.Clientes;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Clientes;

[Injectable]
public class ClientesHandler(IClienteRepository clienteRepository)
{
    public async Task<PaginatedData<Cliente>> HandleAsync(ClientesFilter filter, Pagination pagination)
    {
        IEnumerable<Cliente> items = await clienteRepository.ObtenerClientesAsync(pagination.Page, pagination.Total, filter);
        int total = await clienteRepository.ContarClientesAsync(filter);

        return new PaginatedData<Cliente>()
        {
            Items = items,
            Total = total
        };
    }

}
