using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EmergenciaConfiguration : IEntityTypeConfiguration<Emergencia>
{
	public void Configure(EntityTypeBuilder<Emergencia> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Emergencia");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.MotivoEmergenciaId).HasColumnName("Fk_MotivoEmergencia");
		builder.Property(p => p.EmergenciaLlamadaId).HasColumnName("Fk_EmergenciaLlamada");

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.Emergencias)
			.HasForeignKey(d => d.UsuarioId);*/

		/*builder.HasOne(d => d.EmergenciaLlamada)
			.WithMany(p => p.Emergencias)
			.HasForeignKey(d => d.EmergenciaLlamadaId);*/

		/*builder.HasOne(d => d.MotivoEmergencia)
			.WithMany(p => p.Emergencias)
			.HasForeignKey(d => d.MotivoEmergenciaId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Emergencias)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
