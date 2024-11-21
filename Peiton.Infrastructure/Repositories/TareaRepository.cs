using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Tareas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaRepository))]
public class TareaRepository : RepositoryBase<Tarea>, ITareaRepository
{
	public TareaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarTareasAsync(int tuteladoId, TareasFilter filter)
	{
		return ApplyFilters(DbSet, tuteladoId, filter).CountAsync();
	}

	public Task<Tarea[]> ObtenerTareasAsync(int page, int total, int tuteladoId, TareasFilter filter)
	{
		return ApplyFilters(DbSet, tuteladoId, filter)
			.OrderByDescending(s => s.Id)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	private IQueryable<Tarea> ApplyFilters(IQueryable<Tarea> query, int tuteladoId, TareasFilter filter)
	{
		query = query.Include(t => t.TareaDepartamento)
				.Include(t => t.TareaCategoria)
				.Include(t => t.TareaSubcategoria)
				.Include(t => t.TareaTipo)
				.Include(t => t.UsuarioGestor)
				.Where(t => t.TuteladoId == tuteladoId);

		if (filter == null) return query;

		if (filter.Fecha.HasValue)
		{
			query = query.Where(t => t.Fecha.Date == filter.Fecha.Value.Date);
		}

		if (filter.TareaDepartamentoId.HasValue)
		{
			query = query.Where(t => t.TareaDepartamentoId == filter.TareaDepartamentoId);
		}

		if (filter.TareaTipoId.HasValue)
		{
			query = query.Where(t => t.TareaTipoId == filter.TareaTipoId);
		}

		if (!string.IsNullOrWhiteSpace(filter.TareaCategoria))
		{
			query = query.Where(s => s.TareaCategoria != null && s.TareaCategoria.Descripcion.Contains(filter.TareaCategoria));
		}

		if (!string.IsNullOrWhiteSpace(filter.TareaSubcategoria))
		{
			query = query.Where(s => s.TareaSubcategoria != null && s.TareaSubcategoria.Descripcion.Contains(filter.TareaSubcategoria));
		}


		if (!string.IsNullOrWhiteSpace(filter.UsuarioGestor))
		{
			query = query.Where(s => s.UsuarioGestor != null && s.UsuarioGestor.NombreCompleto!.Contains(filter.UsuarioGestor));
		}

		return query;
	}
}
