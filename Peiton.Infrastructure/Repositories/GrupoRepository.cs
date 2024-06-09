using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IGrupoRepository))]
	public class GrupoRepository: RepositoryBase<Grupo>, IGrupoRepository
	{
		public GrupoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}