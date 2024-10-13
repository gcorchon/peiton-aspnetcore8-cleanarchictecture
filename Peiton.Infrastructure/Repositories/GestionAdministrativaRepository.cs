using Microsoft.EntityFrameworkCore;
using Peiton.Core.Repositories;
using Peiton.Contracts.GestoresAdministrativos;
using Peiton.Core.Entities;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;

[Injectable(typeof(IGestionAdministrativaRepository))]
public class GestionAdministrativaRepository : RepositoryBase<GestionAdministrativa>, IGestionAdministrativaRepository
{
    public GestionAdministrativaRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<int> ContarGestionesAdministrativasAsync(GestionesAdministrativasFilter filter)
    {
        IQueryable<GestionAdministrativa> query = this.DbSet.Include(g => g.Tutelado)
                                                    .Include(g => g.Usuario)
                                                    .Include(g => g.GestionAdministrativaTipo);

        return ApplyFilter(query, filter)
                .CountAsync();
    }


    public Task<List<GestionAdministrativa>> ObtenerGestionesAdministrativasAsync(int page, int total, GestionesAdministrativasFilter filter)
    {
        IQueryable<GestionAdministrativa> query = this.DbSet.Include(g => g.Tutelado)
                                                    .Include(g => g.Usuario)
                                                    .Include(g => g.GestionAdministrativaTipo);


        query = this.ApplyFilter(query, filter);

        return query.OrderByDescending(a => a.Id)
                    .Skip((page - 1) * total)
                    .Take(total)
                    .ToListAsync();
    }

    private IQueryable<GestionAdministrativa> ApplyFilter(IQueryable<GestionAdministrativa> query, GestionesAdministrativasFilter filter)
    {
        if (filter == null) return query;

        if (filter.Id.HasValue)
        {
            query = query.Where(a => a.Id == filter.Id.Value);
        }

        if (!string.IsNullOrWhiteSpace(filter.Tutelado))
        {
            query = query.Where(a => a.Tutelado.NombreCompleto!.Contains(filter.Tutelado));
        }

        if (!string.IsNullOrWhiteSpace(filter.Trabajador))
        {
            query = query.Where(a => a.Usuario.NombreCompleto.Contains(filter.Trabajador));
        }

        if (filter.Tipo.HasValue)
        {
            query = query.Where(a => a.GestionAdministrativaTipoId == filter.Tipo);
        }

        if (filter.Estado.HasValue)
        {
            query = query.Where(a => (a.Estado & filter.Estado) > 0);
        }

        return query;
    }
}
