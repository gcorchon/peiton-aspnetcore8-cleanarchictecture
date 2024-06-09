using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEntidadGestoraRepository))]
	public class EntidadGestoraRepository: RepositoryBase<EntidadGestora>, IEntidadGestoraRepository
	{
		public EntidadGestoraRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}