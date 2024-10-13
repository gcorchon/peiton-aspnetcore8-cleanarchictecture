using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Clientes;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IClienteRepository))]
public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
{
	public ClienteRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarClientesAsync(ClientesFilter filter)
	{
		return ApplyFilters(DbSet, filter).CountAsync();
	}

	public Task<List<Cliente>> ObtenerClientesAsync(int page, int total, ClientesFilter filter)
	{
		return ApplyFilters(DbSet, filter)
				.OrderBy(c => c.Nombre)
				.Skip((page - 1) * total)
				.Take(total)
				.AsNoTracking()
				.ToListAsync();
	}

	private IQueryable<Cliente> ApplyFilters(IQueryable<Cliente> query, ClientesFilter filter)
	{
		query = query.Where(c => c.Activo);

		if (!string.IsNullOrWhiteSpace(filter.CIF))
		{
			query = query.Where(c => c.CIF != null && c.CIF.StartsWith(filter.CIF));
		}

		if (!string.IsNullOrWhiteSpace(filter.CodCliente))
		{
			query = query.Where(c => c.CodCliente.StartsWith(filter.CodCliente));
		}

		if (!string.IsNullOrWhiteSpace(filter.Nombre))
		{
			query = query.Where(c => c.Nombre.Contains(filter.Nombre));
		}

		return query;
	}
}
