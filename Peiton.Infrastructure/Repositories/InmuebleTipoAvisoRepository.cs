using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleTipoAvisoRepository))]
public class InmuebleTipoAvisoRepository(PeitonDbContext dbContext) : RepositoryBase<InmuebleTipoAviso>(dbContext), IInmuebleTipoAvisoRepository
{
}
