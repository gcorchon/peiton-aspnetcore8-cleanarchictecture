using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Emergencias;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEmergenciaRepository))]
public class EmergenciaRepository(PeitonDbContext dbContext) : RepositoryBase<Emergencia>(dbContext), IEmergenciaRepository
{
    
    public Task<int> ContarEmergenciasAsync(int tuteladoId, EmergenciasFilter filter)
    {
        return ApplyFilters(DbSet, tuteladoId, filter).CountAsync();
    }
    
    public Task<Emergencia[]> ObtenerEmergenciasAsync(int page, int total, int tuteladoId, EmergenciasFilter filter)
    {
        return ApplyFilters(DbSet, tuteladoId, filter)
            .OrderByDescending(s => s.Id)
            .Skip((page - 1) * total)
            .Take(total)
            .AsNoTracking()
            .ToArrayAsync();
    }
    
    private IQueryable<Emergencia> ApplyFilters(IQueryable<Emergencia> query, int tuteladoId, EmergenciasFilter filter)
    {
        query = query.Include(e => e.MotivoEmergencia).Include(e => e.EmergenciaLlamada).Where(e => e.TuteladoId == tuteladoId);

        if(filter == null) return query;

        if(!string.IsNullOrWhiteSpace(filter.Descripcion))
        {
            query = query.Where(s => s.Descripcion.Contains(filter.Descripcion));
        }

        if(!string.IsNullOrWhiteSpace(filter.MotivoEmergencia))
        {
            query = query.Where(s => s.MotivoEmergencia.Descripcion.Contains(filter.MotivoEmergencia));
        }

        if(!string.IsNullOrWhiteSpace(filter.EmergenciaLlamada))
        {
            query = query.Where(s => s.EmergenciaLlamada != null && s.EmergenciaLlamada.Descripcion.Contains(filter.EmergenciaLlamada));
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
