using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITecnicoIntegracionSocialRepository))]
public class TecnicoIntegracionSocialRepository(PeitonDbContext dbContext) : RepositoryBase<TecnicoIntegracionSocial>(dbContext), ITecnicoIntegracionSocialRepository
{
}
