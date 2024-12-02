using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(INivelSoporteRepository))]
public class NivelSoporteRepository(PeitonDbContext dbContext) : RepositoryBase<NivelSoporte>(dbContext), INivelSoporteRepository
{
}
