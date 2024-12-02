using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoLaboralFormativaRepository))]
public class TipoLaboralFormativaRepository(PeitonDbContext dbContext) : RepositoryBase<TipoLaboralFormativa>(dbContext), ITipoLaboralFormativaRepository
{
}
