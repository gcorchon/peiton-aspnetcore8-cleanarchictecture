using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITrabajadorSocialRepository))]
public class TrabajadorSocialRepository(PeitonDbContext dbContext) : RepositoryBase<TrabajadorSocial>(dbContext), ITrabajadorSocialRepository
{
}
