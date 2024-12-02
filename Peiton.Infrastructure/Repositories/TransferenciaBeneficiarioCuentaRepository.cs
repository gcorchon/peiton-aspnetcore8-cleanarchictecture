using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITransferenciaBeneficiarioCuentaRepository))]
public class TransferenciaBeneficiarioCuentaRepository(PeitonDbContext dbContext) : RepositoryBase<TransferenciaBeneficiarioCuenta>(dbContext), ITransferenciaBeneficiarioCuentaRepository
{
}
