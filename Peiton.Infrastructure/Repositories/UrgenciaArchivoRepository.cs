using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IUrgenciaArchivoRepository))]
	public class UrgenciaArchivoRepository: RepositoryBase<UrgenciaArchivo>, IUrgenciaArchivoRepository
	{
		public UrgenciaArchivoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}