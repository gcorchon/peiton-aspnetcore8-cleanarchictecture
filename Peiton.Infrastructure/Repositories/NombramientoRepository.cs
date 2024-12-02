using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(INombramientoRepository))]
public class NombramientoRepository(PeitonDbContext dbContext) : RepositoryBase<Nombramiento>(dbContext), INombramientoRepository
{
}
