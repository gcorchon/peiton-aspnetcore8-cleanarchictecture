using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDatosEconomicosCajaRepository))]
public class DatosEconomicosCajaRepository(PeitonDbContext dbContext) : RepositoryBase<DatosEconomicosCaja>(dbContext), IDatosEconomicosCajaRepository
{
}
