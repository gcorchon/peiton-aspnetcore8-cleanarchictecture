using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.EmergenciasCentros;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEmergenciaCentroRepository))]
public class EmergenciaCentroRepository(PeitonDbContext dbContext) : RepositoryBase<EmergenciaCentro>(dbContext), IEmergenciaCentroRepository
{
    public Task<int> ContarEmergenciasCentrosAsync(int tuteladoId, EmergenciasCentrosFilter filter)
    {
        return ApplyFilters(DbSet, tuteladoId, filter).CountAsync();
    }
    
    public Task<EmergenciaCentro[]> ObtenerEmergenciasCentrosAsync(int page, int total, int tuteladoId, EmergenciasCentrosFilter filter)
    {
        return ApplyFilters(DbSet, tuteladoId, filter)
            .OrderByDescending(s => s.Id)
            .Skip((page - 1) * total)
            .Take(total)
            .AsNoTracking()
            .ToArrayAsync();
    }

    private IQueryable<EmergenciaCentro> ApplyFilters(IQueryable<EmergenciaCentro> query, int tuteladoId, EmergenciasCentrosFilter filter)
    {
        query = query.Include(e => e.MotivoEmergenciaCentro).Where(e => e.TuteladoId == tuteladoId);

        if(filter == null) return query;

        if(!string.IsNullOrWhiteSpace(filter.Descripcion))
        {
            query = query.Where(s => s.Descripcion.Contains(filter.Descripcion));
        }

        if(!string.IsNullOrWhiteSpace(filter.MotivoEmergenciaCentro))
        {
            query = query.Where(s => s.MotivoEmergenciaCentro.Descripcion.Contains(filter.MotivoEmergenciaCentro));
        }

        if(filter.Fecha.HasValue)
        {
            query = query.Where(s => s.Fecha.Date == filter.Fecha.Value.Date);
        }
        
        if(!string.IsNullOrWhiteSpace(filter.Hora))
        {
            query = query.Where(s => DbContext.TimeFromDate(s.Fecha).StartsWith(filter.Hora));
        }
        
        return query;
    }
}
