using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMotivoEmergenciaCentroRepository))]
public class MotivoEmergenciaCentroRepository(PeitonDbContext dbContext) : RepositoryBase<MotivoEmergenciaCentro>(dbContext), IMotivoEmergenciaCentroRepository
{
}
