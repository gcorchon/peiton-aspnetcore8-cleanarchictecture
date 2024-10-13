using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMedidaPenalMedidaRepository))]
public class MedidaPenalMedidaRepository : RepositoryBase<MedidaPenalMedida>, IMedidaPenalMedidaRepository
{
	public MedidaPenalMedidaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
