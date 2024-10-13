using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDiagnosticoRepository))]
public class DiagnosticoRepository : RepositoryBase<Diagnostico>, IDiagnosticoRepository
{
	public DiagnosticoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
