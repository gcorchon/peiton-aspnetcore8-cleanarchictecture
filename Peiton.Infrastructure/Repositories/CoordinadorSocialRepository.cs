using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICoordinadorSocialRepository))]
public class CoordinadorSocialRepository(PeitonDbContext dbContext) : RepositoryBase<CoordinadorSocial>(dbContext), ICoordinadorSocialRepository
{
}
