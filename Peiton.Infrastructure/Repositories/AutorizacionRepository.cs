using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAutorizacionRepository))]
public class AutorizacionRepository(PeitonDbContext dbContext) : RepositoryBase<Autorizacion>(dbContext), IAutorizacionRepository
{
}
