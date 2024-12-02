using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoAnejoRepository))]
public class TipoAnejoRepository(PeitonDbContext dbContext) : RepositoryBase<TipoAnejo>(dbContext), ITipoAnejoRepository
{
}
