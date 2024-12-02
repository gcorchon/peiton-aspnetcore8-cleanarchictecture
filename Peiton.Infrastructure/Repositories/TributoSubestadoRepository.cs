using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITributoSubestadoRepository))]
public class TributoSubestadoRepository(PeitonDbContext dbContext) : RepositoryBase<TributoSubestado>(dbContext), ITributoSubestadoRepository
{
}
