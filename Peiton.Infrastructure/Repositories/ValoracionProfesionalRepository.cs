using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IValoracionProfesionalRepository))]
	public class ValoracionProfesionalRepository: RepositoryBase<ValoracionProfesional>, IValoracionProfesionalRepository
	{
		public ValoracionProfesionalRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}