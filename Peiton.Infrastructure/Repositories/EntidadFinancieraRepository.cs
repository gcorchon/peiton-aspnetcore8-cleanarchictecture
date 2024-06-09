using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEntidadFinancieraRepository))]
	public class EntidadFinancieraRepository: RepositoryBase<EntidadFinanciera>, IEntidadFinancieraRepository
	{
		public EntidadFinancieraRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}