using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISalaReservaRepository))]
public class SalaReservaRepository(PeitonDbContext dbContext) : RepositoryBase<SalaReserva>(dbContext), ISalaReservaRepository
{
	public Task<SalaReserva[]> ObtenerReservasAsync(DateTime fecha)
	{
		return DbSet.Where(r => r.Fecha == fecha).Include(r => r.Usuario).AsNoTracking().ToArrayAsync();
	}
}
