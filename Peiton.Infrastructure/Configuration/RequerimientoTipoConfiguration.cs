using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class RequerimientoTipoConfiguration : IEntityTypeConfiguration<RequerimientoTipo>
{
	public void Configure(EntityTypeBuilder<RequerimientoTipo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_RequerimientoTipo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
