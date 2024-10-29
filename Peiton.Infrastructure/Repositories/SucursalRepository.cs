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
		return query;
	}
}
