using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoResidenciaRepository))]
	public class TipoResidenciaRepository: RepositoryBase<TipoResidencia>, ITipoResidenciaRepository
	{
		public TipoResidenciaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}