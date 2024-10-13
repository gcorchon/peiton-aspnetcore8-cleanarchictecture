using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EmergenciaCentroConfiguration : IEntityTypeConfiguration<EmergenciaCentro>
{
	public void Configure(EntityTypeBuilder<EmergenciaCentro> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_EmergenciaCentro");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.MotivoEmergenciaCentroId).HasColumnName("Fk_MotivoEmergenciaCentro");

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.EmergenciasCentros)
			.HasForeignKey(d => d.UsuarioId);*/

		/*builder.HasOne(d => d.MotivoEmergenciaCentro)
			.WithMany(p => p.EmergenciasCentros)
			.HasForeignKey(d => d.MotivoEmergenciaCentroId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.EmergenciasCentros)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
