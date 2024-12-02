using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IVehiculoEntidadReservaRepository))]
public class VehiculoEntidadReservaRepository(PeitonDbContext dbContext) : RepositoryBase<VehiculoEntidadReserva>(dbContext), IVehiculoEntidadReservaRepository
{
    public Task<VehiculoEntidadReserva[]> ObtenerReservasAsync(DateTime fecha)
    {
        return this.DbSet.Include("Usuario").Where(r => r.Fecha == fecha).ToArrayAsync();
    }
}
