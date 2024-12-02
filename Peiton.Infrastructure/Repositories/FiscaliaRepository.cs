using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFiscaliaRepository))]
public class FiscaliaRepository(PeitonDbContext dbContext) : RepositoryBase<Fiscalia>(dbContext), IFiscaliaRepository
{
}
