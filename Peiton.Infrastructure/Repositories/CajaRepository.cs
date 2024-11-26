using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Contracts.Enums;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Infrastructure.Utils;

namespace Peiton.Infrastructure.Repositories;
[Injectable(typeof(ICajaRepository))]
public class CajaRepository : RepositoryBase<Caja>, ICajaRepository
{
	public CajaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarMovimientosAsync(TipoMovimiento tipo, CajaFilter filter)
	{
		return ApplyFilters(DbSet.Include(c => c.Tutelado).Include(c => c.TipoPago), tipo, filter).CountAsync();
	}

	public Task<Caja[]> ObtenerMovimientosAsync(int page, int total, TipoMovimiento tipo, CajaFilter filter)
	{
		return ApplyFilters(DbSet.Include(c => c.Tutelado).Include(c => c.TipoPago), tipo, filter)
			.OrderByDescending(c => c.FechaAutorizacion)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}


	private IQueryable<Caja> ApplyFilters(IQueryable<Caja> query, TipoMovimiento tipo, CajaFilter filter)
	{

		query = query.Where(c => c.MetodoPagoId == (int)tipo);

		if (!string.IsNullOrWhiteSpace(filter.Concepto))
		{
			query = query.Where(c => c.Concepto.Contains(filter.Concepto));
		}

		if (!string.IsNullOrWhiteSpace(filter.FechaAutorizacion))
		{
			query = query.Where(c => DbContext.DateAsString(c.FechaAutorizacion).Contains(filter.FechaAutorizacion));
		}

		if (!string.IsNullOrWhiteSpace(filter.FechaPago))
		{
			query = query.Where(c => c.FechaPago != null && DbContext.DateAsString(c.FechaPago.Value).Contains(filter.FechaPago));
		}

		if (!string.IsNullOrWhiteSpace(filter.Nombre))
		{
			query = query.Where(c => c.Tutelado.NombreCompleto!.Contains(filter.Nombre));
		}

		if (filter.Tipo.HasValue)
		{
			query = query.Where(c => c.TipoPagoId == filter.Tipo.Value);
		}

		if (!string.IsNullOrWhiteSpace(filter.Importe))
		{
			query = query.Where(c => DbContext.DecimalAsString(c.Importe).StartsWith(filter.Importe));
		}

		if (filter.Pendiente.HasValue)
		{
			query = query.Where(c => c.Pendiente == filter.Pendiente.Value);
		}

		return query;
	}

	public Task<int> ContarHistoricoMovimientosAsync(int tuteladoId, HistoricoMovimientosFilter filter)
	{
		return ApplyFilters(DbSet.Include(c => c.MetodoPago).Include(c => c.TipoPago), tuteladoId, filter).CountAsync();
	}

	public Task<Caja[]> ObtenerHistoricoMovimientosAsync(int page, int total, int tuteladoId, HistoricoMovimientosFilter filter)
	{
		return ApplyFilters(DbSet.Include(c => c.MetodoPago).Include(c => c.TipoPago), tuteladoId, filter)
			.OrderByDescending(c => c.FechaPago)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	private IQueryable<Caja> ApplyFilters(IQueryable<Caja> query, int tuteladoId, HistoricoMovimientosFilter filter)
	{
		query = query.Where(c => c.TuteladoId == tuteladoId && !c.Pendiente);

		if (!string.IsNullOrWhiteSpace(filter.Concepto))
		{
			query = query.Where(c => c.Concepto.Contains(filter.Concepto));
		}

		if (!string.IsNullOrWhiteSpace(filter.FechaAutorizacion))
		{
			query = query.Where(c => DbContext.DateAsString(c.FechaAutorizacion).Contains(filter.FechaAutorizacion));
		}

		if (filter.Metodo.HasValue)
		{
			query = query.Where(c => c.MetodoPagoId == filter.Metodo);
		}

		if (!string.IsNullOrWhiteSpace(filter.Importe))
		{
			query = query.Where(c => DbContext.DecimalAsString(c.Importe).StartsWith(filter.Importe));
		}

		if (filter.Anticipo.HasValue)
		{
			query = query.Where(c => c.Anticipo == filter.Anticipo.Value);
		}

		return query;
	}

	public async Task<decimal> ObtenerSaldoCajaAsync(int tuteladoId)
	{
		var saldoInicialCaja = await DbContext.Tutelado.Where(t => t.Id == tuteladoId).Select(t => t.SaldoInicialCaja).SingleAsync();
		var total = await DbSet.Where(c => !c.Anticipo && !c.Pendiente && c.TuteladoId == tuteladoId).SumAsync(c => c.Importe);
		return total + saldoInicialCaja;
	}

	public async Task<decimal> ObtenerSaldoCajaAsync()
	{
		var saldoInicialCaja = await DbContext.Tutelado.SumAsync(t => t.SaldoInicialCaja);
		var total = await DbSet.Where(c => !c.Anticipo && !c.Pendiente).SumAsync(c => c.Importe);
		return total + saldoInicialCaja;
	}

	public Task<Reintegro[]> ObtenerReintegrosParaDocumentoAsync(DateTime fechaDesde, DateTime fechaHasta)
	{
		return DbContext.Database
					.SqlQuery<Reintegro>(@$"SELECT Tutelado.Apellidos + ', ' + Tutelado.Nombre as ApellidosNombre, SaldoInicialCaja + coalesce(Total, 0) as SaldoCaja, Caja.Concepto, Caja.Importe, Convert(date, Caja.FechaPago) as FechaPago, Caja.Anticipo
                                                FROM [Tutelado]
                                                inner join Caja on Pk_Tutelado = Caja.Fk_Tutelado and Caja.FechaPago between {fechaDesde} and dateadd(d, 1, {fechaHasta}) 
                                                left join (select Fk_Tutelado, SUM(Importe) as Total 
                                                from Caja where Caja.Anticipo=0 and Caja.Pendiente=0 group by Fk_Tutelado) dv 
                                                ON Pk_Tutelado = dv.Fk_Tutelado
                                                order by 1, Caja.FechaPago desc").ToArrayAsync();
	}

}
