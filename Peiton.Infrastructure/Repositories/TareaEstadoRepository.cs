using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaEstadoRepository))]
public class TareaEstadoRepository(PeitonDbContext dbContext) : RepositoryBase<TareaEstado>(dbContext), ITareaEstadoRepository
{
}
