using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IMetodoPagoRepository))]
	public class MetodoPagoRepository: RepositoryBase<MetodoPago>, IMetodoPagoRepository
	{
		public MetodoPagoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}