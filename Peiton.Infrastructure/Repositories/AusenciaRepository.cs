using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Ausencias;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;

[Injectable(typeof(IAusenciaRepository))]
public class AusenciaRepository : RepositoryBase<Ausencia>, IAusenciaRepository
{
    public AusenciaRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<int> ContarAusenciasAsync(AusenciasFilter filter)
    {
        return ApplyFilters(this.DbSet.Include(a => a.Usuario)
                            .Include(a => a.UsuarioSuplente)
                            , filter).CountAsync();
    }

    public Task<Ausencia[]> ObtenerAusenciasAsync(int page, int total, AusenciasFilter filter)
    {
        return ApplyFilters(this.DbSet
                            .Include(a => a.Usuario)
                            .Include(a => a.UsuarioSuplente), filter)
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * total)
                .Take(total)
                .AsNoTracking()
                .ToArrayAsync();
    }

    private IQueryable<Ausencia> ApplyFilters(IQueryable<Ausencia> query, AusenciasFilter filter)
    {
        if (filter == null) return query;

        if (filter.FechaIntervalo.HasValue)
        {
            query = query.Where(a => a.FechaInicio <= filter.FechaIntervalo && a.FechaFin >= filter.FechaIntervalo);
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaInicio))
        {
            query = query.Where(a => this.DbContext.DateAsString(a.FechaInicio).Contains(filter.FechaInicio));
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaFin))
        {
            query = query.Where(a => this.DbContext.DateAsString(a.FechaFin).Contains(filter.FechaFin));
        }

        if (!string.IsNullOrWhiteSpace(filter.Usuario))
        {
            query = query.Where(a => a.Usuario.NombreCompleto.Contains(filter.Usuario));
        }

        if (!string.IsNullOrWhiteSpace(filter.UsuarioSuplente))
        {
            query = query.Where(a => a.UsuarioSuplente != null && a.UsuarioSuplente.NombreCompleto.Contains(filter.UsuarioSuplente));
        }

        return query;

    }

    /*public Ausencia? ObtenerAusenciaActual(int userId)
    {
        var hoy = DateTime.Now.Date;
        return this.DbSet.Where(a => a.UsuarioId == userId && a.FechaInicio <= hoy && a.FechaFin >= hoy).FirstOrDefault();
    }*/

    public async Task<Ausencia?> ObtenerAusenciaActualAsync(int userId)
    {
        var hoy = DateTime.Now.Date;
        return await DbSet.Where(a => a.UsuarioId == userId && a.FechaInicio <= hoy && a.FechaFin >= hoy).FirstOrDefaultAsync();
    }
}
