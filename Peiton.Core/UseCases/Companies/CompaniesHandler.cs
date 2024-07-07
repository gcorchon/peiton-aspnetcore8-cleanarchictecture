using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Contracts.Companies;

namespace Peiton.Core.UseCases.Companys;

[Injectable]
public class CompaniesHandler(ICompanyRepository companyRepository)
{
    public async Task<PaginatedData<Company>> HandleAsync(BuscarCompaniesFilter filter, Pagination pagination)
    {
        IEnumerable<Company> items = await companyRepository.ObtenerCompaniesAsync(pagination.Page, pagination.Total, filter);
        int total = await companyRepository.ContarCompaniesAsync(filter);

        return new PaginatedData<Company>()
        {
            Items = items,
            Total = total
        };
    }

}
