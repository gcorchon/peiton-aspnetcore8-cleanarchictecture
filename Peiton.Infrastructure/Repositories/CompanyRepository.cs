using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Companies;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICompanyRepository))]
public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<Company[]> ObtenerCompaniesAsync(int page, int total, BuscarCompaniesFilter filter)
    {
        return ApplyFilters(this.DbSet.Include(c => c.Cnae2009Navigation).ThenInclude(c => c.Categoria), filter)
            .OrderBy(c => c.RZS)
            .Skip((page - 1) * total)
            .Take(total)
            .AsNoTracking()
            .ToArrayAsync();

    }

    public Task<int> ContarCompaniesAsync(BuscarCompaniesFilter filter)
    {
        return ApplyFilters(this.DbSet.Include(c => c.Cnae2009Navigation).ThenInclude(c => c.Categoria), filter).CountAsync();
    }

    private IQueryable<Company> ApplyFilters(IQueryable<Company> query, BuscarCompaniesFilter filter)
    {
        if (filter == null) return query;

        if (!string.IsNullOrEmpty(filter.Categoria))
        {
            query = query.Where(c => c.Cnae2009Navigation.Categoria != null && c.Cnae2009Navigation.Categoria.Descripcion.Contains(filter.Categoria));
        }

        if (!string.IsNullOrEmpty(filter.CIF))
        {
            query = query.Where(c => c.CIF.StartsWith(filter.CIF));
        }

        if (!string.IsNullOrEmpty(filter.RZS))
        {
            query = query.Where(c => c.RZS.Contains(filter.RZS));
        }

        if (!string.IsNullOrEmpty(filter.DescripcionCnae2009))
        {
            query = query.Where(c => c.Cnae2009Navigation.Description.Contains(filter.DescripcionCnae2009));
        }

        return query;
    }
}
