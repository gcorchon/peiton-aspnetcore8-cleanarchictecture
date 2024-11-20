using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Seguimientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAgendaRepository))]
public class AgendaRepository : RepositoryBase<Agenda>, IAgendaRepository
{
	public AgendaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarSeguimientosAsync(int tuteladoId, SeguimientosFilter filter)
	{
		return ApplyFilters(DbSet, tuteladoId, filter).CountAsync();
	}

	public Task<Agenda[]> ObtenerSeguimientosAsync(int page, int total, int tuteladoId, SeguimientosFilter filter)
	{
		return ApplyFilters(DbSet, tuteladoId, filter)
			.OrderByDescending(s => s.Id)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	public Task<Agenda[]> ObtenerSeguimientosAsync(int tuteladoId, SeguimientosFilter filter)
	{
		return ApplyFilters(DbSet.Include(a => a.Usuario)
								 .Include(a => a.AgendaActuacion)
							, tuteladoId, filter)
			.OrderByDescending(s => s.Id)
			.AsNoTracking()
			.ToArrayAsync();
	}

	private IQueryable<Agenda> ApplyFilters(IQueryable<Agenda> query, int tuteladoId, SeguimientosFilter filter)
	{
		query = query.Include(a => a.Tutelado).Include(a => a.CategoriaAgenda).Include(a => a.AgendaAreaActuacion).Where(t => t.TuteladoId == tuteladoId);

		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.Tutelado))
		{
			query = query.Where(s => s.Tutelado.NombreCompleto!.Contains(filter.Tutelado));
		}

		if (!string.IsNullOrWhiteSpace(filter.Descripcion))
		{
			query = query.Where(s => s.Descripcion.Contains(filter.Descripcion));
		}

		if (filter.Fecha.HasValue)
		{
			query = query.Where(s => s.Fecha.Date == filter.Fecha.Value.Date);
		}

		if (filter.CategoriaAgendaId.HasValue)
		{
			query = query.Where(s => s.CategoriaAgendaId == filter.CategoriaAgendaId.Value);
		}

		if (filter.AgendaActuacionId.HasValue)
		{
			query = query.Where(s => s.AgendaActuacionId == filter.AgendaActuacionId.Value);
		}


		return query;
	}

	public Task<Agenda[]> ObtenerSeguimientosAsync(ExportarSeguimientosMasivaRequest request)
	{
		var diaSiguiente = request.FechaFin.AddDays(1);
		var query = DbSet
			.Include(a => a.Tutelado)
			.Include(a => a.Usuario)
			.Include(a => a.AgendaAreaActuacion)
			.Include(a => a.AgendaActuacion)
			.Include(a => a.CategoriaAgenda)
			.Where(a => a.Fecha >= request.FechaInicio && a.Fecha < diaSiguiente);

		if (request.CategoriaAgendaId != null)
		{
			query = query.Where(a => a.CategoriaAgendaId == request.CategoriaAgendaId.Value);
		}

		if (request.UsuarioId != null)
		{
			query = query.Where(a => a.UsuarioId == request.UsuarioId.Value);
		}

		return query.ToArrayAsync();
	}
}
