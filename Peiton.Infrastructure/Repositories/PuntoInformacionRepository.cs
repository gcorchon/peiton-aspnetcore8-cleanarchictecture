using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPuntoInformacionRepository))]
public class PuntoInformacionRepository(PeitonDbContext dbContext) : RepositoryBase<PuntoInformacion>(dbContext), IPuntoInformacionRepository
{
}
