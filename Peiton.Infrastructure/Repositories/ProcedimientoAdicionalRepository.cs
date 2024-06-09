using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IProcedimientoAdicionalRepository))]
	public class ProcedimientoAdicionalRepository: RepositoryBase<ProcedimientoAdicional>, IProcedimientoAdicionalRepository
	{
		public ProcedimientoAdicionalRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}