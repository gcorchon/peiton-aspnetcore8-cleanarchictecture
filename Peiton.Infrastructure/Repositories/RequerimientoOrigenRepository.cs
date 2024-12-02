using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRequerimientoOrigenRepository))]
public class RequerimientoOrigenRepository(PeitonDbContext dbContext) : RepositoryBase<RequerimientoOrigen>(dbContext), IRequerimientoOrigenRepository
{
}
