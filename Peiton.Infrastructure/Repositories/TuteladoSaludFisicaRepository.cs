using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITuteladoSaludFisicaRepository))]
	public class TuteladoSaludFisicaRepository: RepositoryBase<TuteladoSaludFisica>, ITuteladoSaludFisicaRepository
	{
		public TuteladoSaludFisicaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}