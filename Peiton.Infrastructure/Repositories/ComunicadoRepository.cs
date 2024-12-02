using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IComunicadoRepository))]
public class ComunicadoRepository(PeitonDbContext dbContext) : RepositoryBase<Comunicado>(dbContext), IComunicadoRepository
{
}
