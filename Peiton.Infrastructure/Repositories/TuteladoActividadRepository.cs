using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITuteladoActividadRepository))]
	public class TuteladoActividadRepository: RepositoryBase<TuteladoActividad>, ITuteladoActividadRepository
	{
		public TuteladoActividadRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}