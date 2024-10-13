using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoCuratelaRepository))]
public class TipoCuratelaRepository : RepositoryBase<TipoCuratela>, ITipoCuratelaRepository
{
	public TipoCuratelaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
