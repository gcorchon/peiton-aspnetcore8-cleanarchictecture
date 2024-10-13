using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TuteladoSaludFisicaConfiguration : IEntityTypeConfiguration<TuteladoSaludFisica>
{
	public void Configure(EntityTypeBuilder<TuteladoSaludFisica> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.Orden });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.SituacionSaludId).HasColumnName("Fk_SituacionSalud");
		builder.Property(p => p.ConcienciaEnfermedadId).HasColumnName("Fk_ConcienciaEnfermedad");
		builder.Property(p => p.AdhesionTratamientoId).HasColumnName("Fk_AdhesionTratamiento");
		builder.Property(p => p.AutonomiaTratamientoId).HasColumnName("Fk_AutonomiaTratamiento");
		builder.Property(p => p.Patologia).HasMaxLength(255);

		/*builder.HasOne(d => d.AdhesionTratamiento)
			.WithMany(p => p.TuteladosSaludFisicas)
			.HasForeignKey(d => d.AdhesionTratamientoId);*/

		/*builder.HasOne(d => d.AutonomiaTratamiento)
			.WithMany(p => p.TuteladosSaludFisicas)
			.HasForeignKey(d => d.AutonomiaTratamientoId);*/

		/*builder.HasOne(d => d.ConcienciaEnfermedad)
			.WithMany(p => p.TuteladosSaludFisicas)
			.HasForeignKey(d => d.ConcienciaEnfermedadId);*/

		/*builder.HasOne(d => d.SituacionSalud)
			.WithMany(p => p.TuteladosSaludFisicas)
			.HasForeignKey(d => d.SituacionSaludId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.TuteladosSaludFisicas)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
