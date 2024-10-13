using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMedidaPenalRepository))]
public class MedidaPenalRepository : RepositoryBase<MedidaPenal>, IMedidaPenalRepository
{
	public MedidaPenalRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
