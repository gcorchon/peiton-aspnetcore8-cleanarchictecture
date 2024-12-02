using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoCuratelaRepository))]
public class TipoCuratelaRepository(PeitonDbContext dbContext) : RepositoryBase<TipoCuratela>(dbContext), ITipoCuratelaRepository
{
}
