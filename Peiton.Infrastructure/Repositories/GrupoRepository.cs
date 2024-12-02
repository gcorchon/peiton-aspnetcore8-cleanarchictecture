using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IGrupoRepository))]
public class GrupoRepository(PeitonDbContext dbContext) : RepositoryBase<Grupo>(dbContext), IGrupoRepository
{
	public Task<Grupo[]> ObtenerGruposConUsuariosAsync()
	{
		return DbSet.Include(g => g.Usuarios.Where(u => !u.Borrado)
				.OrderBy(u => u.NombreCompleto))
				.AsNoTracking()
				.ToArrayAsync();
	}
}
