using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IReferenteDFRepository))]
public class ReferenteDFRepository(PeitonDbContext dbContext) : RepositoryBase<ReferenteDF>(dbContext), IReferenteDFRepository
{
}
