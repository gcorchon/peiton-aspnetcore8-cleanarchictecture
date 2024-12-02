using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IResidenciaHabitualHistoricoRepository))]
public class ResidenciaHabitualHistoricoRepository(PeitonDbContext dbContext) : RepositoryBase<ResidenciaHabitualHistorico>(dbContext), IResidenciaHabitualHistoricoRepository
{
}
