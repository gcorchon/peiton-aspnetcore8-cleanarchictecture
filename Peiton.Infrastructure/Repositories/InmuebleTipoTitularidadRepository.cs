using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleTipoTitularidadRepository))]
public class InmuebleTipoTitularidadRepository(PeitonDbContext dbContext) : RepositoryBase<InmuebleTipoTitularidad>(dbContext), IInmuebleTipoTitularidadRepository
{
}
