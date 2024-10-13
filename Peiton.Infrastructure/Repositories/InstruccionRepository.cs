using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInstruccionRepository))]
public class InstruccionRepository : RepositoryBase<Instruccion>, IInstruccionRepository
{
	public InstruccionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
