using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITransferenciaBeneficiarioRepository))]
	public class TransferenciaBeneficiarioRepository: RepositoryBase<TransferenciaBeneficiario>, ITransferenciaBeneficiarioRepository
	{
		public TransferenciaBeneficiarioRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}