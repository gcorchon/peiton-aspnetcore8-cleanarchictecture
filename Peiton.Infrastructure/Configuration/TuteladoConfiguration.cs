using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TuteladoConfiguration : IEntityTypeConfiguration<Tutelado>
	{
		public void Configure(EntityTypeBuilder<Tutelado> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Tutelado");
			builder.Property(p => p.NumeroExpediente).HasMaxLength(12);
			builder.Property(p => p.Nombre).HasMaxLength(100);
			builder.Property(p => p.Apellido1).HasMaxLength(50);
			builder.Property(p => p.Apellido2).HasMaxLength(50);
			builder.Property(p => p.Apellidos).HasComputedColumnSql("([Apellido1]+case when [Apellido2] IS NOT NULL AND [Apellido2]<>'' then ' '+[Apellido2] else '' end)", false);
			builder.Property(p => p.DNI).HasMaxLength(50);
			builder.Property(p => p.Pasaporte).HasMaxLength(50);
			builder.Property(p => p.NacionalidadId).HasColumnName("Fk_Nacionalidad");
			builder.Property(p => p.EstadoCivilId).HasColumnName("Fk_EstadoCivil");
			builder.Property(p => p.SeguridadSocial).HasMaxLength(50);
			builder.Property(p => p.Muface).HasMaxLength(50);
			builder.Property(p => p.AbogadoId).HasColumnName("Fk_Abogado");
			builder.Property(p => p.TrabajadorSocialId).HasColumnName("Fk_TrabajadorSocial");
			builder.Property(p => p.EconomicoId).HasColumnName("Fk_Economico");
			builder.Property(p => p.EducadorSocialId).HasColumnName("Fk_EducadorSocial");
			builder.Property(p => p.Muerto).IsRequired();
			builder.Property(p => p.Sexo).HasMaxLength(0);
			builder.Property(p => p.MotivoMuertoId).HasColumnName("Fk_MotivoMuerto");
			builder.Property(p => p.CajaDecesos).HasMaxLength(50);
			builder.Property(p => p.NumeroArchivo).HasMaxLength(50);
			builder.Property(p => p.SaldoInicialCaja).IsRequired();
			builder.Property(p => p.NombreCompleto).HasComputedColumnSql("((([nombre]+' ')+[apellido1])+case when [apellido2] IS NOT NULL AND [apellido2]<>'' then ' '+[apellido2] else '' end)", false);
			builder.Property(p => p.Foto).HasMaxLength(255);
			builder.Property(p => p.CodigoGestoriaFondoTutela).HasMaxLength(50);
			builder.Property(p => p.CodigoGestoriaFondoBankia).HasMaxLength(50);
			builder.Property(p => p.Perpol).IsRequired();
			builder.Property(p => p.NombreAutorizado).HasMaxLength(50);
			builder.Property(p => p.ApellidosAutorizado).HasMaxLength(50);
			builder.Property(p => p.DNIAutorizado).HasMaxLength(50);
			builder.Property(p => p.RetribucionContinuada).IsRequired();
			builder.Property(p => p.AmbitoId).HasColumnName("Fk_Ambito");
			builder.Property(p => p.NivelSoporteId).HasColumnName("Fk_NivelSoporte");
			builder.Property(p => p.EntidadGestoraId).HasColumnName("Fk_EntidadGestora");
			builder.Property(p => p.TecnicoIntegracionSocialId).HasColumnName("Fk_TecnicoIntegracionSocial");
			builder.Property(p => p.FechaCreacion).HasDefaultValueSql("(getdate())");
			builder.Property(p => p.DatosJuridicosEstadoId).HasColumnName("Fk_DatosJuridicosEstado");
			builder.Property(p => p.ExpedienteVinculado).HasMaxLength(50);
			builder.Property(p => p.ParentescoExpedienteVinculado).HasMaxLength(50);
			builder.Property(p => p.EntidadDerivanteId).HasColumnName("Fk_EntidadDerivante");
			builder.Property(p => p.ValoracionResultadoId).HasColumnName("Fk_ValoracionResultado");
			builder.Property(p => p.ValoracionDestinatarioId).HasColumnName("Fk_ValoracionDestinatario");
			builder.Property(p => p.DerivanteEspecifico).HasMaxLength(100);
			builder.Property(p => p.ValoracionEstadoId).HasColumnName("Fk_ValoracionEstado");
			builder.Property(p => p.ValoracionMedidaPropuestaId).HasColumnName("Fk_ValoracionMedidaPropuesta");
			builder.Property(p => p.ValoracionProfesionalId).HasColumnName("Fk_ValoracionProfesional");
			builder.Property(p => p.ValoracionTutorId).HasColumnName("Fk_ValoracionTutor");
			builder.Property(p => p.InformePsicosocial);
			builder.Property(p => p.ReferenteDFId).HasColumnName("Fk_ReferenteDF");
			builder.Property(p => p.ValoracionMedidaCautelarId).HasColumnName("Fk_ValoracionMedidaCautelar");
			builder.Property(p => p.CoordinadorSocialId).HasColumnName("Fk_CoordinadorSocial");
			builder.Property(p => p.ValoracionEntradaExpedienteId).HasColumnName("Fk_ValoracionEntradaExpediente");
			builder.Property(p => p.NoBinario).IsRequired();
			builder.Property(p => p.NoTutelado).IsRequired();
			builder.Property(p => p.LugarBaja).HasMaxLength(255);
			builder.Property(p => p.MunicipioBaja).HasMaxLength(255);
			builder.Property(p => p.EquipoDefinitivo).IsRequired();
			builder.Property(p => p.SaldoInicialCaja).HasColumnType("money");

			/*builder.HasOne(d => d.CoordinadorSocial)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.CoordinadorSocialId);*/

			/*builder.HasOne(d => d.DatosJuridicosEstado)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.DatosJuridicosEstadoId);*/

			/*builder.HasOne(d => d.EntidadDerivante)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.EntidadDerivanteId);*/

			/*builder.HasOne(d => d.EntidadGestora)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.EntidadGestoraId);*/

			/*builder.HasOne(d => d.NivelSoporte)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.NivelSoporteId);*/

			/*builder.HasOne(d => d.ReferenteDF)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.ReferenteDFId);*/

			/*builder.HasOne(d => d.TecnicoIntegracionSocial)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.TecnicoIntegracionSocialId);*/

			/*builder.HasOne(d => d.Abogado)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.AbogadoId);*/

			/*builder.HasOne(d => d.Ambito)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.AmbitoId);*/

			/*builder.HasOne(d => d.Economico)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.EconomicoId);*/

			/*builder.HasOne(d => d.EducadorSocial)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.EducadorSocialId);*/

			/*builder.HasOne(d => d.EstadoCivil)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.EstadoCivilId);*/

			/*builder.HasOne(d => d.MotivoMuerto)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.MotivoMuertoId);*/

			/*builder.HasOne(d => d.Nacionalidad)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.NacionalidadId);*/

			/*builder.HasOne(d => d.TrabajadorSocial)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.TrabajadorSocialId);*/

			/*builder.HasOne(d => d.ValoracionDestinatario)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.ValoracionDestinatarioId);*/

			/*builder.HasOne(d => d.ValoracionEntradaExpediente)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.ValoracionEntradaExpedienteId);*/

			/*builder.HasOne(d => d.ValoracionEstado)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.ValoracionEstadoId);*/

			/*builder.HasOne(d => d.ValoracionMedidaCautelar)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.ValoracionMedidaCautelarId);*/

			/*builder.HasOne(d => d.ValoracionMedidaPropuesta)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.ValoracionMedidaPropuestaId);*/

			/*builder.HasOne(d => d.ValoracionProfesional)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.ValoracionProfesionalId);*/

			/*builder.HasOne(d => d.ValoracionResultado)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.ValoracionResultadoId);*/

			/*builder.HasOne(d => d.ValoracionTutor)
				.WithMany(p => p.Tutelados)
				.HasForeignKey(d => d.ValoracionTutorId);*/

			/*builder.HasMany(d => d.AdiccionesComportamentales)
				.WithMany(p => p.Tutelados)
				.UsingEntity<Dictionary<string, object>>(
			"TuteladoAdiccionComportamental",
			l => l.HasOne<AdiccionComportamental>().WithMany().HasForeignKey("Fk_AdiccionComportamental"),
			r => r.HasOne<Tutelado>().WithMany().HasForeignKey("Fk_Tutelado"),
			j =>
			{
				j.HasKey("Fk_Tutelado", "Fk_AdiccionComportamental");
				j.ToTable("TuteladoAdiccionComportamental");
				});*/

				/*builder.HasMany(d => d.AdiccionesSustancias)
					.WithMany(p => p.Tutelados)
					.UsingEntity<Dictionary<string, object>>(
				"TuteladoAdiccionSustancia",
				l => l.HasOne<AdiccionSustancia>().WithMany().HasForeignKey("Fk_AdiccionSustancia"),
				r => r.HasOne<Tutelado>().WithMany().HasForeignKey("Fk_Tutelado"),
				j =>
				{
					j.HasKey("Fk_Tutelado", "Fk_AdiccionSustancia");
					j.ToTable("TuteladoAdiccionSustancia");
					});*/

					/*builder.HasMany(d => d.ApoyosExternos)
						.WithMany(p => p.Tutelados)
						.UsingEntity<Dictionary<string, object>>(
					"TuteladoApoyoExterno",
					l => l.HasOne<ApoyoExterno>().WithMany().HasForeignKey("Fk_ApoyoExterno"),
					r => r.HasOne<Tutelado>().WithMany().HasForeignKey("Fk_Tutelado"),
					j =>
					{
						j.HasKey("Fk_Tutelado", "Fk_ApoyoExterno");
						j.ToTable("TuteladoApoyoExterno");
						});*/

						/*builder.HasMany(d => d.DiscapacidadesTipos)
							.WithMany(p => p.Tutelados)
							.UsingEntity<Dictionary<string, object>>(
						"TuteladoDiscapacidadTipo",
						l => l.HasOne<DiscapacidadTipo>().WithMany().HasForeignKey("Fk_DiscapacidadTipo"),
						r => r.HasOne<Tutelado>().WithMany().HasForeignKey("Fk_Tutelado"),
						j =>
						{
							j.HasKey("Fk_Tutelado", "Fk_DiscapacidadTipo");
							j.ToTable("TuteladoDiscapacidadTipo");
							});*/

							/*builder.HasMany(d => d.TiposCuratelas)
								.WithMany(p => p.Tutelados)
								.UsingEntity<Dictionary<string, object>>(
							"TuteladoTipoCuratelaAsistencial",
							l => l.HasOne<TipoCuratela>().WithMany().HasForeignKey("Fk_TipoCuratela"),
							r => r.HasOne<Tutelado>().WithMany().HasForeignKey("Fk_Tutelado"),
							j =>
							{
								j.HasKey("Fk_Tutelado", "Fk_TipoCuratela");
								j.ToTable("TuteladoTipoCuratelaAsistencial");
								});*/

								/*builder.HasMany(d => d.TiposCuratelas)
									.WithMany(p => p.Tutelados)
									.UsingEntity<Dictionary<string, object>>(
								"TuteladoTipoCuratelaRepresentativa",
								l => l.HasOne<TipoCuratela>().WithMany().HasForeignKey("Fk_TipoCuratela"),
								r => r.HasOne<Tutelado>().WithMany().HasForeignKey("Fk_Tutelado"),
								j =>
								{
									j.HasKey("Fk_Tutelado", "Fk_TipoCuratela");
									j.ToTable("TuteladoTipoCuratelaRepresentativa");
									});*/

									/*builder.HasMany(d => d.TiposOrientaciones)
										.WithMany(p => p.Tutelados)
										.UsingEntity<Dictionary<string, object>>(
									"TuteladoTipoOrientacion",
									l => l.HasOne<TipoOrientacion>().WithMany().HasForeignKey("Fk_TipoOrientacion"),
									r => r.HasOne<Tutelado>().WithMany().HasForeignKey("Fk_Tutelado"),
									j =>
									{
										j.HasKey("Fk_Tutelado", "Fk_TipoOrientacion");
										j.ToTable("TuteladoTipoOrientacion");
										});*/
									}
								}
							}