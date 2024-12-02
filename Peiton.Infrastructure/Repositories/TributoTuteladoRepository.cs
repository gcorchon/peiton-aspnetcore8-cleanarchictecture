using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITributoTuteladoRepository))]
public class TributoTuteladoRepository(PeitonDbContext dbContext) : RepositoryBase<TributoTutelado>(dbContext), ITributoTuteladoRepository
{
}
