using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoObjetivoRepository))]
public class TuteladoObjetivoRepository(PeitonDbContext dbContext) : RepositoryBase<TuteladoObjetivo>(dbContext), ITuteladoObjetivoRepository
{
	public Task<TuteladoObjetivo[]> ObtenerObjetivosAsync(int tuteladoId, int tipoObjetivoId)
	{
		return DbSet
			.Where(t => t.TuteladoId == tuteladoId && t.TipoObjetivoId == tipoObjetivoId)
			.ToArrayAsync();
	}
}
