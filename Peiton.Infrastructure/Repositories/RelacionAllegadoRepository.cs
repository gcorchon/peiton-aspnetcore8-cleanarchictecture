using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRelacionAllegadoRepository))]
public class RelacionAllegadoRepository(PeitonDbContext dbContext) : RepositoryBase<RelacionAllegado>(dbContext), IRelacionAllegadoRepository
{
}
