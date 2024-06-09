using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICalendarioFestivosRepository))]
	public class CalendarioFestivosRepository: RepositoryBase<CalendarioFestivos>, ICalendarioFestivosRepository
	{
		public CalendarioFestivosRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}