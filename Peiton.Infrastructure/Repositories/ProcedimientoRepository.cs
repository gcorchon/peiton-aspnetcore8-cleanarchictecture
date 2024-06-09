using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IProcedimientoRepository))]
	public class ProcedimientoRepository: RepositoryBase<Procedimiento>, IProcedimientoRepository
	{
		public ProcedimientoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}