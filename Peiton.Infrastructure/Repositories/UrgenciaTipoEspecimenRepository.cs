using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaTipoEspecimenRepository))]
public class UrgenciaTipoEspecimenRepository : RepositoryBase<UrgenciaTipoEspecimen>, IUrgenciaTipoEspecimenRepository
{
	public UrgenciaTipoEspecimenRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
