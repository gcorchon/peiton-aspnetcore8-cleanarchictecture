using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILocalizacionCajaRepository))]
public class LocalizacionCajaRepository : RepositoryBase<LocalizacionCaja>, ILocalizacionCajaRepository
{
	public LocalizacionCajaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
