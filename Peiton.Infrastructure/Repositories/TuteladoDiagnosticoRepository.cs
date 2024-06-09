using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITuteladoDiagnosticoRepository))]
	public class TuteladoDiagnosticoRepository: RepositoryBase<TuteladoDiagnostico>, ITuteladoDiagnosticoRepository
	{
		public TuteladoDiagnosticoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}