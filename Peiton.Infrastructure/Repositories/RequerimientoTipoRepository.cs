using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRequerimientoTipoRepository))]
public class RequerimientoTipoRepository(PeitonDbContext dbContext) : RepositoryBase<RequerimientoTipo>(dbContext), IRequerimientoTipoRepository
{
}
