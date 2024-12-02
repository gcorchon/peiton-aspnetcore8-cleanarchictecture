using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFormaPagoRepository))]
public class FormaPagoRepository(PeitonDbContext dbContext) : RepositoryBase<FormaPago>(dbContext), IFormaPagoRepository
{
}
