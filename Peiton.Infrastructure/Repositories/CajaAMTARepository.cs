using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Contracts.MovimientosPendientesCaja;
using Microsoft.EntityFrameworkCore;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{

    [Injectable(typeof(ICajaAMTARepository))]
    public class CajaAMTARepository: RepositoryBase<CajaAMTA>, ICajaAMTARepository
	{
        
        public CajaAMTARepository(PeitonDbContext dbContext) : base(dbContext)
        {
            
        }

        public Task<int> ContarMovimientosPendientesCajaAsync(MovimientosPendientesCajaFilter filter)
        {
            IQueryable<CajaAMTA> query = this.DbSet
                             .Include(c => c.Tutelado);

            query = ApplyFilters(query, filter);

            return query.CountAsync();
        }

        public Task<List<CajaAMTA>> ObtenerMovimientosPendientesCajaAsync(int page, int total, MovimientosPendientesCajaFilter filter)
        {
            IQueryable<CajaAMTA> query = this.DbSet
                             .Include(c => c.Tutelado);
            
            query = ApplyFilters(query, filter);

            return query
                        .OrderByDescending(c => c.Fecha)
                        .Skip((page - 1) * total)
                        .Take(total)
                        .AsNoTracking()
                        .ToListAsync();
        }

        IQueryable<CajaAMTA> ApplyFilters(IQueryable<CajaAMTA> query, MovimientosPendientesCajaFilter filter)
        {
            var fechaDesde = new DateTime(2016, 1, 1);
            
            query = query.Where(c => c.Fecha >= fechaDesde);

            if (!string.IsNullOrWhiteSpace(filter.Fecha))
            {
                query = query.Where(c => this.DbContext.DateAsString(c.Fecha).Contains(filter.Fecha));
            }

            if(!string.IsNullOrWhiteSpace(filter.Importe))
            {
                query = query.Where(c => this.DbContext.DecimalAsString(c.Importe).StartsWith(filter.Importe));
            }

            if(!string.IsNullOrWhiteSpace(filter.Concepto))
            {
                query = query.Where(c => c.Concepto.Contains(filter.Concepto));
            }

            if(!string.IsNullOrWhiteSpace(filter.Persona))
            {
                query = query.Where(c => (c.Persona ?? "").Contains(filter.Persona) || (c.Tutelado != null && (c.Tutelado.NombreCompleto ?? "").Contains(filter.Persona)));
            }

            if (filter.Pendientes.HasValue)
            {
                if (filter.Pendientes.Value)
                {
                    query = query
                        .Include(c => c.Asientos)
                        .Where(c => c.Asientos.Sum(a => a.Importe) != c.Importe);
                } 
                else
                {
                    query = query
                        .Include(c => c.Asientos)
                        .Where(c => c.Asientos.Sum(a => a.Importe) == c.Importe);
                }
            }

            return query;
        }
    }
}