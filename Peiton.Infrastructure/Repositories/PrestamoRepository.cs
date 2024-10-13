using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPrestamoRepository))]
public class PrestamoRepository : RepositoryBase<Prestamo>, IPrestamoRepository
{
	public PrestamoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
