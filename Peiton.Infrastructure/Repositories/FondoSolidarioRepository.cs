using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFondoSolidarioRepository))]
public class FondoSolidarioRepository(PeitonDbContext dbContext) : RepositoryBase<FondoSolidario>(dbContext), IFondoSolidarioRepository
{
	public Task<int> ContarFondosSolidariosAsync(int tuteladoId)
	{
		return DbSet
				.Include(f => f.FondoSolidarioDestino).Include(f => f.Solicitante)
				.Where(f => f.TuteladoId == tuteladoId)
				.CountAsync();
	}

	public Task<FondoSolidario[]> ObtenerFondosSolidariosAsync(int page, int total, int tuteladoId)
	{
		return DbSet.Include(f => f.FondoSolidarioDestino).Include(f => f.Solicitante)
				.Where(f => f.TuteladoId == tuteladoId)
				.OrderByDescending(f => f.Id)
				.Skip((page - 1) * total)
				.Take(total)
				.AsNoTracking()
				.ToArrayAsync();
	}

	public Task<int> ContarFondosSolidariosAsync(FondosSolidariosFilter filter)
	{
		return ApplyFilters(DbSet, filter).CountAsync();
	}

	public Task<FondoSolidario[]> ObtenerFondosSolidariosAsync(int page, int total, FondosSolidariosFilter filter)
	{
		return ApplyFilters(DbSet, filter)
			.OrderByDescending(s => s.Id)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	private IQueryable<FondoSolidario> ApplyFilters(IQueryable<FondoSolidario> query, FondosSolidariosFilter filter)
	{
		query = query.Include(f => f.Tutelado).Include(f => f.FondoSolidarioTipoFondo);

		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.Tutelado))
		{
			query = query.Where(v => v.Tutelado.NombreCompleto!.Contains(filter.Tutelado));
		}

		if (filter.FechaSolicitud.HasValue)
		{
			query = query.Where(v => v.FechaSolicitud == filter.FechaSolicitud.Value);
		}

		if (filter.FechaRevision.HasValue)
		{
			query = query.Where(v => v.FechaRevision == filter.FechaRevision.Value);
		}

		if (filter.FechaAutorizacion.HasValue)
		{
			query = query.Where(v => v.FechaAutorizacion == filter.FechaAutorizacion.Value);
		}

		if (filter.FechaPago.HasValue)
		{
			query = query.Where(v => v.FechaPago == filter.FechaPago.Value);
		}

		if (filter.Importe.HasValue)
		{
			query = query.Where(v => v.Importe == filter.Importe.Value);
		}

		if (filter.FondoSolidarioTipoFondoId.HasValue)
		{
			query = query.Where(v => v.FondoSolidarioTipoFondoId == filter.FondoSolidarioTipoFondoId.Value);
		}

		if (filter.Estado.HasValue)
		{
			var estado = filter.Estado.Value;
			if (estado == 1) query = query.Where(v => v.Verificado && !v.Revisado && !v.Autorizado && !v.Pagado && !v.Rechazado);
			else if (estado == 2) query = query.Where(v => v.Revisado && !v.Autorizado && !v.Pagado && !v.Rechazado);
			else if (estado == 3) query = query.Where(v => v.Autorizado && !v.Pagado && !v.Rechazado);
			else if (estado == 4) query = query.Where(v => v.Pagado && !v.Rechazado);
			else if (estado == 5) query = query.Where(v => v.Rechazado);
			else if (estado == 0) query = query.Where(v => !v.Verificado && !v.Revisado && !v.Autorizado && !v.Pagado && !v.Rechazado);

		}
		return query;
	}

}