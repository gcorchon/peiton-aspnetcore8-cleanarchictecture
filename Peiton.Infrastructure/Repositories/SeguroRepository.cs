using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISeguroRepository))]
public class SeguroRepository(PeitonDbContext dbContext) : RepositoryBase<Seguro>(dbContext), ISeguroRepository
{
}
