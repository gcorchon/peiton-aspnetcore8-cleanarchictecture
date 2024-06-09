using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IQuejaTipoDenuncianteRepository))]
	public class QuejaTipoDenuncianteRepository: RepositoryBase<QuejaTipoDenunciante>, IQuejaTipoDenuncianteRepository
	{
		public QuejaTipoDenuncianteRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}