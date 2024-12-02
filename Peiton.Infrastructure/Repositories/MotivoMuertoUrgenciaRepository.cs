using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMotivoMuertoUrgenciaRepository))]
public class MotivoMuertoUrgenciaRepository(PeitonDbContext dbContext) : RepositoryBase<MotivoMuertoUrgencia>(dbContext), IMotivoMuertoUrgenciaRepository
{
}
