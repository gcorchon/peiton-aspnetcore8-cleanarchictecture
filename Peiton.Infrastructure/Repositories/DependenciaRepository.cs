using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDependenciaRepository))]
	public class DependenciaRepository: RepositoryBase<Dependencia>, IDependenciaRepository
	{
		public DependenciaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}