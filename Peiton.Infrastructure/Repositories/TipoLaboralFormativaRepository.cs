using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoLaboralFormativaRepository))]
	public class TipoLaboralFormativaRepository: RepositoryBase<TipoLaboralFormativa>, ITipoLaboralFormativaRepository
	{
		public TipoLaboralFormativaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}