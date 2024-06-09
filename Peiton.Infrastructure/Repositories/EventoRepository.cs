using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEventoRepository))]
	public class EventoRepository: RepositoryBase<Evento>, IEventoRepository
	{
		public EventoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}