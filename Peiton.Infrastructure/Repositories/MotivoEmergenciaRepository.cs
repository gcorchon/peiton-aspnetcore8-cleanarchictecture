using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMotivoEmergenciaRepository))]
public class MotivoEmergenciaRepository(PeitonDbContext dbContext) : RepositoryBase<MotivoEmergencia>(dbContext), IMotivoEmergenciaRepository
{
}
