using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoSeguroRepository))]
public class TipoSeguroRepository(PeitonDbContext dbContext) : RepositoryBase<TipoSeguro>(dbContext), ITipoSeguroRepository
{
}
