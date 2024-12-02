
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISueldoPensionRepository))]
public class SueldoPensionRepository(PeitonDbContext dbContext) : RepositoryBase<SueldoPension>(dbContext), ISueldoPensionRepository
{
}
