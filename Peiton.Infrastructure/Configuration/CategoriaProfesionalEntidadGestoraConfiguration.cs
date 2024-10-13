using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CategoriaProfesionalEntidadGestoraConfiguration : IEntityTypeConfiguration<CategoriaProfesionalEntidadGestora>
{
	public void Configure(EntityTypeBuilder<CategoriaProfesionalEntidadGestora> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_CategoriaProfesionalEntidadGestora");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
