using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDuracionLaboralFormativaRepository))]
public class DuracionLaboralFormativaRepository(PeitonDbContext dbContext) : RepositoryBase<DuracionLaboralFormativa>(dbContext), IDuracionLaboralFormativaRepository
{
}
