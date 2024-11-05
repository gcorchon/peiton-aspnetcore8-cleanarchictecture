using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Mensajes;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMensajeRepository))]
public class MensajeRepository : RepositoryBase<Mensaje>, IMensajeRepository
{
	private readonly IIdentityService identityService;
	public MensajeRepository(PeitonDbContext dbContext, IIdentityService identityService) : base(dbContext)
	{
		this.identityService = identityService;
	}

	public override Task<Mensaje?> GetByIdAsync(int id)
	{
		return DbSet.FirstOrDefaultAsync(m => m.Id == id && m.Usuario_ParaId == identityService.GetUserId());
	}

	public Task<int> ContarMensajesAsync(MensajesFilter filter)
	{
		return ApplyFilters(DbSet.Include(m => m.UsuarioDe).Where(m => m.Usuario_ParaId == identityService.GetUserId()), filter).CountAsync();
	}

	public Task<Mensaje[]> ObtenerMensajesAsync(int page, int total, MensajesFilter filter)
	{
		return ApplyFilters(DbSet.Include(m => m.UsuarioDe).Where(m => m.Usuario_ParaId == identityService.GetUserId()), filter)
			.OrderByDescending(s => s.Id)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	private IQueryable<Mensaje> ApplyFilters(IQueryable<Mensaje> query, MensajesFilter filter)
	{
		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.Persona))
		{
			query = query.Where(s => s.UsuarioPara.NombreCompleto.Contains(filter.Persona));
		}

		if (!string.IsNullOrWhiteSpace(filter.Asunto))
		{
			query = query.Where(s => s.Asunto.Contains(filter.Asunto));
		}

		if (!string.IsNullOrWhiteSpace(filter.Fecha))
		{
			query = query.Where(s => DbContext.DateAsString(s.Fecha).StartsWith(filter.Fecha));
		}

		if (filter.Dias.HasValue)
		{
			query = query.Where(s => s.Dias == filter.Dias.Value);
		}

		if (!string.IsNullOrWhiteSpace(filter.Estado))
		{
			if (filter.Estado == "Pendiente")
			{
				query = query.Where(s => !s.Leido);
			}

			if (filter.Estado == "Leido")
			{
				query = query.Where(s => s.Leido);
			}

			if (filter.Estado == "Archivado")
			{
				query = query.Where(s => s.Archivado);
			}
		}

		return query;
	}
}
