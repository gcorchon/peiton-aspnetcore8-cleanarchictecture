using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DatosSocialesConfiguration : IEntityTypeConfiguration<DatosSociales>
	{
		public void Configure(EntityTypeBuilder<DatosSociales> builder)
		{
			builder.HasKey(t => t.TuteladoId);

			builder.Property(p => p.TuteladoId).ValueGeneratedNever().HasColumnName("Fk_Tutelado");
			builder.Property(p => p.GradoDiscapacidad).HasMaxLength(10);
			builder.Property(p => p.DependenciaId).HasColumnName("Fk_Dependencia");
			builder.Property(p => p.LugarResidenciaId).HasColumnName("Fk_LugarResidencia");
			builder.Property(p => p.TipoRelacionFamiliarId).HasColumnName("Fk_TipoRelacionFamiliar");
			builder.Property(p => p.RelacionAMTAVisitaId).HasColumnName("Fk_RelacionAMTAVisita");
			builder.Property(p => p.RelacionAMTAContactoId).HasColumnName("Fk_RelacionAMTAContacto");
			builder.Property(p => p.EstadoSaludId).HasColumnName("Fk_EstadoSalud");
			builder.Property(p => p.AdaptacionCentroId).HasColumnName("Fk_AdaptacionCentro");
			builder.Property(p => p.RelacionCentroResidentesId).HasColumnName("Fk_RelacionCentroResidentes");
			builder.Property(p => p.RelacionCentroProfesionalesId).HasColumnName("Fk_RelacionCentroProfesionales");
			builder.Property(p => p.InformeSocialEnBlanco).IsRequired();
			builder.Property(p => p.CentroOcupacionalAMASId).HasColumnName("Fk_CentroOcupacionalAMAS");
			builder.Property(p => p.PiaId).HasColumnName("Fk_Pia");
			builder.Property(p => p.DiscapacidadId).HasColumnName("Fk_Discapacidad");
			builder.Property(p => p.OrientacionId).HasColumnName("Fk_Orientacion");
			builder.Property(p => p.SituacionSaludId).HasColumnName("Fk_SituacionSalud");
			builder.Property(p => p.HabilidadPracticaAlimentacionId).HasColumnName("Fk_HabilidadPracticaAlimentacion");
			builder.Property(p => p.HabilidadPracticaHigienePersonalId).HasColumnName("Fk_HabilidadPracticaHigienePersonal");
			builder.Property(p => p.HabilidadPracticaVestidoId).HasColumnName("Fk_HabilidadPracticaVestido");
			builder.Property(p => p.HabilidadPracticaTareaDomesticaId).HasColumnName("Fk_HabilidadPracticaTareaDomestica");
			builder.Property(p => p.HabilidadPracticaSolicitarAsistenciaId).HasColumnName("Fk_HabilidadPracticaSolicitarAsistencia");
			builder.Property(p => p.HabilidadPracticaAplicarseMedidasTerapeuticasId).HasColumnName("Fk_HabilidadPracticaAplicarseMedidasTerapeuticas");
			builder.Property(p => p.HabilidadPracticaEvitarSituacionesRiesgoId).HasColumnName("Fk_HabilidadPracticaEvitarSituacionesRiesgo");
			builder.Property(p => p.HabilidadPracticaPedirAyudaUrgenciaId).HasColumnName("Fk_HabilidadPracticaPedirAyudaUrgencia");
			builder.Property(p => p.HabilidadPracticaDesplazamientoDentroDelHogarId).HasColumnName("Fk_HabilidadPracticaDesplazamientoDentroDelHogar");
			builder.Property(p => p.HabilidadPracticaDesplazamientoFueraDelHogarId).HasColumnName("Fk_HabilidadPracticaDesplazamientoFueraDelHogar");
			builder.Property(p => p.HabilidadPracticaDesplazamientoTransportePublicoId).HasColumnName("Fk_HabilidadPracticaDesplazamientoTransportePublico");
			builder.Property(p => p.FormativaAutonomiaFormativaId).HasColumnName("Fk_FormativaAutonomiaFormativa");
			builder.Property(p => p.TipoLaboralFormativaId).HasColumnName("Fk_TipoLaboralFormativa");
			builder.Property(p => p.DuracionLaboralFormativaId).HasColumnName("Fk_DuracionLaboralFormativa");
			builder.Property(p => p.LaboralAutonomiaFormativaId).HasColumnName("Fk_LaboralAutonomiaFormativa");
			builder.Property(p => p.OcioAutonomiaFormativaId).HasColumnName("Fk_OcioAutonomiaFormativa");
			builder.Property(p => p.TipoResidenciaId).HasColumnName("Fk_TipoResidencia");
			builder.Property(p => p.TipoCentroDeDiaId).HasColumnName("Fk_TipoCentroDeDia");

			builder.HasOne(d => d.Tutelado)
				.WithOne(p => p.DatosSociales)
				.HasForeignKey<DatosSociales>(t => t.TuteladoId);

			/*builder.HasOne(d => d.AdaptacionCentro)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.AdaptacionCentroId);*/

			/*builder.HasOne(d => d.CentroOcupacionalAMAS)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.CentroOcupacionalAMASId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.Dependencia)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.DependenciaId);*/

			/*builder.HasOne(d => d.EstadoSalud)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.EstadoSaludId);*/

			/*builder.HasOne(d => d.LugarResidencia)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.LugarResidenciaId);*/

			/*builder.HasOne(d => d.RelacionAMTAContacto)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.RelacionAMTAContactoId);*/

			/*builder.HasOne(d => d.RelacionAMTAVisita)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.RelacionAMTAVisitaId);*/

			/*builder.HasOne(d => d.RelacionCentroProfesionales)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.RelacionCentroProfesionalesId);*/

			/*builder.HasOne(d => d.RelacionCentroResidentes)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.RelacionCentroResidentesId);*/

			/*builder.HasOne(d => d.TipoRelacionFamiliar)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.TipoRelacionFamiliarId);*/

			/*builder.HasOne(d => d.Discapacidad)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.DiscapacidadId);*/

			/*builder.HasOne(d => d.DuracionLaboralFormativa)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.DuracionLaboralFormativaId);*/

			/*builder.HasOne(d => d.FormativaAutonomiaFormativa)
				.WithMany(p => p.DatosSocialesFormativaAutonomiaFormativa)
				.HasForeignKey(d => d.FormativaAutonomiaFormativaId);*/

			/*builder.HasOne(d => d.HabilidadPracticaAlimentacion)
				.WithMany(p => p.DatosSocialesHabilidadPracticaAlimentacion)
				.HasForeignKey(d => d.HabilidadPracticaAlimentacionId);*/

			/*builder.HasOne(d => d.HabilidadPracticaAplicarseMedidasTerapeuticas)
				.WithMany(p => p.DatosSocialesHabilidadPracticaAplicarseMedidasTerapeuticas)
				.HasForeignKey(d => d.HabilidadPracticaAplicarseMedidasTerapeuticasId);*/

			/*builder.HasOne(d => d.HabilidadPracticaDesplazamientoDentroDelHogar)
				.WithMany(p => p.DatosSocialesHabilidadPracticaDesplazamientoDentroDelHogar)
				.HasForeignKey(d => d.HabilidadPracticaDesplazamientoDentroDelHogarId);*/

			/*builder.HasOne(d => d.HabilidadPracticaDesplazamientoFueraDelHogar)
				.WithMany(p => p.DatosSocialesHabilidadPracticaDesplazamientoFueraDelHogar)
				.HasForeignKey(d => d.HabilidadPracticaDesplazamientoFueraDelHogarId);*/

			/*builder.HasOne(d => d.HabilidadPracticaDesplazamientoTransportePublico)
				.WithMany(p => p.DatosSocialesHabilidadPracticaDesplazamientoTransportePublico)
				.HasForeignKey(d => d.HabilidadPracticaDesplazamientoTransportePublicoId);*/

			/*builder.HasOne(d => d.HabilidadPracticaEvitarSituacionesRiesgo)
				.WithMany(p => p.DatosSocialesHabilidadPracticaEvitarSituacionesRiesgo)
				.HasForeignKey(d => d.HabilidadPracticaEvitarSituacionesRiesgoId);*/

			/*builder.HasOne(d => d.HabilidadPracticaHigienePersonal)
				.WithMany(p => p.DatosSocialesHabilidadPracticaHigienePersonal)
				.HasForeignKey(d => d.HabilidadPracticaHigienePersonalId);*/

			/*builder.HasOne(d => d.HabilidadPracticaPedirAyudaUrgencia)
				.WithMany(p => p.DatosSocialesHabilidadPracticaPedirAyudaUrgencia)
				.HasForeignKey(d => d.HabilidadPracticaPedirAyudaUrgenciaId);*/

			/*builder.HasOne(d => d.HabilidadPracticaSolicitarAsistencia)
				.WithMany(p => p.DatosSocialesHabilidadPracticaSolicitarAsistencia)
				.HasForeignKey(d => d.HabilidadPracticaSolicitarAsistenciaId);*/

			/*builder.HasOne(d => d.HabilidadPracticaTareaDomestica)
				.WithMany(p => p.DatosSocialesHabilidadPracticaTareaDomestica)
				.HasForeignKey(d => d.HabilidadPracticaTareaDomesticaId);*/

			/*builder.HasOne(d => d.HabilidadPracticaVestido)
				.WithMany(p => p.DatosSocialesHabilidadPracticaVestido)
				.HasForeignKey(d => d.HabilidadPracticaVestidoId);*/

			/*builder.HasOne(d => d.LaboralAutonomiaFormativa)
				.WithMany(p => p.DatosSocialesLaboralAutonomiaFormativa)
				.HasForeignKey(d => d.LaboralAutonomiaFormativaId);*/

			/*builder.HasOne(d => d.OcioAutonomiaFormativa)
				.WithMany(p => p.DatosSocialesOcioAutonomiaFormativa)
				.HasForeignKey(d => d.OcioAutonomiaFormativaId);*/

			/*builder.HasOne(d => d.Orientacion)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.OrientacionId);*/

			/*builder.HasOne(d => d.Pia)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.PiaId);*/

			/*builder.HasOne(d => d.SituacionSalud)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.SituacionSaludId);*/

			/*builder.HasOne(d => d.TipoCentroDeDia)
				.WithMany(p => p.DatosSocialesTipoCentroDeDia)
				.HasForeignKey(d => d.TipoCentroDeDiaId);*/

			/*builder.HasOne(d => d.TipoLaboralFormativa)
				.WithMany(p => p.DatosSociales)
				.HasForeignKey(d => d.TipoLaboralFormativaId);*/

			/*builder.HasOne(d => d.TipoResidencia)
				.WithMany(p => p.DatosSocialesTipoResidencia)
				.HasForeignKey(d => d.TipoResidenciaId);*/

		}
	}
}