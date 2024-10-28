using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Visitas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRegistroEntradaRepository))]
public class RegistroEntradaRepository : RepositoryBase<RegistroEntrada>, IRegistroEntradaRepository
{
	public RegistroEntradaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarRegistrosEntradaAsync(RegistroEntradaFilter filter)
	{
		IQueryable<RegistroEntrada> query = ApplyFilter(DbSet, filter);

		return query.CountAsync();
	}

	public Task<int> ContarVisitasSinSalidaAsync()
	{
		return DbSet.Where(r => r.HoraSalida == null)
					.CountAsync();
	}

	public Task<RegistroEntrada[]> ObtenerRegistrosEntradaAsync(int page, int total, RegistroEntradaFilter filter)
	{
		IQueryable<RegistroEntrada> query = ApplyFilter(DbSet, filter);

		return query.OrderByDescending(a => a.Id)
					.Skip((page - 1) * total)
					.Take(total)
					.AsNoTracking()
					.ToArrayAsync();
	}

	public Task<RegistroEntrada[]> ObtenerVisitasSinSalidaAsync(int page, int total)
	{
		return DbSet.Where(r => r.HoraSalida == null)
					.OrderByDescending(a => a.Id)
					.Skip((page - 1) * total)
					.Take(total)
					.AsNoTracking()
					.ToArrayAsync();
	}

	private IQueryable<RegistroEntrada> ApplyFilter(IQueryable<RegistroEntrada> query, RegistroEntradaFilter? filter)
	{
		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.Fecha))
		{
			query = query.Where(r => DbContext.DateAsString(r.Fecha).Contains(filter.Fecha));
		}

		if (!string.IsNullOrWhiteSpace(filter.HoraEntrada))
		{
			query = query.Where(r => r.HoraEntrada.StartsWith(filter.HoraEntrada));
		}

		if (!string.IsNullOrWhiteSpace(filter.HoraSalida))
		{
			query = query.Where(r => r.HoraSalida != null && r.HoraSalida.StartsWith(filter.HoraSalida));
		}

		if (!string.IsNullOrWhiteSpace(filter.Visitante))
		{
			query = query.Where(r => r.Nombre.Contains(filter.Visitante));
		}

		if (!string.IsNullOrWhiteSpace(filter.Visitado))
		{
			query = query.Where(r => DbContext.EsVisitado(filter.Visitado, r.Personas));
		}

		return query;
	}
}
