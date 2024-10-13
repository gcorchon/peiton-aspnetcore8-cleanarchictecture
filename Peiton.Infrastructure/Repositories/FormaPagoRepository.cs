using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFormaPagoRepository))]
public class FormaPagoRepository : RepositoryBase<FormaPago>, IFormaPagoRepository
{
	public FormaPagoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
