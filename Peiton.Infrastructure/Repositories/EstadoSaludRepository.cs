using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEstadoSaludRepository))]
	public class EstadoSaludRepository: RepositoryBase<EstadoSalud>, IEstadoSaludRepository
	{
		public EstadoSaludRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}