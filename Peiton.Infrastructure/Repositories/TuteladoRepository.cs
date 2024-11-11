using System.Text.RegularExpressions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Tutelados;
using Peiton.Contracts.Usuarios;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoRepository))]
public class TuteladoRepository : RepositoryBase<Tutelado>, ITuteladoRepository
{
	private readonly IIdentityService identityService;
	public TuteladoRepository(PeitonDbContext dbContext, IIdentityService identityService) : base(dbContext)
	{
		this.identityService = identityService;
	}
	public async Task<Tutelado[]> ObtenerTuteladosAsync(int page, int total, TuteladosFilter filter)
	{
		var profile = await identityService.GetUserProfileAsync();
		if (profile.Perfil == 3) return [];

		return await ApplyFilters(DbSet, filter, profile)
				.OrderBy(t => t.Apellidos).ThenBy(t => t.Nombre)
				.Skip((page - 1) * total)
				.Take(total)
				.AsNoTracking()
				.ToArrayAsync();
	}

	public async Task<int> ContarTuteladosAsync(TuteladosFilter filter)
	{
		var profile = await identityService.GetUserProfileAsync();
		if (profile.Perfil == 3) return 0;
		return await ApplyFilters(DbSet, filter, profile).CountAsync();
	}

	private IQueryable<Tutelado> ApplyFilters(IQueryable<Tutelado> query, TuteladosFilter filter, Info profile)
	{
		query = query.Include(t => t.DatosJuridicos).Include("DatosJuridicos.Nombramiento");

		if (profile.Perfil == 2)
		{
			var predicate = PredicateBuilder.New<Tutelado>();

			if (profile.AbogadoChecked && profile.Abogado.HasValue)
			{
				predicate.Or(t => t.AbogadoId == profile.Abogado);
			}

			if (profile.EconomicoChecked && profile.Economico.HasValue)
			{
				predicate.Or(t => t.EconomicoId == profile.Economico);
			}

			if (profile.TrabajadorChecked && profile.Trabajador.HasValue)
			{
				predicate.Or(t => t.TrabajadorSocialId == profile.Trabajador);
			}

			if (profile.EducadorChecked && profile.Educador.HasValue)
			{
				predicate.Or(t => t.EducadorSocialId == profile.Educador);
			}

			if (profile.TecnicoIntegracionSocialChecked && profile.TecnicoIntegracionSocial.HasValue)
			{
				predicate.Or(t => t.TecnicoIntegracionSocialId == profile.TecnicoIntegracionSocial);
			}

			if (profile.CentroChecked && profile.Centro.HasValue)
			{
				//query = query.Include(t => t.ResidenciaHabitual);
				predicate.Or(t => t.ResidenciaHabitual != null && t.ResidenciaHabitual.Tipo == "C" && t.ResidenciaHabitual.CentroId == profile.Centro);
			}

			if (profile.AmasChecked)
			{
				//query = query.Include(t => t.ResidenciaHabitual);
				predicate.Or(t => t.ResidenciaHabitual != null && t.ResidenciaHabitual.Tipo == "C" && t.ResidenciaHabitual.Centro != null && t.ResidenciaHabitual.Centro.Amas);
			}

			if (profile.CentroDiaChecked && profile.CentroDia.HasValue)
			{
				predicate.Or(t => t.ApoyosFormales.Any(a => a.CentroId == profile.CentroDia));
			}

			if (profile.CentroOcupacionalChecked && profile.CentroOcupacional.HasValue)
			{
				predicate.Or(t => t.DatosSociales != null && t.DatosSociales.CentroOcupacionalAMASId == profile.CentroOcupacional);
			}

			if (profile.AbogadoExternoChecked && profile.AbogadoExterno.HasValue)
			{
				predicate.Or(t => t.ProcedimientosAdicionales.Any(p => !p.Terminado && p.AbogadoExternoId == profile.AbogadoExterno));
				predicate.Or(t => t.OtrosAsuntos.Any(p => p.Terminado.HasValue && !p.Terminado.Value && p.AbogadoExternoId == profile.AbogadoExterno));
			}

			if (profile.ContigoAppChecked)
			{
				predicate.Or(t => t.AppMovilTutelados.Any());
			}

			query = query.Where(predicate);

			if (profile.Muertos)
			{
				query = query.Where(t => !t.Muerto);
			}
		}

		if (!string.IsNullOrWhiteSpace(filter.NumeroExpediente))
		{
			query = query.Where(s => s.NumeroExpediente.Contains(filter.NumeroExpediente));
		}

		if (!string.IsNullOrWhiteSpace(filter.NombreCompleto))
		{
			query = query.Where(t => t.NombreCompleto!.Contains(filter.NombreCompleto));
		}

		if (!string.IsNullOrWhiteSpace(filter.Cargo))
		{
			query = query.Where(t => t.DatosJuridicos != null && t.DatosJuridicos.Nombramiento != null && t.DatosJuridicos.Nombramiento.Descripcion.Contains(filter.Cargo));
		}

		if (!string.IsNullOrWhiteSpace(filter.DNI))
		{
			query = query.Where(s => s.DNI != null && s.DNI.Contains(filter.DNI));
		}

		if (!string.IsNullOrWhiteSpace(filter.Query))
		{
			if (Regex.IsMatch(filter.Query, @"^\d{5}/\d{4}$"))
			{
				query = query.Where(t => t.NumeroExpediente == filter.Query);
			}
			else
			{
				query = query.Where(t => t.DNI == filter.Query || (t.NombreCompleto != null && t.NombreCompleto.Contains(filter.Query)));
			}
		}

		return query;

	}

	public Task<Tutelado[]> ObtenerTuteladosParaReintegrosAsync(string text)
	{
		return DbSet
				.Include(t => t.Credenciales.Where(c => !c.Baja))
				.ThenInclude(c => c.Accounts.Where(a => !a.Baja))
				.Where(t => !t.Muerto && t.NombreCompleto!.Contains(text))
				.OrderBy(t => t.NombreCompleto)
				.Take(10)
				.ToArrayAsync();

	}

	public Task<Tutelado[]> ObtenerTuteladosPorNombreAsync(string query, int total)
	{
		return DbSet.Where(t => t.NombreCompleto!.Contains(query)).OrderBy(t => t.NombreCompleto).Take(total).AsNoTracking().ToArrayAsync();

	}
}
