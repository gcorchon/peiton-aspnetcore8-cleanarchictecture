using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMedidaPIARepository))]
public class MedidaPIARepository : RepositoryBase<MedidaPIA>, IMedidaPIARepository
{
	public MedidaPIARepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
