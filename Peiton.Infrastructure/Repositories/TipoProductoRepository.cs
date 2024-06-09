using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoProductoRepository))]
	public class TipoProductoRepository: RepositoryBase<TipoProducto>, ITipoProductoRepository
	{
		public TipoProductoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}