using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleTipoAutorizacionRepository))]
public class InmuebleTipoAutorizacionRepository(PeitonDbContext dbContext) : RepositoryBase<InmuebleTipoAutorizacion>(dbContext), IInmuebleTipoAutorizacionRepository
{
}
