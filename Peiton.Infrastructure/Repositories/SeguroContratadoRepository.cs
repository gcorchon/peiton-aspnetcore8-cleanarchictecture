using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ISeguroContratadoRepository))]
	public class SeguroContratadoRepository: RepositoryBase<SeguroContratado>, ISeguroContratadoRepository
	{
		public SeguroContratadoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}