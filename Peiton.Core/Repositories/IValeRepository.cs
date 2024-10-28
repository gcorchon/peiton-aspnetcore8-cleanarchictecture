using Peiton.Contracts.Vales;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IValeRepository : IRepository<Vale>
{
	Task<Vale[]> ObtenerValesAsync(int page, int total, ValesFilter filter);
	Task<int> ContarValesAsync(ValesFilter filter);
}
