using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IResidenciaHabitualRepository))]
public class ResidenciaHabitualRepository : RepositoryBase<ResidenciaHabitual>, IResidenciaHabitualRepository
{
	public ResidenciaHabitualRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
