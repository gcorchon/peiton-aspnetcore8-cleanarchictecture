using Peiton.Contracts.Companies;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ICompanyRepository : IRepository<Company>
{
    Task<Company[]> ObtenerCompaniesAsync(int page, int total, BuscarCompaniesFilter filter);
    Task<int> ContarCompaniesAsync(BuscarCompaniesFilter filter);
}
