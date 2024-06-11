using Peiton.Contracts.Clientes;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
	public interface IClienteRepository : IRepository<Cliente>
	{
		Task<int> ContarClientesAsync(ClientesFilter filter);
		Task<List<Cliente>> ObtenerClientesAsync(int page, int total, ClientesFilter filter);
	}
}