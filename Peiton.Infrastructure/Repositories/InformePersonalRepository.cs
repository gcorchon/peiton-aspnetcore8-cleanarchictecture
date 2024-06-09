using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInformePersonalRepository))]
	public class InformePersonalRepository: RepositoryBase<InformePersonal>, IInformePersonalRepository
	{
		public InformePersonalRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}