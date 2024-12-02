using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInformeMensualRepository))]
public class InformeMensualRepository(PeitonDbContext dbContext) : RepositoryBase<InformeMensual>(dbContext), IInformeMensualRepository
{
}
