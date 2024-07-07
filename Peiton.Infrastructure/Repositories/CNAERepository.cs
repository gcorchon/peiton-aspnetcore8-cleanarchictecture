using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.CNAEs;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICNAERepository))]
	public class CNAERepository: RepositoryBase<CNAE>, ICNAERepository
	{
		public CNAERepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}

        public Task<int> ContarCNAEsAsync(ObtenerCNAEsFilter filter)
        {
            var query = from cnae in DbSet
                        join vwCategoria in this.DbContext.VwCategoria on cnae.CategoriaId equals vwCategoria.Id into gj
                        from categoria in gj.DefaultIfEmpty()
                        select new CNAEViewModel()
                        {
                            Cnae2009 = cnae.Cnae2009,
                            Description = cnae.Description,
                            Categoria = categoria != null ? new ListItem()
                            {
                                Value = categoria.Id,
                                Text = categoria.BreadCrumb
                            } : null
                        };

            return ApplyFilters(query, filter)
                    .CountAsync();
        }

        public Task<List<CNAEViewModel>> ObtenerCNAEsAsync(int page, int total, ObtenerCNAEsFilter filter)
        {
            var query = from cnae in DbSet
                        join vwCategoria in this.DbContext.VwCategoria on cnae.CategoriaId equals vwCategoria.Id into gj
                        from categoria in gj.DefaultIfEmpty()
                        select new CNAEViewModel()
                        {
                            Cnae2009 = cnae.Cnae2009,
                            Description = cnae.Description,
                            Categoria = categoria != null ? new ListItem()
                            {
                                Value = categoria.Id,
                                Text = categoria.BreadCrumb
                            } : null
                        };

            return ApplyFilters(query, filter)
                    .OrderBy(c => c.Description)
                    .Skip((page - 1) * total)
                    .Take(total)
                    .AsNoTracking()
                    .ToListAsync();
        }

        private IQueryable<CNAEViewModel> ApplyFilters(IQueryable<CNAEViewModel> query, ObtenerCNAEsFilter filter)
        {
            if (filter == null) return query;

            if (!string.IsNullOrEmpty(filter.DescripcionCnae2009))
            {
                query = query.Where(c => c.Description.Contains(filter.DescripcionCnae2009));
            }

            if(!string.IsNullOrWhiteSpace(filter.Categoria))
            {
                query = query.Where(c => c.Categoria != null && c.Categoria.Text.Contains(filter.Categoria));
            }

            return query;
        }


    }
}