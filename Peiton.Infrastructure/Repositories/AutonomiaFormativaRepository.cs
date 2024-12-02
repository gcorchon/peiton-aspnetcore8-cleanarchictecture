using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAutonomiaFormativaRepository))]
public class AutonomiaFormativaRepository(PeitonDbContext dbContext) : RepositoryBase<AutonomiaFormativa>(dbContext), IAutonomiaFormativaRepository
{
}
