using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IArchivoRepository))]
	public class ArchivoRepository: RepositoryBase<Archivo>, IArchivoRepository
	{
		public ArchivoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}