using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaTipoRepository))]
public class TareaTipoRepository(PeitonDbContext dbContext) : RepositoryBase<TareaTipo>(dbContext), ITareaTipoRepository
{
}
