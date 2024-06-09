using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IConsultaAlmacenadaRepository))]
	public class ConsultaAlmacenadaRepository: RepositoryBase<ConsultaAlmacenada>, IConsultaAlmacenadaRepository
	{
		public ConsultaAlmacenadaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}