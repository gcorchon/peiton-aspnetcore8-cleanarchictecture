using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITransferenciaBeneficiarioCuentaRepository))]
	public class TransferenciaBeneficiarioCuentaRepository: RepositoryBase<TransferenciaBeneficiarioCuenta>, ITransferenciaBeneficiarioCuentaRepository
	{
		public TransferenciaBeneficiarioCuentaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}