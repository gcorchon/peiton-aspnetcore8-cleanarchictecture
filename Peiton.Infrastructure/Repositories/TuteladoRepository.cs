using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoRepository))]
public class TuteladoRepository : RepositoryBase<Tutelado>, ITuteladoRepository
{
	public TuteladoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<Tutelado[]> ObtenerTuteladosParaReintegrosAsync(string text)
	{
		return DbSet
				.Include(t => t.Credenciales.Where(c => !c.Baja))
				.ThenInclude(c => c.Accounts.Where(a => !a.Baja))
				.Where(t => !t.Muerto && t.NombreCompleto!.Contains(text))
				.OrderBy(t => t.NombreCompleto)
				.Take(10)
				.ToArrayAsync();

	}

	public Task<Tutelado[]> ObtenerTuteladosPorNombreAsync(string query, int total)
	{
		return DbSet.Where(t => t.NombreCompleto!.Contains(query)).OrderBy(t => t.NombreCompleto).Take(total).AsNoTracking().ToArrayAsync();

	}
}
