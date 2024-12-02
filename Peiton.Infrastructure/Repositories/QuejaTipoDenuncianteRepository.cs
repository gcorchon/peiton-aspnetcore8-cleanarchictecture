using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IQuejaTipoDenuncianteRepository))]
public class QuejaTipoDenuncianteRepository(PeitonDbContext dbContext) : RepositoryBase<QuejaTipoDenunciante>(dbContext), IQuejaTipoDenuncianteRepository
{
}
