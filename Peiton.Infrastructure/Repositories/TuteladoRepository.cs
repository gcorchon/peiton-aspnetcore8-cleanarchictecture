using System.Text.RegularExpressions;
using Dapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Common;
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

	public override async Task<Tutelado?> GetByIdAsync(int id)
	{
		var visible = await CanViewAsync(id);
		if (!visible) throw new UnauthorizedAccessException("No tienes permiso para ver los datos del tutelado");
		return await base.GetByIdAsync(id);
	}

	public async Task<bool> CanViewAsync(int id)
	{
		var profile = await identityService.GetUserProfileAsync();

		if (profile.Perfil == 3) return false;
		var tutelado = await base.GetByIdAsync(id);

		if (tutelado == null) return true;

		if (tutelado.Muerto && profile.Muertos) return false;

		if (profile.Perfil == 2)
		{
			return (profile.AbogadoChecked && profile.Abogado.HasValue && profile.Abogado == tutelado.AbogadoId)
			 || (profile.EconomicoChecked && profile.Economico.HasValue && profile.Economico == tutelado.EconomicoId)
			 || (profile.TrabajadorChecked && profile.Trabajador.HasValue && profile.Trabajador == tutelado.TrabajadorSocialId)
			 || (profile.EducadorChecked && profile.Educador.HasValue && profile.Educador == tutelado.EducadorSocialId)
			 || (profile.TecnicoIntegracionSocialChecked && profile.TecnicoIntegracionSocial.HasValue && profile.TecnicoIntegracionSocial == tutelado.TecnicoIntegracionSocialId)
			 || (profile.CentroChecked && profile.Centro.HasValue && tutelado.ResidenciaHabitual != null && tutelado.ResidenciaHabitual.Tipo == "C" && tutelado.ResidenciaHabitual.CentroId == profile.Centro)
			 || (profile.AmasChecked && tutelado.ResidenciaHabitual != null && tutelado.ResidenciaHabitual.Tipo == "C" && tutelado.ResidenciaHabitual.Centro != null && tutelado.ResidenciaHabitual.Centro.Amas)
			 || (profile.CentroDiaChecked && profile.CentroDia.HasValue && tutelado.ApoyosFormales.Any(apoyo => apoyo.CentroId == profile.CentroDia.Value))
			 || (profile.CentroOcupacionalChecked && profile.CentroOcupacional.HasValue && tutelado.DatosSociales != null && tutelado.DatosSociales.CentroOcupacionalAMASId == profile.CentroOcupacional)
			 || (profile.AbogadoExternoChecked && profile.AbogadoExterno.HasValue &&
										(tutelado.ProcedimientosAdicionales.Any(p => !p.Terminado && p.AbogadoExternoId == profile.AbogadoExterno) ||
										 tutelado.OtrosAsuntos.Any(p => p.Terminado.HasValue && !p.Terminado.Value && p.AbogadoExternoId == profile.AbogadoExterno)))
			 || (profile.ContigoAppChecked && tutelado.AppMovilTutelados.Any());
		}

		return profile.Perfil == 1;
	}
	public async Task<bool> CanModifyAsync(int id)
	{
		var profile = await identityService.GetUserProfileAsync();

		if (profile.PerfilEdit == 3) throw new UnauthorizedAccessException("No tienes permiso para editar los datos del tutelado");
		var tutelado = await base.GetByIdAsync(id);

		if (tutelado == null) return true;

		if (tutelado.Muerto && profile.Muertos) throw new UnauthorizedAccessException("No tienes permiso para editar los datos del tutelado");

		if (profile.PerfilEdit == 2)
		{
			var visible = (profile.AbogadoEditChecked && profile.AbogadoEdit.HasValue && profile.AbogadoEdit == tutelado.AbogadoId)
			 || (profile.EconomicoEditChecked && profile.EconomicoEdit.HasValue && profile.EconomicoEdit == tutelado.EconomicoId)
			 || (profile.TrabajadorEditChecked && profile.TrabajadorEdit.HasValue && profile.TrabajadorEdit == tutelado.TrabajadorSocialId)
			 || (profile.EducadorEditChecked && profile.EducadorEdit.HasValue && profile.EducadorEdit == tutelado.EducadorSocialId)
			 || (profile.TecnicoIntegracionSocialEditChecked && profile.TecnicoIntegracionSocialEdit.HasValue && profile.TecnicoIntegracionSocialEdit == tutelado.TecnicoIntegracionSocialId)
			 || (profile.CentroEditChecked && profile.CentroEdit.HasValue && tutelado.ResidenciaHabitual != null && tutelado.ResidenciaHabitual.Tipo == "C" && tutelado.ResidenciaHabitual.CentroId == profile.CentroEdit)
			 || (profile.AmasEditChecked && tutelado.ResidenciaHabitual != null && tutelado.ResidenciaHabitual.Tipo == "C" && tutelado.ResidenciaHabitual.Centro != null && tutelado.ResidenciaHabitual.Centro.Amas)
			 || (profile.CentroDiaEditChecked && profile.CentroDiaEdit.HasValue && tutelado.ApoyosFormales.Any(apoyo => apoyo.CentroId == profile.CentroDiaEdit.Value))
			 || (profile.CentroOcupacionalEditChecked && profile.CentroOcupacionalEdit.HasValue && tutelado.DatosSociales != null && tutelado.DatosSociales.CentroOcupacionalAMASId == profile.CentroOcupacional)
			 || (profile.AbogadoExternoEditChecked && profile.AbogadoExternoEdit.HasValue &&
										(tutelado.ProcedimientosAdicionales.Any(p => !p.Terminado && p.AbogadoExternoId == profile.AbogadoExternoEdit) ||
										 tutelado.OtrosAsuntos.Any(p => p.Terminado.HasValue && !p.Terminado.Value && p.AbogadoExternoId == profile.AbogadoExternoEdit)))
			 || (profile.ContigoAppEditChecked && tutelado.AppMovilTutelados.Any());


			return visible;
		}

		return profile.PerfilEdit == 1;
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
		}

		if (profile.Muertos)
		{
			query = query.Where(t => !t.Muerto);
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


	public Task<IEnumerable<ListItem>> ObtenerEquipoAsync(int tuteladoId)
	{
		var sql = @"select Pk_Usuario as Value, NombreCompleto as Text from (
					select Usuario.Pk_Usuario, Usuario.NombreCompleto
					from Usuario inner join TrabajadorSocial on TrabajadorSocial.Nombre = Usuario.NombreCompleto
					inner join Tutelado on Tutelado.Fk_TrabajadorSocial = Pk_TrabajadorSocial
					where Pk_Tutelado = @TuteladoId
					union
					select Usuario.Pk_Usuario, Usuario.NombreCompleto
					from Usuario inner join Abogado on Abogado.Nombre = Usuario.NombreCompleto
					inner join Tutelado on Tutelado.Fk_Abogado = Pk_Abogado
					where Pk_Tutelado = @TuteladoId
					union
					select Usuario.Pk_Usuario, Usuario.NombreCompleto
					from Usuario inner join Economico on Economico.Nombre = Usuario.NombreCompleto
					inner join Tutelado on Tutelado.Fk_Economico = Pk_Economico
					where Pk_Tutelado = @TuteladoId
					union
					select Usuario.Pk_Usuario, Usuario.NombreCompleto
					from Usuario inner join TecnicoIntegracionSocial on TecnicoIntegracionSocial.Nombre = Usuario.NombreCompleto
					inner join Tutelado on Tutelado.Fk_TecnicoIntegracionSocial = Pk_TecnicoIntegracionSocial
					where Pk_Tutelado = @TuteladoId
					union
					select Usuario.Pk_Usuario, Usuario.NombreCompleto
					from Usuario inner join EducadorSocial on EducadorSocial.Nombre = Usuario.NombreCompleto
					inner join Tutelado on Tutelado.Fk_EducadorSocial = Pk_EducadorSocial
					where Pk_Tutelado = @TuteladoId
					union
					select Usuario.Pk_Usuario, Usuario.NombreCompleto
					from Usuario inner join CoordinadorSocial on CoordinadorSocial.Nombre = Usuario.NombreCompleto
					inner join Tutelado on Tutelado.Fk_CoordinadorSocial = Pk_CoordinadorSocial
					where Pk_Tutelado = @TuteladoId
					union
					select Usuario.Pk_Usuario, Usuario.NombreCompleto
					from Usuario inner join ReferenteDF on ReferenteDF.Descripcion = Usuario.NombreCompleto
					inner join Tutelado on Tutelado.Fk_ReferenteDF = Pk_ReferenteDF
					where Pk_Tutelado = @TuteladoId) dv";

		return DbContext.Database.GetDbConnection().QueryAsync<ListItem>(sql, new { TuteladoId = tuteladoId });
	}
}
