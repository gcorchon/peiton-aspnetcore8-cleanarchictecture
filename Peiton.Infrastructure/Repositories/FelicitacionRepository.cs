using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFelicitacionRepository))]
public class FelicitacionRepository(PeitonDbContext dbContext) : RepositoryBase<Felicitacion>(dbContext), IFelicitacionRepository
{
}
