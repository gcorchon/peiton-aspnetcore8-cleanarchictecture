using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;


namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAbogadoRepository))]
public class AbogadoRepository : RepositoryBase<Abogado>, IAbogadoRepository
{
	public AbogadoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
