using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IProductoManualRepository))]
	public class ProductoManualRepository: RepositoryBase<ProductoManual>, IProductoManualRepository
	{
		public ProductoManualRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}