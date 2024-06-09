using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class EquipoAtencionEntidadGestoraConfiguration : IEntityTypeConfiguration<EquipoAtencionEntidadGestora>
	{
		public void Configure(EntityTypeBuilder<EquipoAtencionEntidadGestora> builder)
		{
			builder.HasKey(t => new { t.EntidadGestoraId, t.Orden});

			builder.Property(p => p.EntidadGestoraId).HasColumnName("Fk_EntidadGestora");
			builder.Property(p => p.CategoriaProfesionalEntidadGestoraId).HasColumnName("Fk_CategoriaProfesionalEntidadGestora");
			builder.Property(p => p.Otros).HasMaxLength(50);
			builder.Property(p => p.TipologiaProfesionalEntidadGestoraId).HasColumnName("Fk_TipologiaProfesionalEntidadGestora");

			/*builder.HasOne(d => d.CategoriaProfesionalEntidadGestora)
				.WithMany(p => p.EquiposAtencionesEntidadesGestoras)
				.HasForeignKey(d => d.CategoriaProfesionalEntidadGestoraId);*/

			/*builder.HasOne(d => d.EntidadGestora)
				.WithMany(p => p.EquiposAtencionesEntidadesGestoras)
				.HasForeignKey(d => d.EntidadGestoraId);*/

			/*builder.HasOne(d => d.TipologiaProfesionalEntidadGestora)
				.WithMany(p => p.EquiposAtencionesEntidadesGestoras)
				.HasForeignKey(d => d.TipologiaProfesionalEntidadGestoraId);*/

		}
	}
}