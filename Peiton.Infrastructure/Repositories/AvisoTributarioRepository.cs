using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IAvisoTributarioRepository))]
	public class AvisoTributarioRepository: RepositoryBase<AvisoTributario>, IAvisoTributarioRepository
	{
		public AvisoTributarioRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}