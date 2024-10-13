using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class PerfilUsuarioEntidadGestoraConfiguration : IEntityTypeConfiguration<PerfilUsuarioEntidadGestora>
{
	public void Configure(EntityTypeBuilder<PerfilUsuarioEntidadGestora> builder)
	{
		builder.HasKey(t => new { t.EntidadGestoraId, t.Orden });

		builder.Property(p => p.EntidadGestoraId).HasColumnName("Fk_EntidadGestora");
		builder.Property(p => p.TipoDiscapacidad).HasMaxLength(250);
		builder.Property(p => p.Edad).HasMaxLength(50);
		builder.Property(p => p.NumeroPersonas).HasMaxLength(50);

		/*builder.HasOne(d => d.EntidadGestora)
			.WithMany(p => p.PerfilesUsuariosEntidadesGestoras)
			.HasForeignKey(d => d.EntidadGestoraId);*/

	}
}
