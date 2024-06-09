using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IOrigenExpedienteRepository))]
	public class OrigenExpedienteRepository: RepositoryBase<OrigenExpediente>, IOrigenExpedienteRepository
	{
		public OrigenExpedienteRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}