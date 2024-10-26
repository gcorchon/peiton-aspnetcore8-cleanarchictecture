using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISalaReservaRepository))]
public class SalaReservaRepository : RepositoryBase<SalaReserva>, ISalaReservaRepository
{
	public SalaReservaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<List<SalaReserva>> ObtenerReservasAsync(DateTime fecha)
	{
		return DbSet.Where(r => r.Fecha == fecha).Include(r => r.Usuario).AsNoTracking().ToListAsync();
	}
}
