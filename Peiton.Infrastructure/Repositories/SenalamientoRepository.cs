using Dapper;
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

	public Task<Abogado?> BuscarAbogadoDisponibleAsync(DateTime fecha)
	{
		return this.DbContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<Abogado>(@"select top 1 Abogado.* from Abogado
                            left join Senalamiento on Fk_AbogadoAsistente = Pk_Abogado and CONVERT(date, fecha) = CONVERT(date, @fecha)         
                            where Abogado.Senalamientos = 1 and Senalamiento.Pk_Senalamiento is null
                            order by (select COUNT(*) from Senalamiento where Fk_AbogadoAsistente=Pk_Abogado and Senalamiento.Fecha > DATEADD(d, -7, convert(date, @fecha)))", new { fecha });
	}

	public Task<bool> EstaLibrandoAsync(int abogadoId, DateTime fecha, int senalamientoId)
	{
		return this.DbContext.Database.GetDbConnection().ExecuteScalarAsync<bool>(@"select case when exists(
                                            SELECT null
                                              FROM Senalamiento where Fk_AbogadoAsistente = @abogadoId
                                              and CONVERT(date, fecha) = CONVERT(date, @fecha) 
                                              and Pk_Senalamiento <> @senalamientoId) then convert(bit, 0) 
                                            else convert(bit, 1) end as libra", new { abogadoId, fecha, senalamientoId });

	}

	public Task<bool> EstaLibrandoAsync(int abogadoId, DateTime fecha)
	{
		return this.DbContext.Database.GetDbConnection().ExecuteScalarAsync<bool>(@"select case when exists(
                                            SELECT null
                                              FROM Senalamiento where Fk_AbogadoAsistente = @abogadoId
                                              and CONVERT(date, fecha) = CONVERT(date, @fecha)) then convert(bit,0)
                                            else convert(bit, 1) end as libra", new { abogadoId, fecha });
	}

	public Task<bool> TieneOtroCasoAsync(int abogadoId, DateTime fecha, int juzgadoId, int senalamientoId)
	{
		return this.DbContext.Database.GetDbConnection().ExecuteScalarAsync<bool>(@"select case when exists(
                                            SELECT null
                                              FROM Senalamiento where Fk_AbogadoAsistente = @abogadoId
                                              and CONVERT(date, fecha) = CONVERT(date, @fecha)
                                              and Pk_Senalamiento <> @senalamientoId
                                              and Fk_Juzgado = @juzgadoId)
                                            then convert(bit, 1) 
                                            else convert(bit, 0) end as mismoJuzgado", new { abogadoId, fecha, juzgadoId, senalamientoId });
	}

	public Task<bool> TieneOtroCasoAsync(int abogadoId, DateTime fecha, int juzgadoId)
	{
		return this.DbContext.Database.GetDbConnection().ExecuteScalarAsync<bool>(@"select case when exists(
                                            SELECT null
                                              FROM Senalamiento where Fk_AbogadoAsistente = @abogadoId
                                              and CONVERT(date, fecha) = CONVERT(date, @fecha)
                                              and Fk_Juzgado = @juzgadoId)
                                            then convert(bit, 1) 
                                            else convert(bit, 0) end as mismoJuzgado", new { abogadoId, fecha, juzgadoId });
	}
}
