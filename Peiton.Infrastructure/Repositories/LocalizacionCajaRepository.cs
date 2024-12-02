using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILocalizacionCajaRepository))]
public class LocalizacionCajaRepository(PeitonDbContext dbContext) : RepositoryBase<LocalizacionCaja>(dbContext), ILocalizacionCajaRepository
{
}
