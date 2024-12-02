using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITransferenciaBeneficiarioRepository))]
public class TransferenciaBeneficiarioRepository(PeitonDbContext dbContext) : RepositoryBase<TransferenciaBeneficiario>(dbContext), ITransferenciaBeneficiarioRepository
{
}
