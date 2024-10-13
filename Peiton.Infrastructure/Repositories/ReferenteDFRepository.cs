using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IReferenteDFRepository))]
public class ReferenteDFRepository : RepositoryBase<ReferenteDF>, IReferenteDFRepository
{
	public ReferenteDFRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
