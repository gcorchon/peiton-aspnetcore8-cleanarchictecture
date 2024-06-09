using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEscritoSucursalRepository))]
	public class EscritoSucursalRepository: RepositoryBase<EscritoSucursal>, IEscritoSucursalRepository
	{
		public EscritoSucursalRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}