using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Mensajes;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMensajeEnviadoRepository))]
public class MensajeEnviadoRepository : RepositoryBase<MensajeEnviado>, IMensajeEnviadoRepository
{
	private readonly IIdentityService identityService;
	public MensajeEnviadoRepository(PeitonDbContext dbContext, IIdentityService identityService) : base(dbContext)
	{
		this.identityService = identityService;
	}

	public override Task<MensajeEnviado?> GetByIdAsync(int id)
	{
		return DbSet.FirstOrDefaultAsync(m => m.Id == id && m.Usuario_DeId == identityService.GetUserId());
	}

	public Task<int> ContarMensajesAsync(MensajesFilter filter)
	{
		return ApplyFilters(DbSet.Include(m => m.UsuarioDe).Where(m => m.Usuario_DeId == identityService.GetUserId()), filter).CountAsync();
	}

	public Task<MensajeEnviado[]> ObtenerMensajesAsync(int page, int total, MensajesFilter filter)
	{
		return ApplyFilters(DbSet.Include(m => m.UsuarioDe).Where(m => m.Usuario_DeId == identityService.GetUserId()), filter)
			.OrderByDescending(s => s.Id)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	private IQueryable<MensajeEnviado> ApplyFilters(IQueryable<MensajeEnviado> query, MensajesFilter filter)
	{
		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.Persona))
		{
			//Para contiene un JSON... en SQL Server 2014 no tengo una forma sencilla de consultarlo de forma eficiente.
			query = query.Where(s => s.Para.Contains(filter.Persona));
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

		return query;
	}
}
