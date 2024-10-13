using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipologiaProfesionalEntidadGestoraConfiguration : IEntityTypeConfiguration<TipologiaProfesionalEntidadGestora>
{
	public void Configure(EntityTypeBuilder<TipologiaProfesionalEntidadGestora> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TipologiaProfesionalEntidadGestora");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
