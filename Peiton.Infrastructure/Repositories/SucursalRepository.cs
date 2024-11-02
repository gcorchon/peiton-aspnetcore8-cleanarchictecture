using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Sucursales;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISucursalRepository))]
public class SucursalRepository : RepositoryBase<Sucursal>, ISucursalRepository
{
	public SucursalRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarSucursalesAsync(SucursalesFilter filter)
	{
		return ApplyFilters(DbSet, filter).CountAsync();
	}

	public Task<Sucursal[]> ObtenerSucursalesAsync(int page, int total, SucursalesFilter filter)
	{
		return ApplyFilters(DbSet, filter)
				.OrderBy(s => s.EntidadFinancieraId)
				.Skip((page - 1) * total)
				.Take(total)
				.AsNoTracking()
				.ToArrayAsync();
	}

	private IQueryable<Sucursal> ApplyFilters(IQueryable<Sucursal> query, SucursalesFilter filter)
	{
		if (filter == null) return query;

		if (filter.EntidadFinancieraId.HasValue)
		{
			query = query.Where(s => s.EntidadFinancieraId == filter.EntidadFinancieraId.Value);
		}

		if (!string.IsNullOrWhiteSpace(filter.Ciudad))
		{
			query = query.Where(s => s.Ciudad == filter.Ciudad);
		}

		if (!string.IsNullOrWhiteSpace(filter.Provincia))
		{
			query = query.Where(s => s.Provincia == filter.Provincia);
		}

		if (!string.IsNullOrWhiteSpace(filter.Direccion))
		{
			query = query.Where(s => s.Direccion == filter.Direccion);
		}

		if (!string.IsNullOrWhiteSpace(filter.Telefono))
		{
			query = query.Where(s => s.Telefono == filter.Telefono);
		}

		if (!string.IsNullOrWhiteSpace(filter.Numero))
		{
			query = query.Where(s => s.Numero == filter.Numero);
		}

		if (!string.IsNullOrWhiteSpace(filter.CodigoPostal))
		{
			query = query.Where(s => s.CodigoPostal == filter.CodigoPostal);
		}

		return query;
	}
}
