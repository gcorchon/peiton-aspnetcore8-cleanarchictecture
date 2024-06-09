using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IResidenciaHabitualHistoricoRepository))]
	public class ResidenciaHabitualHistoricoRepository: RepositoryBase<ResidenciaHabitualHistorico>, IResidenciaHabitualHistoricoRepository
	{
		public ResidenciaHabitualHistoricoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}