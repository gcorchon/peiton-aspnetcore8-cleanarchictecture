using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMotivoEntradaRepository))]
public class MotivoEntradaRepository(PeitonDbContext dbContext) : RepositoryBase<MotivoEntrada>(dbContext), IMotivoEntradaRepository
{
}
