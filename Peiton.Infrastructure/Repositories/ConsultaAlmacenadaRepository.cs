using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Consultas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IConsultaAlmacenadaRepository))]
	public class ConsultaAlmacenadaRepository: RepositoryBase<ConsultaAlmacenada>, IConsultaAlmacenadaRepository
	{
		public ConsultaAlmacenadaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}

        public Task<List<ConsultaListItem>> ObtenerConsultas(int usuarioId, ConsultasFilter filter)
        {
            return ApplyFilters(DbContext.ObtenerConsultasAlmacenadas(usuarioId), filter)
                    .OrderBy(c => c.Descripcion)
                    .AsNoTracking()
                    .ToListAsync();
        }

        private IQueryable<ConsultaListItem> ApplyFilters(IQueryable<ConsultaListItem> query, ConsultasFilter filter) {
            if (filter == null) return query;

            if (!string.IsNullOrEmpty(filter.Id))
            {
                query = query.Where(c => DbContext.IntAsString(c.Id).StartsWith(filter.Id));
            }

            if (!string.IsNullOrEmpty(filter.Descripcion))
            {
                query = query.Where(c => c.Descripcion.Contains(filter.Descripcion));
            }

            if (!string.IsNullOrEmpty(filter.Categoria))
            {
                query = query.Where(c => c.Categoria.Contains(filter.Categoria));
            }

            if (!string.IsNullOrEmpty(filter.Usuarios))
            {
                query = query.Where(c => c.Usuarios != null && c.Usuarios.Contains(filter.Usuarios));
            }

            return query;
        }
    }
}