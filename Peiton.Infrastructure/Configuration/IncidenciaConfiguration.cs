using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class IncidenciaConfiguration : IEntityTypeConfiguration<Incidencia>
{
	public void Configure(EntityTypeBuilder<Incidencia> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Incidencia");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.Titulo).HasMaxLength(255);
		builder.Property(p => p.IncidenciaEstadoId).HasColumnName("Fk_IncidenciaEstado");

		/*builder.HasOne(d => d.IncidenciaEstado)
			.WithMany(p => p.Incidencias)
			.HasForeignKey(d => d.IncidenciaEstadoId);*/

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.Incidencias)
			.HasForeignKey(d => d.UsuarioId);*/

	}
}
