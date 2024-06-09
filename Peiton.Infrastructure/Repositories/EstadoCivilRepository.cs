using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEstadoCivilRepository))]
	public class EstadoCivilRepository: RepositoryBase<EstadoCivil>, IEstadoCivilRepository
	{
		public EstadoCivilRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}