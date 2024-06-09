using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IAmbitoCoberturaServicioRepository))]
	public class AmbitoCoberturaServicioRepository: RepositoryBase<AmbitoCoberturaServicio>, IAmbitoCoberturaServicioRepository
	{
		public AmbitoCoberturaServicioRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}