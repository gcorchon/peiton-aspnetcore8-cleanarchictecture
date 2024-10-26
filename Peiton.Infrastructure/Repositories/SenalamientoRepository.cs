using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Senalamientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISenalamientoRepository))]
public class SenalamientoRepository : RepositoryBase<Senalamiento>, ISenalamientoRepository
{
	public SenalamientoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<List<Senalamiento>> ObtenerSenalamientosAsync(SenalamientosFillter filter)
	{
		var fechaDesde = new DateTime(filter.Year, filter.Month, 1);
		var fechaHasta = fechaDesde.AddMonths(1);

		IQueryable<Senalamiento> query = DbSet.Include(s => s.AbogadoAsistente).Where(s => s.Fecha >= fechaDesde && s.Fecha < fechaHasta && s.MadridCapital == filter.SoloMadrid);

		if (!string.IsNullOrWhiteSpace(filter.Tutelado))
		{
			query = query.Where(s => s.Tutelado != null && s.Tutelado.Contains(filter.Tutelado));
		}

		return query.OrderBy(s => s.Fecha).AsNoTracking().ToListAsync();
	}
}
