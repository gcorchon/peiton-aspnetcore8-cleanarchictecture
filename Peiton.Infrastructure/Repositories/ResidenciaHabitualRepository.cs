using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IResidenciaHabitualRepository))]
public class ResidenciaHabitualRepository(PeitonDbContext dbContext) : RepositoryBase<ResidenciaHabitual>(dbContext), IResidenciaHabitualRepository
{
}
