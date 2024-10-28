using Peiton.Contracts.CNAEs;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ICNAERepository : IRepository<CNAE>
{
    Task<CNAEViewModel[]> ObtenerCNAEsAsync(int page, int total, ObtenerCNAEsFilter filter);
    Task<int> ContarCNAEsAsync(ObtenerCNAEsFilter filter);
}
