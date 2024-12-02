using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Vales;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;
[Injectable(typeof(IValeRepository))]
public class ValeRepository(PeitonDbContext dbContext) : RepositoryBase<Vale>(dbContext), IValeRepository
{
	public Task<int> ContarValesAsync(ValesFilter filter)
	{
		return ApplyFilters(DbSet.Include(v => v.Solicitante), filter).CountAsync();
	}

	public Task<Vale[]> ObtenerValesAsync(int page, int total, ValesFilter filter)
	{
		return ApplyFilters(DbSet.Include(v => v.Solicitante), filter)
					.OrderByDescending(v => v.Id)
					.Skip((page - 1) * total)
					.Take(total)
					.AsNoTracking()
					.ToArrayAsync();
	}

	private IQueryable<Vale> ApplyFilters(IQueryable<Vale> query, ValesFilter filter)
	{
		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.FechaSolicitud))
		{
			query = query.Where(v => DbContext.DateAsString(v.FechaSolicitud).Contains(filter.FechaSolicitud));
		}

		if (!string.IsNullOrWhiteSpace(filter.FechaRevision))
		{
			query = query.Where(v => v.FechaRevision != null && DbContext.DateAsString(v.FechaRevision.Value).Contains(filter.FechaRevision));
		}

		if (!string.IsNullOrWhiteSpace(filter.FechaAutorizacion))
		{
			query = query.Where(v => v.FechaAutorizacion != null && DbContext.DateAsString(v.FechaAutorizacion.Value).Contains(filter.FechaAutorizacion));
		}

		if (!string.IsNullOrWhiteSpace(filter.FechaPago))
		{
			query = query.Where(v => v.FechaPago != null && DbContext.DateAsString(v.FechaPago.Value).Contains(filter.FechaPago));
		}

		if (!string.IsNullOrWhiteSpace(filter.Solicitante))
		{
			query = query.Where(t => t.Solicitante.NombreCompleto.Contains(filter.Solicitante));
		}

		if (!string.IsNullOrWhiteSpace(filter.Importe))
		{
			query = query.Where(v => DbContext.DecimalAsString(v.Importe).StartsWith(filter.Importe));
		}

		if (filter.Estado.HasValue)
		{
			var estado = filter.Estado.Value;
			if (estado == 1) query = query.Where(v => v.Revisado && !v.Autorizado && !v.Pagado && !v.Rechazado);
			else if (estado == 2) query = query.Where(v => v.Autorizado && !v.Pagado && !v.Rechazado);
			else if (estado == 3) query = query.Where(v => v.Pagado && !v.Rechazado);
			else if (estado == 4) query = query.Where(v => v.Rechazado);
			else if (estado == 0) query = query.Where(v => !v.Revisado && !v.Autorizado && !v.Pagado && !v.Rechazado);

		}

		return query;
	}
}
