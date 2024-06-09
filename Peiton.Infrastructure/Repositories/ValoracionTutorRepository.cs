using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IValoracionTutorRepository))]
	public class ValoracionTutorRepository: RepositoryBase<ValoracionTutor>, IValoracionTutorRepository
	{
		public ValoracionTutorRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}