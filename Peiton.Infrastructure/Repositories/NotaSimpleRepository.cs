using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(INotaSimpleRepository))]
	public class NotaSimpleRepository: RepositoryBase<NotaSimple>, INotaSimpleRepository
	{
		public NotaSimpleRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}