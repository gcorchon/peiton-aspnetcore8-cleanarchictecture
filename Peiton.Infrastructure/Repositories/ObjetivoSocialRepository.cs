using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IObjetivoSocialRepository))]
public class ObjetivoSocialRepository(PeitonDbContext dbContext) : RepositoryBase<ObjetivoSocial>(dbContext), IObjetivoSocialRepository
{
}
