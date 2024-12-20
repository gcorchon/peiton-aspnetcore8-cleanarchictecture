using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEducadorSocialRepository))]
public class EducadorSocialRepository(PeitonDbContext dbContext) : RepositoryBase<EducadorSocial>(dbContext), IEducadorSocialRepository
{
}
