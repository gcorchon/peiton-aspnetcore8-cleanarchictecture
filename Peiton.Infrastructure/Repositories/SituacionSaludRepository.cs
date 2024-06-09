using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ISituacionSaludRepository))]
	public class SituacionSaludRepository: RepositoryBase<SituacionSalud>, ISituacionSaludRepository
	{
		public SituacionSaludRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}