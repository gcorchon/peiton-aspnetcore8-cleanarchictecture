using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IParticipacionUsuarioPIARepository))]
public class ParticipacionUsuarioPIARepository(PeitonDbContext dbContext) : RepositoryBase<ParticipacionUsuarioPIA>(dbContext), IParticipacionUsuarioPIARepository
{
}
