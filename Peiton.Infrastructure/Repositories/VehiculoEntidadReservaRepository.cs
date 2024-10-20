using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IVehiculoEntidadReservaRepository))]
public class VehiculoEntidadReservaRepository : RepositoryBase<VehiculoEntidadReserva>, IVehiculoEntidadReservaRepository
{
	public VehiculoEntidadReservaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

    public Task<List<VehiculoEntidadReserva>> ObtenerReservasAsync(DateTime fecha)
    {
        return this.DbSet.Include("Usuario").Where(r => r.Fecha == fecha).ToListAsync();
    }
}
