using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.AvisosTributarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAvisoTributarioRepository))]
public class AvisoTributarioRepository(PeitonDbContext dbContext) : RepositoryBase<AvisoTributario>(dbContext), IAvisoTributarioRepository
{
    public Task<int> ContarAvisosTributariosAsync(AvisosTributariosFilter filter)
    {
        return ApplyFilters(this.DbSet.Include(a => a.TipoAvisoTributario)
                            .Include(a => a.Usuario)
                            .Include(a => a.Tutelado), filter).CountAsync();
    }

    public Task<AvisoTributario[]> ObtenerAvisosTributariosAsync(int page, int total, AvisosTributariosFilter filter)
    {
        return ApplyFilters(this.DbSet.Include(a => a.TipoAvisoTributario)
                            .Include(a => a.Usuario)
                            .Include(a => a.Tutelado), filter)
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * total)
                .Take(total)
                .AsNoTracking()
                .ToArrayAsync();
    }

    private IQueryable<AvisoTributario> ApplyFilters(IQueryable<AvisoTributario> query, AvisosTributariosFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrWhiteSpace(filter.Id))
        {
            query = query.Where(a => DbContext.IntAsString(a.Id).StartsWith(filter.Id));
        }

        if (!string.IsNullOrWhiteSpace(filter.Tutelado))
        {
            query = query.Where(a => a.Tutelado.NombreCompleto!.Contains(filter.Tutelado));
        }

        if (!string.IsNullOrWhiteSpace(filter.Usuario))
        {
            query = query.Where(a => a.Usuario.NombreCompleto.Contains(filter.Usuario));
        }

        if (filter.TipoAvisoTributarioId.HasValue)
        {
            query = query.Where(a => a.TipoAvisoTributarioId == filter.TipoAvisoTributarioId.Value);
        }

        if (filter.Estado.HasValue)
        {
            switch (filter.Estado.Value)
            {
                case 0:
                    query = query.Where(t => !t.EnTramite && !t.Resuelto);
                    break;
                case 1:
                    query = query.Where(t => t.EnTramite && !t.Resuelto);
                    break;
                case 2:
                    query = query.Where(t => t.Resuelto);
                    break;
            }
        }

        return query;
    }

}
