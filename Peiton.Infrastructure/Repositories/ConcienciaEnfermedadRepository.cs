using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IConcienciaEnfermedadRepository))]
	public class ConcienciaEnfermedadRepository: RepositoryBase<ConcienciaEnfermedad>, IConcienciaEnfermedadRepository
	{
		public ConcienciaEnfermedadRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}